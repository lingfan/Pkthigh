using System;
using System.Collections.Generic;
using System.Linq;
using ILRuntime.CLR.TypeSystem;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;

namespace JEngine.Editor
{
    public partial class SerializeILTypeInstance
    {
        [SerializeTypeMethod(1)]
        public static bool SerializeCrossBindingAdaptorType(AnimBool fadeGroup, Type cType, IType type,
            ILTypeInstance instance, string name, object val)
        {
            //可绑定值，可以尝试更改
            if (cType.GetInterfaces().Contains(typeof(CrossBindingAdaptorType))) //需要跨域继承的普遍都有适配器
            {
                var clrInstance = Tools.FindObjectsOfTypeAll<CrossBindingAdaptorType>()
                    .Find(adaptor =>
                        adaptor.ILInstance.Equals(val)) as MonoBehaviour;
                if (clrInstance != null)
                {
                    GUI.enabled = true;
                    EditorGUILayout.ObjectField(name, clrInstance, typeof(MonoBehaviour), true);
                    GUI.enabled = false;
                }

                return true;
            }

            return false;
        }
    }
}