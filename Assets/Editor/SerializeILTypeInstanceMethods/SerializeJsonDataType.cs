using System;
using System.Collections.Generic;
using ILRuntime.CLR.TypeSystem;
using ILRuntime.Runtime.Intepreter;
using LitJson;
using UnityEditor;
using UnityEditor.AnimatedValues;

namespace JEngine.Editor
{
    public partial class SerializeILTypeInstance
    {
        [SerializeTypeMethod(4)]
        public static bool SerializeJsonDataType(AnimBool fadeGroup, Type cType, IType type,
            ILTypeInstance instance, string name, object val)
        {
            if (cType == typeof(JsonData)) //可以折叠显示Json数据
            {
                if (val != null)
                {
                    fadeGroup.target = EditorGUILayout.Foldout(fadeGroup.target, name, true);
                    if (EditorGUILayout.BeginFadeGroup(fadeGroup.faded))
                    {
                        val = EditorGUILayout.TextArea(
                            ((JsonData) val).ToString()
                        );
                    }

                    EditorGUILayout.EndFadeGroup();
                    EditorGUILayout.Space();
                }
                else
                {
                    EditorGUILayout.LabelField(name, "暂无值的JsonData");
                }

                return true;
            }

            return false;
        }
    }
}