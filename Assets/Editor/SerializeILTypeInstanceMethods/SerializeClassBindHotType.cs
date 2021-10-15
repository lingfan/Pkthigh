using System;
using System.Collections.Generic;
using ILRuntime.CLR.TypeSystem;
using ILRuntime.Runtime.Intepreter;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;

namespace JEngine.Editor
{
    public partial class SerializeILTypeInstance
    {
        [SerializeTypeMethod(0)]
        public static bool SerializeClassBindHotType(AnimBool fadeGroup, Type cType, IType type,
            ILTypeInstance instance, string name, object val)
        {
            try
            {
                var clrInstance = Tools.FindObjectsOfTypeAll<MonoBehaviourAdapter.Adaptor>()
                    .Find(adaptor =>
                        adaptor.ILInstance.Equals(val));
                if (clrInstance != null)
                {
                    GUI.enabled = true;
                    EditorGUILayout.ObjectField(name, clrInstance, typeof(MonoBehaviourAdapter.Adaptor),
                        true);
                    GUI.enabled = false;
                }
                else
                {
                    EditorGUILayout.LabelField(name, val.ToString());
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}