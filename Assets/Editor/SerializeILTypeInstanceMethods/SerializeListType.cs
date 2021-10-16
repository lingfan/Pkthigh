using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using ILRuntime.CLR.TypeSystem;
using ILRuntime.Reflection;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;
using Object = UnityEngine.Object;

namespace JEngine.Editor
{
    public partial class SerializeILTypeInstance
    {
       [SerializeTypeMethod(7)]
        public static bool SerializeListType(AnimBool fadeGroup, Type cType, IType type,
            ILTypeInstance instance, string name, object val)
        {
            var fieldType = instance.Type.ReflectionType.GetField(name,
                    BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance |
                    BindingFlags.Static)
                ?.FieldType ?? instance.Type.ReflectionType.GetProperty(name,
                BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance |
                BindingFlags.Static)?.PropertyType;

            if (fieldType == null) return false;

            Type elemType = null;
            var isArray = false;
            if (fieldType.IsArray)
            {
                isArray = true;
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

            if (elemType != null)
            {
                IList list;
                if (isArray)
                {
                    list = val as Array;
                }
                else
                {
                    list = val as IList;
                }

                if (list == null) return false;

                if (typeof(Object).IsAssignableFrom(elemType))
                {
                    GenerateFadeGroup(fadeGroup,name, () =>
                    {
                        list = GenerateList(list, elemType);
                        for (int index = 0; index < list.Count; index++)
                        {
                            list[index] = EditorGUILayout.ObjectField($"Element {index}", list[index] as Object,
                                elemType, true);
                        }
                    });
                }

                if (elemType is ILRuntimeType)
                {
                    GenerateFadeGroup(fadeGroup,name, () =>
                    {
                        list = GenerateList(list, elemType);
                        for (int index = 0; index < list.Count; index++)
                        {
                            var index1 = index;
                            var clrInstance = Tools.FindObjectsOfTypeAll<CrossBindingAdaptorType>()
                                .Find(adaptor =>
                                    adaptor.ILInstance.Equals(list[index1])) as MonoBehaviour;

                            if (clrInstance != null)
                            {
                                EditorGUILayout.ObjectField($"Element {index1}", clrInstance, typeof(MonoBehaviour), true);
                            }
                            else
                            {
                                EditorGUILayout.LabelField($"Element {index1}",
                                    list[index] != null ? "暂不支持序列化非通过ClassBind的热更实例" : "(null)");
                            }
                        }
                    });
                    return true;
                }

                if (elemType.IsPrimitive || elemType == typeof(string))
                {
                    GenerateFadeGroup(fadeGroup,name, () =>
                    {
                        list = GenerateList(list, elemType);
                        for (int index = 0; index < list.Count; index++)
                        {
                            if (elemType == typeof(float))
                            {
                                list[index] = EditorGUILayout.FloatField($"Element {index}", (float) list[index]);
                            }
                            else if (elemType == typeof(double))
                            {
                                list[index] = EditorGUILayout.DoubleField($"Element {index}", (double) list[index]);
                            }
                            else if (elemType == typeof(int))
                            {
                                list[index] = EditorGUILayout.IntField($"Element {index}", (int) list[index]);
                            }
                            else if (elemType == typeof(long))
                            {
                                list[index] = EditorGUILayout.LongField($"Element {index}", (long) list[index]);
                            }
                            else if (elemType == typeof(bool))
                            {
                                var result = bool.TryParse(list[index].ToString(), out var value);
                                if (!result)
                                {
                                    value = list[index].ToString() == "1";
                                }

                                list[index] = EditorGUILayout.Toggle($"Element {index}", value);
                            }
                            else if (elemType == typeof(string))
                            {
                                if (list[index] != null)
                                {
                                    list[index] = EditorGUILayout.TextField($"Element {index}", (string) list[index]);
                                }
                                else
                                {
                                    list[index] = EditorGUILayout.TextField($"Element {index}", "");
                                }
                            }
                            else
                            {
                                EditorGUILayout.LabelField($"Element {index}", list[index].ToString());
                            }
                        }
                    });
                }
                
                if (isArray)
                {
                    if (list != null)
                    {
                        int n = list.Count;
                        val = Array.CreateInstance(elemType, n);
                        for (int x = 0; x < n; x++)
                            ((Array) val).SetValue(list[x], x);
                    }
                }
                else
                {
                    if (list != null)
                        val = list;
                }

                return true;
            }

            return false;
        }

        private static void GenerateFadeGroup(AnimBool fadeGroup, string name,Action action)
        {
            fadeGroup.target = EditorGUILayout.Foldout(fadeGroup.target, name, true);
            if (EditorGUILayout.BeginFadeGroup(fadeGroup.faded))
            {
                action?.Invoke();
            }
            EditorGUILayout.EndFadeGroup();
        }
        
        private static IList GenerateList(IList list,Type elemType)
        {
            int newCount = Mathf.Max(0, EditorGUILayout.IntField("Size", list.Count));
            if (elemType is ILRuntimeType)
                EditorGUILayout.HelpBox("热更类型数组不支持在编辑器内进行更改", MessageType.Info);
            while (newCount < list.Count)
                list.RemoveAt(list.Count - 1);
            while (newCount > list.Count)
                list.Add((elemType.IsPrimitive || elemType == typeof(string))
                    ? Activator.CreateInstance(elemType)
                    : null);
            return list;
        }
    }
}