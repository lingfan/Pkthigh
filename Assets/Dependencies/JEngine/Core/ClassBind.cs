using libx;
using System;
using System.Collections;
using System.Collections.Generic;
using Malee.List;
using System.Linq;
using UnityEngine;
using System.Reflection;
using ILRuntime.CLR.Utils;
using ILRuntime.Reflection;
using Sirenix.OdinInspector;
using ILRuntime.CLR.TypeSystem;
using UnityEngine.Serialization;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using AppDomain = ILRuntime.Runtime.Enviorment.AppDomain;
using Object = UnityEngine.Object;

namespace JEngine.Core
{
    [HelpURL("https://xgamedev.uoyou.com/classbind-v0-6.html")]
    public class ClassBind : SerializedMonoBehaviour
    {
        [Searchable] [FormerlySerializedAs("ScriptsToBind")]
        public ClassData[] scriptsToBind = new ClassData[1];

        /// <summary>
        /// Add class
        /// </summary>
        /// <param name="classData"></param>
        /// <returns></returns>
        public object AddClass(ClassData classData)
        {
            //添加脚本
            string classType =
                $"{classData.classNamespace + (string.IsNullOrEmpty(classData.classNamespace) ? "" : ".")}{classData.className}";
            if (!InitJEngine.Appdomain.LoadedTypes.TryGetValue(classType, out var type))
            {
                Log.PrintError($"自动绑定{name}出错：{classType}不存在，已跳过");
                return null;
            }

            Type t = type.ReflectionType; //获取实际属性
            classData.ClassType = t;
            Type baseType =
                t.BaseType is ILRuntimeWrapperType wrapperType
                    ? wrapperType.RealType
                    : t.BaseType; //这个地方太坑了 你一旦热更工程代码写的骚 就会导致ILWrapperType这个问题出现 一般人还真不容易发现这个坑
            Type monoType = typeof(MonoBehaviour);

            //JBehaviour需自动赋值一个值
            bool isMono = t.IsSubclassOf(monoType) || (baseType != null && baseType.IsSubclassOf(monoType));
            bool needAdapter = baseType != null &&
                               baseType.GetInterfaces().Contains(typeof(CrossBindingAdaptorType));

            ILTypeInstance instance = isMono
                ? new ILTypeInstance(type as ILType, false)
                : InitJEngine.Appdomain.Instantiate(classType);

            instance.CLRInstance = instance;

            /*
             * 这里是ClassBind的灵魂，我都佩服我自己这么写，所以别乱改这块
             * 非mono的跨域继承用特殊的，就是用JEngine提供的一个mono脚本，来显示字段，里面存ILTypeInstance
             * 总之JEngine牛逼
             * ClassBind只支持挂以下2种热更类型：纯热更类型，继承了Mono的类型（无论是主工程多重继承后跨域还是跨域后热更工程多重继承都可以）
             * 主工程多重继承后再跨域多重继承的应该还不支持
             */
            //主工程多重继承后跨域继承的生成适配器后用这个
            if (needAdapter && isMono && baseType != typeof(MonoBehaviourAdapter.Adaptor))
            {
                Type adapterType = Type.GetType(baseType.FullName ?? string.Empty);
                if (adapterType == null)
                {
                    Log.PrintError($"{t.FullName}, need to generate adapter");
                    return null;
                }

                //直接反射赋值一波了
                var clrInstance = gameObject.AddComponent(adapterType) as MonoBehaviour;

                var clrILInstance = t.GetFields(
                        BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
                    .First(f => f.Name == "instance" && f.FieldType == typeof(ILTypeInstance));
                var clrAppDomain = t.GetFields(
                        BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
                    .First(f => f.Name == "appdomain" && f.FieldType == typeof(AppDomain));
                if (!(clrInstance is null))
                {
                    clrInstance.enabled = false;
                    clrILInstance.SetValue(clrInstance, instance);
                    clrAppDomain.SetValue(clrInstance, InitJEngine.Appdomain);
                    instance.CLRInstance = clrInstance;
                    classData.ClrInstance = (CrossBindingAdaptorType) clrInstance;
                }
            }
            //直接继承Mono的，热更工程多层继承mono的，非继承mono的，或不需要继承的，用这个
            else
            {
                //挂个适配器到编辑器（直接继承mono，非继承mono，无需继承，都可以用这个）
                var clrInstance = gameObject.AddComponent<MonoBehaviourAdapter.Adaptor>();
                clrInstance.enabled = false;
                clrInstance.ILInstance = instance;
                clrInstance.AppDomain = InitJEngine.Appdomain;
                classData.ClrInstance = clrInstance;


                //是MonoBehaviour继承，需要指定CLRInstance
                if (isMono)
                {
                    instance.CLRInstance = clrInstance;
                }

                //判断类型
                clrInstance.isMonoBehaviour = isMono;

                classData.Added = true;

                //JBehaviour额外处理
                var go = t.GetField("_gameObject", BindingFlags.Public);
                go?.SetValue(clrInstance.ILInstance, gameObject);
            }

            if (isMono)
            {
                if (type.BaseType.ReflectionType is ILRuntimeType)
                {
                    Log.PrintWarning(
                        "因为有跨域多层继承MonoBehaviour，会有一个可以忽略的警告：You are trying to create a MonoBehaviour using the 'new' keyword.  This is not allowed.  MonoBehaviours can only be added using AddComponent(). Alternatively, your script can inherit from ScriptableObject or no base class at all");
                    type.ReflectionType.GetConstructor(new Type[] { })?.Invoke(instance, new object[] { });
                }
                else
                {
                    var m = type.GetConstructor(Extensions.EmptyParamList);
                    if (m != null)
                    {
                        InitJEngine.Appdomain.Invoke(m, instance, null);
                    }
                }
            }

            return instance;
        }

        /// <summary>
        /// Set value
        /// </summary>
        /// <param name="classData"></param>
        public void SetVal(ClassData classData)
        {
            var classType =
                $"{classData.classNamespace + (classData.classNamespace == "" ? "" : ".")}{classData.className}";
            var t = classData.ClassType;
            var clrInstance = classData.ClrInstance;
            //绑定数据
            classData.BoundData = false;
            var fields = classData.fields.ToArray();
            object obj = null;
            const BindingFlags flag = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance |
                                      BindingFlags.Static;

            foreach (var field in fields)
            {
                try
                {
                    Type fieldType = null;
                    if (field.fieldType != FieldType.Bool)
                    {
                        fieldType = t.GetField(field.fieldName, flag
                        ).FieldType ?? t.GetProperty(field.fieldName, flag).PropertyType;
                    }

                    switch (field.fieldType)
                    {
                        case FieldType.Number:
                        {
                            fieldType = ((ILRuntimeWrapperType) fieldType).RealType;
                            obj = Tools.GetPrimitiveFromString(fieldType, field.value);
                            classData.BoundData = true;
                            break;
                        }
                        case FieldType.String:
                            fieldType = typeof(string);
                            obj = Tools.GetPrimitiveFromString(fieldType, field.value);
                            classData.BoundData = true;
                            break;
                        case FieldType.Bool:
                            fieldType = typeof(bool);
                            obj = Tools.GetPrimitiveFromString(fieldType, field.value);
                            classData.BoundData = true;
                            break;
                        case FieldType.GameObject:
                            obj = field.gameObject is GameObject
                                ? field.gameObject
                                : (field.gameObject as MonoBehaviour).gameObject;
                            classData.BoundData = true;
                            break;
                        case FieldType.UnityComponent when field.gameObject is GameObject go:
                        {
                            if (fieldType != null)
                            {
                                obj = Tools.GetInstanceFromGO(fieldType, go);
                                classData.BoundData = true;
                            }
                            else
                            {
                                Log.PrintError(
                                    $"自动绑定{name}出错：{classType}.{field.fieldName}赋值出错：{field.fieldName}不存在");
                            }

                            break;
                        }
                        case FieldType.UnityComponent:
                            obj = field.gameObject;
                            classData.BoundData = true;
                            break;
                        case FieldType.HotUpdateResource:
                            obj = AssetMgr.Load(field.path ?? field.value, typeof(Object));
                            classData.BoundData = true;
                            break;
                        case FieldType.NotSupported:
                            continue;
                        case FieldType.PrimitiveTypeList:
                            string[] pLst = field.primitiveTypeList;
                            if (!Tools.MakeArrayForClassBind(fieldType, true, ref obj, pLst))
                            {
                                Log.PrintError(
                                    $"自动绑定{name}出错：{classType}.{field.fieldName}赋值出错：{field.fieldName}不是List或Array，已跳过");
                                continue;
                            }

                            classData.BoundData = true;
                            break;
                        case FieldType.UnityObjectTypeList:
                            var lst = field.unityObjectTypeList;
                            if (!Tools.MakeArrayForClassBind(fieldType, false, ref obj, null, lst))
                            {
                                Log.PrintError(
                                    $"自动绑定{name}出错：{classType}.{field.fieldName}赋值出错：{field.fieldName}不是List或Array，已跳过");
                                continue;
                            }

                            classData.BoundData = true;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                catch (Exception except)
                {
                    Log.PrintError(
                        $"自动绑定{name}出错：{classType}.{field.fieldName}获取值{field.value}出错：{except.Message},{except.StackTrace}，已跳过");
                }

                //如果有数据再绑定
                if (!classData.BoundData) continue;
                try
                {
                    var fi = t.GetField(field.fieldName, flag);
                    if (fi != null)
                    {
                        fi.SetValue(clrInstance.ILInstance, obj);
                    }
                    else
                    {
                        //没FieldInfo尝试PropertyInfo
                        var pi = t.GetProperty(field.fieldName, flag);
                        if (pi != null)
                        {
                            pi.SetValue(clrInstance.ILInstance, obj);
                        }
                        else
                        {
                            Log.PrintError($"自动绑定{name}出错：{classType}不存在{field.fieldName}，已跳过");
                        }
                    }
                }
                catch (Exception e)
                {
                    Log.PrintError(
                        $"自动绑定{name}出错：{classType}.{field.fieldName}赋值出错：{e.Message}，已跳过");
                }
            }
        }

        /// <summary>
        /// Active
        /// </summary>
        /// <param name="classData"></param>
        public void Active(ClassData classData)
        {
            var classType =
                $"{classData.classNamespace + (classData.classNamespace == "" ? "" : ".")}{classData.className}";
            var t = classData.ClassType;
            var clrInstance = classData.ClrInstance;
            //是否激活
            if (classData.activeAfter)
            {
                if (classData.BoundData == false &&  classData.fields != null &&
                    classData.fields.Count > 0)
                {
                    Log.PrintError($"自动绑定{name}出错：{classType}没有成功绑定数据，自动激活成功，但可能会抛出空异常！");
                }

                //Mono类型能设置enabled
                if (clrInstance.GetType().IsSubclassOf(typeof(MonoBehaviour)))
                {
                    ((MonoBehaviour) clrInstance).enabled = true;
                }

                //不管是啥类型，直接invoke这个awake方法
                const BindingFlags flag = BindingFlags.Default | BindingFlags.Public
                                                               | BindingFlags.Instance | BindingFlags.FlattenHierarchy |
                                                               BindingFlags.NonPublic | BindingFlags.Static;
                var awakeMethod = clrInstance.GetType().GetMethod("Awake", flag) ??
                                  t.GetMethod("Awake", flag);

                if (awakeMethod == null)
                {
                    Log.PrintError($"{t.FullName}不包含Awake方法，无法激活，已跳过");
                }
                else if (!classData.Activated)
                {
                    awakeMethod.Invoke(clrInstance, null);
                    classData.Activated = true;
                }
            }
        }

        /// <summary>
        /// Remove cb
        /// </summary>
        public void Remove()
        {
            //添加后删除
            Destroy(this);
        }
    }

    [Serializable]
    public class ClassData
    {
        [FoldoutGroup("$className")] [FormerlySerializedAs("Namespace")]
        public string classNamespace = "HotUpdateScripts";

        [FoldoutGroup("$className")] [FormerlySerializedAs("Class")]
        public string className = "";

        [FoldoutGroup("$className")] [FormerlySerializedAs("ActiveAfter")]
        public bool activeAfter = true;

        [Searchable]
        [ListDrawerSettings(ShowPaging = true, NumberOfItemsPerPage = 6)]
        [FoldoutGroup("$className")]
        [PropertySpace(0, 15)]
        [FormerlySerializedAs("Fields")]
        public FieldList fields;

        public bool BoundData { get; set; }
        public bool Added { get; set; }
        public bool Activated { get; set; }
        
        public CrossBindingAdaptorType ClrInstance { get; set; }
        public Type ClassType { get; set; }
    }

    [Serializable]
    public class ClassField
    {
        [HideLabel]
        [Tooltip("需要赋值的字段的名字")]
        [HorizontalGroup("$fieldName/Split", 0.25f)]
        [BoxGroup("$fieldName/Split/Member", centerLabel: true)]
        public string fieldName;

        [HideLabel]
        [FoldoutGroup("$fieldName")]
        [HorizontalGroup("$fieldName/Split", 150)]
        [BoxGroup("$fieldName/Split/Type", centerLabel: true)]
        public FieldType fieldType;

        [HideLabel]
        [Tooltip("基本数据的字符串值")]
        [BoxGroup("$fieldName/Split/Value", centerLabel: true)]
        [ShowIf("@this.fieldType == FieldType.Number ||" +
                "this.fieldType == FieldType.String || " +
                "this.fieldType == FieldType.Bool")]
        public string value;

        [FilePath]
        [HideLabel]
        [Tooltip("热更资源的路径")]
        [BoxGroup("$fieldName/Split/Value", centerLabel: true)]
        [ShowIf("@this.fieldType == FieldType.HotUpdateResource")]
        public string path;

        [HideLabel]
        [Tooltip("GameObject或UnityComponent所对应的游戏物体")]
        [BoxGroup("$fieldName/Split/Value", centerLabel: true)]
        [ShowIf(
            "@this.fieldType == FieldType.GameObject || " +
            "this.fieldType == FieldType.UnityComponent")]
        public Object gameObject;

        [Tooltip("基础类型数组或列表的值")]
        [BoxGroup("$fieldName/Split/Value", centerLabel: true)]
        [ShowIf("@this.fieldType == FieldType.PrimitiveTypeList")]
        [ListDrawerSettings(ShowPaging = true, NumberOfItemsPerPage = 5)]
        public string[] primitiveTypeList;

        [Tooltip("UnityObject类型数组或列表的值")]
        [BoxGroup("$fieldName/Split/Value", centerLabel: true)]
        [ShowIf("@this.fieldType == FieldType.UnityObjectTypeList")]
        [ListDrawerSettings(ShowPaging = true, NumberOfItemsPerPage = 5)]
        public Object[] unityObjectTypeList;
    }

    public enum FieldType
    {
        Number,
        String,
        Bool,
        GameObject,
        UnityComponent,
        HotUpdateResource,
        NotSupported,
        PrimitiveTypeList,
        UnityObjectTypeList,
    }

    [Serializable]
    public class FieldList : ReorderableArray<ClassField>
    {
    }
}