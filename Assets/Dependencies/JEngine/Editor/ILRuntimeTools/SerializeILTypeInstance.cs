using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using ILRuntime.Runtime.Intepreter;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

namespace JEngine.Editor
{
    public static partial class SerializeILTypeInstance
    {
        public static int FadeGroupNum = 15;

        private static Dictionary<int, MethodInfo> _serializeMethods;

        public static Dictionary<int, MethodInfo> GetSerializeMethods()
        {
            //序列化成员变量
            if (_serializeMethods == null)
            {
                _serializeMethods = new Dictionary<int, MethodInfo>(0);
                var allMethods = typeof(SerializeILTypeInstance).GetMethods(BindingFlags.Public | BindingFlags.Static);
                foreach (var method in allMethods)
                {
                    var attr = method.GetCustomAttributes(typeof(SerializeTypeMethod), false);
                    if (attr.Length > 0)
                    {
                        _serializeMethods.Add(((SerializeTypeMethod) attr[0]).Priority, method);
                    }
                }

                _serializeMethods = _serializeMethods.OrderByDescending(s => s.Key)
                    .ToDictionary(s => s.Key, m => m.Value);

            }

            return _serializeMethods;
        }

        public static async Task OnEnable(List<AnimBool> fadeGroup, UnityAction repaint)
        {
            for (int i = 0; i < fadeGroup.Count; i++)
            {
                fadeGroup[i] = new AnimBool(false);
                fadeGroup[i].valueChanged.AddListener(repaint);
            }

            while (Application.isEditor && Application.isPlaying)
            {
                try
                {
                    repaint();
                }
                catch
                {
                    //ignored
                }

                await Task.Delay(500);
            }
        }

        public static void OnDisable(List<AnimBool> fadeGroup, UnityAction repaint)
        {
            // 移除动画监听
            foreach (var t in fadeGroup)
            {
                t.valueChanged.RemoveListener(repaint);
            }
        }

        public static void OnDestroy(ref bool displaying)
        {
            if (displaying)
                displaying = false;
        }

        public static bool NeedToHide(ILTypeInstance instance, string objName)
        {
            MemberInfo info = instance.Type.ReflectionType.GetField(objName);
            if (info == null)
            {
                info = instance.Type.ReflectionType.GetProperty(objName);
            }

            if (info != null)
            {
                var attr = info.GetCustomAttributes(typeof(HideInInspector), false);
                if (attr.Length > 0)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool SerializeJBehaviourType(AnimBool fadeGroup,
            ILTypeInstance instance)
        {
            //如果JBehaviour
            var jBehaviourType = InitJEngine.Appdomain.LoadedTypes["JEngine.Core.JBehaviour"];
            var t = instance.Type.ReflectionType;
            if (t.IsSubclassOf(jBehaviourType.ReflectionType))
            {
                var f = t.GetField("_instanceID", BindingFlags.NonPublic);
                if (!(f is null))
                {
                    GUI.enabled = false;
                    var id = f.GetValue(instance).ToString();
                    EditorGUILayout.TextField("InstanceID", id);
                    GUI.enabled = true;
                }

                string frameModeStr = "FrameMode";
                string frequencyStr = "Frequency";
                string pausedStr = "Paused";
                string totalTimeStr = "TotalTime";
                string loopDeltaTimeStr = "LoopDeltaTime";
                string loopCountsStr = "LoopCounts";
                string timeScaleStr = "TimeScale";

                fadeGroup.target = EditorGUILayout.Foldout(fadeGroup.target,
                    "JBehaviour Stats", true);
                if (EditorGUILayout.BeginFadeGroup(fadeGroup.faded))
                {
                    var fm = t.GetField(frameModeStr, BindingFlags.Public);
                    bool frameMode = !(fm is null) &&
                                     EditorGUILayout.Toggle(frameModeStr, (bool) fm.GetValue(instance));
                    fm?.SetValue(instance, frameMode);

                    var fq = t.GetField(frequencyStr, BindingFlags.Public);
                    if (!(fq is null))
                    {
                        int frequency = EditorGUILayout.IntField(frequencyStr, (int) fq.GetValue(instance));
                        fq.SetValue(instance, frequency);
                    }

                    GUI.enabled = false;

                    var paused = t.GetField(pausedStr, BindingFlags.NonPublic);
                    if (!(paused is null)) EditorGUILayout.Toggle(pausedStr, (bool) paused.GetValue(instance));

                    var totalTime = t.GetField(totalTimeStr, BindingFlags.Public);
                    if (!(totalTime is null))
                        EditorGUILayout.FloatField(totalTimeStr, (float) totalTime.GetValue(instance));

                    var loopDeltaTime = t.GetField(loopDeltaTimeStr, BindingFlags.Public);
                    if (!(loopDeltaTime is null))
                        EditorGUILayout.FloatField(loopDeltaTimeStr, (float) loopDeltaTime.GetValue(instance));

                    var loopCounts = t.GetField(loopCountsStr, BindingFlags.Public);
                    if (!(loopCounts is null))
                        EditorGUILayout.LongField(loopCountsStr, (long) loopCounts.GetValue(instance));

                    GUI.enabled = true;

                    var timeScale = t.GetField(timeScaleStr, BindingFlags.Public);
                    if (!(timeScale is null))
                    {
                        var ts = EditorGUILayout.FloatField(timeScaleStr, (float) timeScale.GetValue(instance));
                        timeScale.SetValue(instance, ts);
                    }
                }

                EditorGUILayout.EndFadeGroup();

                if (instance.Type.FieldMapping.Count > 0)
                {
                    EditorGUILayout.Space(10);
                    EditorGUILayout.HelpBox(String.Format(Setting.GetString(SettingString.MemberVariables), t.Name),
                        MessageType.Info);
                }

                return true;
            }

            return false;
        }
    }
}