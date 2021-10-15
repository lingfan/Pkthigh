using System;
using System.Collections.Generic;
using ILRuntime.CLR.TypeSystem;
using ILRuntime.Runtime.Intepreter;
using JEngine.Core;
using UnityEditor;
using UnityEditor.AnimatedValues;

namespace JEngine.Editor
{
    public partial class SerializeILTypeInstance
    {
        [SerializeTypeMethod(6)]
        public static bool SerializePrimitiveType(AnimBool fadeGroup, Type cType, IType type,
            ILTypeInstance instance, string name, object val)
        {
            if (cType.IsPrimitive) //如果是基础类型
            {
                try
                {
                    if (cType == typeof(float))
                    {
                        val = EditorGUILayout.FloatField(name, (float) val);
                    }
                    else if (cType == typeof(double))
                    {
                        val = EditorGUILayout.DoubleField(name, (double) val);
                    }
                    else if (cType == typeof(int))
                    {
                        val = EditorGUILayout.IntField(name, (int) val);
                    }
                    else if (cType == typeof(long))
                    {
                        val = EditorGUILayout.LongField(name, (long) val);
                    }
                    else if (cType == typeof(bool))
                    {
                        var result = bool.TryParse(val.ToString(), out var value);
                        if (!result)
                        {
                            value = val.ToString() == "1";
                        }

                        val = EditorGUILayout.Toggle(name, value);
                    }
                    else
                    {
                        EditorGUILayout.LabelField(name, val.ToString());
                    }
                }
                catch (Exception e)
                {
                    Log.PrintError($"无法序列化{name}，{e.Message}，{e.StackTrace}");
                    EditorGUILayout.LabelField(name, val.ToString());
                }

                return true;
            }

            return false;
        }
    }
}