using System;
using System.Collections.Generic;
using System.Reflection;
using ILRuntime.CLR.TypeSystem;
using ILRuntime.Runtime.Intepreter;
using UnityEditor;
using UnityEditor.AnimatedValues;

namespace JEngine.Editor
{
    public partial class SerializeILTypeInstance
    {
        [SerializeTypeMethod(2)]
        public static bool SerializeBindablePropertyType(AnimBool fadeGroup, Type cType, IType type,
            ILTypeInstance instance, string name, object val)
        {
            //可绑定值，可以尝试更改
            if (type.ReflectionType.ToString().Contains("BindableProperty") && val != null)
            {
                PropertyInfo fi = type.ReflectionType.GetProperty("Value");
                var val2 = fi?.GetValue(val);

                string genericTypeStr = type.ReflectionType.ToString().Split('`')[1].Replace("1<", "")
                    .Replace(">", "");
                Type genericType = Type.GetType(genericTypeStr);
                if (genericType == null ||
                    (!genericType.IsPrimitive && genericType != typeof(string))) //不是基础类型或字符串
                {
                    EditorGUILayout.LabelField(name, val2?.ToString()); //只显示字符串
                }
                else
                {
                    //可更改
                    var data = Core.Tools.ConvertSimpleType(EditorGUILayout.TextField(name, val2?.ToString()),
                        genericType);
                    if (data != null) //尝试更改
                    {
                        fi?.SetValue(val, data);
                    }
                }

                return true;
            }

            return false;
        }
    }
}