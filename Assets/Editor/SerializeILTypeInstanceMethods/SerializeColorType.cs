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
        [SerializeTypeMethod(8)]
        public static bool SerializeColorType(AnimBool fadeGroup, Type cType, IType type,
            ILTypeInstance instance, string name, object val)
        {
            if (cType == typeof(Color))
            {
                if (val != null)
                {
                    val = EditorGUILayout.ColorField(name, (Color) val);
                }
                else
                {
                    val = EditorGUILayout.ColorField(name, Color.white);
                }

                return true;
            }

            return false;
        }
    }
}