using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIConfig : MonoBehaviour
{
    [Header("默认UI层级")] [SerializeField] public Layer uiLayer = Layer.Bottom;

    [Space(10)] [Header("UI类型")] [SerializeField]
    public UIType uiType = UIType.Page;

    [Space(10)] [Header("加载路径")] [SerializeField]
    public string loadPath;

    [HideInInspector]public bool isHotUpdateResources;

    private void Awake()
    {
        if (loadPath != null && loadPath != "")
        {
            if (loadPath.IndexOf("Assets/HotUpdateResources/") != -1)
            {
                isHotUpdateResources = true;
            }
        }
    }


    /// <summary>
    /// UI type
    /// </summary>
    [Serializable]
    public enum UIType
    {
        Page,
        Window,
        Panel,
    }

    /// <summary>
    /// UI Layer
    /// </summary>
    [Serializable]
    public enum Layer
    {
        Hidden,
        Bottom,
        Medium,
        Top,
        TopMost
    }
}