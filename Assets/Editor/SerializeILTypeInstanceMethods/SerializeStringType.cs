using System;
using System.Collections.Generic;
using ILRuntime.CLR.TypeSystem;
using ILRuntime.Runtime.Intepreter;
using UnityEditor;
using UnityEditor.AnimatedValues;

namespace JEngine.Editor
{
    public partial class SerializeILTypeInstance
    {
        [SerializeTypeMethod(5)]
        public static bool SerializeStringType(AnimBool fadeGroup, Type cType, IType type,
            ILTypeInstance instance, string name, object val)
        {
            if (cType == typeof(string))
            {
                if (val != null)
                {
                    val = EditorGUILayout.TextField(name, (string) val);
                }
                else
                {
                    val = EditorGUILayout.TextField(name, "");
                }

                return true;
            }

            return false;
        }
    }
}