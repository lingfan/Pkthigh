/*
 * JEngine自动生成的编辑器脚本，作者已经代替你掉了头发，帮你写出了这个编辑器脚本，让你能够直接看对象序列化后的字段
 */

using UnityEditor;
using UnityEngine;
using JEngine.Editor;
using ProjectAdapter;
using UnityEditor.AnimatedValues;
using System.Collections.Generic;

[CustomEditor(typeof(ExampleAPIAdapter.Adapter), true)]
public class ExampleAPIAdapterEditor : Editor
{
        private bool _displaying;
    private List<AnimBool> _fadeGroup = new List<AnimBool>()
    {
        new AnimBool(false)
    };

    private async void OnEnable()
    {
        _displaying = true;
        await SerializeILTypeInstance.OnEnable(_fadeGroup, () =>
        {
            if (_displaying)
            {
                Repaint();
            }
        });
    }

    private void OnDestroy()
    {
        SerializeILTypeInstance.OnDestroy(ref _displaying);
    }

    private void OnDisable()
    {
        SerializeILTypeInstance.OnDisable(_fadeGroup,Repaint);
    }
    
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        ProjectAdapter.ExampleAPIAdapter.Adapter clr = target as ProjectAdapter.ExampleAPIAdapter.Adapter;
        if (clr is null) return;
    
        var instance = clr.ILInstance;
        if (instance != null)
        {
            EditorGUILayout.LabelField("Script", clr.ILInstance.Type.Name);
            _fadeGroup[0].valueChanged.AddListener(Repaint);
    
            if (_fadeGroup.Count <= instance.Type.FieldMapping.Count)
            {
                for (int i = 1; i <= instance.Type.FieldMapping.Count + 1; i++)
                {
                    _fadeGroup.Add(new AnimBool(false));
                    _fadeGroup[i].valueChanged.AddListener(Repaint);
                }
            }    
            int index = 0;

            foreach (var i in instance.Type.FieldMapping)
            {
                //这里是取的所有字段，没有处理不是public的
                var type = instance.Type.FieldTypes[index];
                var cType = type.TypeForCLR;
                var objName = i.Key;
                var objVal = instance[i.Value];
                GUI.enabled = true;
                index++;

                if (SerializeILTypeInstance.NeedToHide(instance, objName)) continue;

                foreach (var method in SerializeILTypeInstance.GetSerializeMethods())
                {
                    System.Object[] parameters = {_fadeGroup[index], cType, type, instance, objName, objVal};
                    var result = method.Value.Invoke(null, parameters);
                    if ((bool) result)
                    {
                        break;
                    }
    
                    if (method.Key == 0)
                    {
                        EditorGUILayout.LabelField(objName, "(null)");
                    }
                }
            }
        }
        // 应用属性修改
        serializedObject.ApplyModifiedProperties();
    }
}
