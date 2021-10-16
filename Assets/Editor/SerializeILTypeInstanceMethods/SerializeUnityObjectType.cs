using System;
using System.Collections.Generic;
using System.Linq;
using ILRuntime.CLR.TypeSystem;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using UnityEditor;
using UnityEditor.AnimatedValues;
using Object = UnityEngine.Object;

namespace JEngine.Editor
{
    public partial class SerializeILTypeInstance
    {
        [SerializeTypeMethod(3)]
        public static bool SerializeUnityObjectType(AnimBool fadeGroup, Type cType, IType type,
            ILTypeInstance instance, string name, object val)
        {
            if (typeof(Object).IsAssignableFrom(cType))
            {
                if (cType.GetInterfaces().Contains(typeof(CrossBindingAdaptorType)))
                {
                    return false;
                }

                //处理Unity类型
                var res = EditorGUILayout.ObjectField(name, val as Object, cType, true);
                val = res;

                return true;
            }

            return false;
        }
    }
}