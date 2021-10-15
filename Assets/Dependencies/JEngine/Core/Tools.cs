using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using ILRuntime.CLR.TypeSystem;
using ILRuntime.Reflection;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using UnityEngine;
using Component = UnityEngine.Component;
using Object = System.Object;

namespace JEngine.Core
{
    public static class Tools
    {
        public static readonly object[] Param0 = new object[0];

        public static object ConvertSimpleType(object value, Type destinationType)
        {
            object returnValue;
            if (value == null || destinationType.IsInstanceOfType(value))
            {
                return value;
            }

            string str = value as string;
            if (str != null && str.Length == 0)
            {
                return destinationType.IsValueType ? Activator.CreateInstance(destinationType) : null;
            }

            TypeConverter converter = TypeDescriptor.GetConverter(destinationType);
            bool flag = converter.CanConvertFrom(value.GetType());
            if (!flag)
            {
                converter = TypeDescriptor.GetConverter(value.GetType());
            }

            if (!flag && !converter.CanConvertTo(destinationType))
            {
                Log.PrintError("无法转换成类型：'" + value + "' ==> " + destinationType);
            }

            try
            {
                returnValue = flag
                    ? converter.ConvertFrom(null, null, value)
                    : converter.ConvertTo(null, null, value, destinationType);
            }
            catch (Exception e)
            {
                Log.PrintError("类型转换出错：'" + value + "' ==> " + destinationType + "\n" + e.Message);
                returnValue = destinationType.IsValueType ? Activator.CreateInstance(destinationType) : null;
            }

            return returnValue;
        }

        public static GameObject GetGameObject(object ins)
        {
            GameObject instance;
            if (ins is GameObject g)
            {
                instance = g;
            }
            else if (ins is ILTypeInstance ilt)
            {
                instance = FindGOForHotClass(ilt);
            }
            else if (ins is Transform t)
            {
                instance = t.gameObject;
            }
            else if (ins is Component c)
            {
                instance = c.gameObject;
            }
            else
            {
                instance = null;
            }

            return instance;
        }

        /// <summary>
        /// 找到热更对象的gameObject
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static GameObject FindGOForHotClass(ILTypeInstance instance)
        {
            var returnType = instance.Type;
            PropertyInfo pi = null;
            if (returnType.ReflectionType == typeof(MonoBehaviour))
            {
                pi = returnType.ReflectionType.GetProperty("gameObject");
            }

            if (returnType.ReflectionType.IsSubclassOf(typeof(MonoBehaviour)))
            {
                if (returnType.ReflectionType.BaseType != null)
                {
                    pi = returnType.ReflectionType.BaseType.GetProperty("gameObject");
                }
            }

            return pi?.GetValue(instance.CLRInstance) as GameObject;
        }

        public static List<T> FindObjectsOfTypeAll<T>()
        {
            return ClassBindMgr.LoadedScenes.SelectMany(scene => scene.GetRootGameObjects())
                .SelectMany(g => g.GetComponentsInChildren<T>(true))
                .ToList();
        }


        /// <summary>
        /// Get a primitive value from string
        /// </summary>
        /// <param name="fieldType"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static object GetPrimitiveFromString(Type fieldType, string val)
        {
            object obj = null;
            if (fieldType == typeof(SByte))
            {
                obj = SByte.Parse(val);
            }
            else if (fieldType == typeof(Byte))
            {
                obj = Byte.Parse(val);
            }
            else if (fieldType == typeof(Int16))
            {
                obj = Int16.Parse(val);
            }
            else if (fieldType == typeof(UInt16))
            {
                obj = UInt16.Parse(val);
            }
            else if (fieldType == typeof(Int32))
            {
                obj = Int32.Parse(val);
            }
            else if (fieldType == typeof(UInt32))
            {
                obj = UInt32.Parse(val);
            }
            else if (fieldType == typeof(Int64))
            {
                obj = Int64.Parse(val);
            }
            else if (fieldType == typeof(UInt64))
            {
                obj = UInt64.Parse(val);
            }
            else if (fieldType == typeof(Single))
            {
                obj = Single.Parse(val);
            }
            else if (fieldType == typeof(Decimal))
            {
                obj = Decimal.Parse(val);
            }
            else if (fieldType == typeof(Double))
            {
                obj = Double.Parse(val);
            }
            else if (fieldType == typeof(bool))
            {
                obj = val == "true";
                if ((bool) obj) return obj;
                val = val.ToLower();
                obj = val == "true";
            }
            else if (fieldType == typeof(string))
            {
                obj = val;
            }

            return obj;
        }

        /// <summary>
        /// Get a class instance from a gameObject, can be either hot or local
        /// </summary>
        /// <param name="fieldType"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static object GetInstanceFromGO(Type fieldType, UnityEngine.Object obj)
        {
            if (obj.GetType() == fieldType || obj.GetType().FullName == fieldType.FullName)
            {
                return obj;
            }

            GameObject go;
            if (obj is GameObject o)
            {
                go = o;
            }
            else
            {
                go = (obj as Component)?.gameObject;
            }

            if (fieldType is ILRuntimeType) //如果在热更中
            {
                if (go is null) return null;
                var components = go.GetComponents<CrossBindingAdaptorType>();
                foreach (var c in components)
                {
                    if (c.ILInstance.Type.FullName != fieldType.FullName) continue;
                    return c.ILInstance;
                }
            }
            else
            {
                if (fieldType is ILRuntimeWrapperType type)
                {
                    fieldType = type.RealType;
                }

                if (!(go is null))
                {
                    return go.GetComponents<Component>().ToList()
                        .Find(c => c.GetType() == fieldType);
                }
            }

            return null;
        }


        public static bool MakeArrayForClassBind(Type fieldType, bool primitive, ref object obj, string[] pLst = null,
            UnityEngine.Object[] lst = null)
        {
            if (fieldType != null)
            {
                IList list;
                Type elemType;
                var isArray = fieldType.IsArray;
                if (isArray)
                {
                    elemType = fieldType.GetElementType();
                }
                else if (fieldType.IsGenericType &&
                         fieldType.GetGenericTypeDefinition() == typeof(List<>))
                {
                    elemType = fieldType.GenericTypeArguments[0];
                    if (elemType == typeof(ILTypeInstance))
                    {
                        elemType = (fieldType as ILRuntimeWrapperType)?.CLRType.GenericArguments[0].Value
                            .ReflectionType;
                    }
                }
                else
                {
                    return false;
                }

                if (elemType == null) return false;

                if (elemType is ILRuntimeType && lst != null)
                {
                    list = new List<ILTypeInstance>();
                    foreach (var ele in lst)
                    {
                        list.Add(Tools.GetInstanceFromGO(elemType, ele) as ILTypeInstance);
                    }
                }
                else
                {
                    Type listType = typeof(List<>);
                    Type newType = listType.MakeGenericType(elemType);
                    list = Activator.CreateInstance(newType, new object[] { }) as IList;
                    if (primitive && pLst != null)
                    {
                        foreach (var ele in pLst)
                        {
                            list?.Add(Tools.GetPrimitiveFromString(elemType, ele));
                        }
                    }
                    else if (lst != null)
                    {
                        foreach (var ele in lst)
                        {
                            list?.Add(Tools.GetInstanceFromGO(elemType, ele));
                        }
                    }
                }

                if (!isArray)
                {
                    obj = list;
                }
                else
                {
                    if (list != null)
                    {
                        int n = list.Count;
                        obj = Array.CreateInstance(elemType, n);
                        for (int i = 0; i < n; i++)
                            ((Array) obj).SetValue(list[i], i);
                    }
                }

                return true;
            }

            return false;
        }

        public static object GetHotComponent(GameObject gameObject, string typeName)
        {
            var clrInstances = gameObject.GetComponents<CrossBindingAdaptorType>();
            return clrInstances.ToList()
                .FindAll(a => a.ILInstance != null && (a.ILInstance.Type.ReflectionType.FullName == typeName ||
                                                       a.ILInstance.Type.ReflectionType.Name == typeName ||
                                                       a.ILInstance.Type.BaseType.FullName == typeName ||
                                                       a.ILInstance.Type.BaseType.ReflectionType.FullName == typeName))
                .Select(a => a.ILInstance).ToArray();
        }

        public static object GetHotComponent(GameObject gameObject, ILType type)
        {
            var clrInstances = gameObject.GetComponents<CrossBindingAdaptorType>();
            return clrInstances.ToList()
                .FindAll(a => a.ILInstance != null && (a.ILInstance.Type == type || a.ILInstance.Type.BaseType == type))
                .Select(a => a.ILInstance).ToArray();
        }

        public static object GetHotComponent(CrossBindingAdaptorType[] adapters, ILType type)
        {
            return adapters.ToList()
                .FindAll(a => a.ILInstance != null && (a.ILInstance.Type == type || a.ILInstance.Type.BaseType == type))
                .Select(a => a.ILInstance).ToArray();
        }

        public static object GetHotComponent(List<CrossBindingAdaptorType> adapters, ILType type)
        {
            return adapters
                .FindAll(a => a.ILInstance != null && (a.ILInstance.Type == type || a.ILInstance.Type.BaseType == type))
                .Select(a => a.ILInstance).ToArray();
        }

        public static void DestroyHotComponent(GameObject gameObject, object hotObject)
        {
            var clrInstances = gameObject.GetComponents<CrossBindingAdaptorType>();
            var objs = clrInstances.ToList()
                .FindAll(a => a.ILInstance != null && Equals(a.ILInstance, hotObject));
            foreach (var obj in objs)
            {
                UnityEngine.Object.Destroy(obj as MonoBehaviour);
            }
        }

        public static object GetHotComponentInChildren(GameObject gameObject, string typeName)
        {
            var clrInstances = gameObject.GetComponentsInChildren<CrossBindingAdaptorType>(true);
            return clrInstances.ToList()
                .FindAll(a => a.ILInstance != null && (a.ILInstance.Type.ReflectionType.FullName == typeName ||
                                                       a.ILInstance.Type.ReflectionType.Name == typeName ||
                                                       a.ILInstance.Type.BaseType.FullName == typeName ||
                                                       a.ILInstance.Type.BaseType.ReflectionType.FullName == typeName))
                .Select(a => a.ILInstance).ToArray();
        }
    }
}