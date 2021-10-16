using HotUpdateScripts.PtkhighHotUpdate.Module.EventData;
using HotUpdateScripts.PtkhighHotUpdate.Module.UI.Base;
using HotUpdateScripts.PtkhighHotUpdate.Module.UI.View;
using JEngine.Core;
using JEngine.Event;
using JEngine.UI;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using static UIConfig;
using Object = UnityEngine.Object;

namespace HotUpdateScripts.PtkhighHotUpdate.Module.UI.Manager
{
    public class UIManager : MonoBehaviour
    {
        [HideInInspector] public static UIManager instance;

        [SerializeField] private RectTransform layerHidden;
        [SerializeField] private RectTransform layerBottom;
        [SerializeField] private RectTransform layerMedium;
        [SerializeField] private RectTransform layerTop;
        [SerializeField] private RectTransform layerTopMost;


        [SerializeField] private List<GameObject> localUIPrefabs = new List<GameObject>();



        /// <summary>
        /// 全局遮罩
        /// </summary>
        [SerializeField] private readonly GameObject Mask;

        /// <summary>
        /// 所有已加载的页面
        /// </summary>
        private Dictionary<string, UIBase> UIMaps = new Dictionary<string, UIBase>();

        /// <summary>
        /// 已打开页面栈,使用栈方便做退回功能
        /// </summary>
        private Stack<UIBase> UIStack = new Stack<UIBase>();



        /// <summary>
        /// 当前打开的页面
        /// </summary>
        private UIBase currentUI;


        void Awake()
        {
            instance = this;
            Object.DontDestroyOnLoad(this);
            InitLocal();
        }


        public void InitLocal()
        {
            for (int i = 0; i < localUIPrefabs.Count; i++)
            {
                UIBase ui = GameObject.Instantiate(localUIPrefabs[i]).GetComponent<UIBase>();
                Register(ui);
            }
            //UIBase ui = GameObject.Instantiate(Resources.Load<GameObject>("PopupTemplate")).GetComponent<UIBase>();
            //Register(ui);
        }

        //目前批量预加载的进度无法获取，可考虑用C# Task进行重写，可等待加载全部完成后再继续，看是否有必要？
        public void PreLoad(List<string> list, Action<GameObject> action = null)
        {
            //或使用消息机制？加载完成后发送通知消息？
            for (int i = 0; i < list.Count; i++)
            {
                LoadAsync(list[i], action);
            }
        }

        /// <summary>
        /// 异步加载资源
        /// </summary>
        /// <param name="uiName"></param>
        /// <param name="action"></param>
        public void LoadAsync(string uiName, Action<GameObject> action = null)
        {
            JResource.LoadResAsync<GameObject>(uiName, (prefab) =>
            {
                Register(prefab.GetComponent<UIBase>());
                action?.Invoke(prefab);
            });
        }

        public GameObject LoadLocal(string uiName)
        {
            if (UIMaps.ContainsKey(uiName))
            {
                throw new Exception($"UI重复加载警告: uiName={uiName}");
            }

            return Resources.Load<GameObject>(uiName);
        }

        /// <summary>
        /// 挂载一个UI
        /// </summary>
        /// <param name="ui"></param>
        private void Register(UIBase ui, Action<UIBase> openCall = null, Action<UIBase> closeCall = null)
        {
            RectTransform parent = layerHidden;

            Log.Print("Register ui in UIManager " + ui.name);
            //初始化
            ui.gameObject.layer = LayerMask.NameToLayer("UI");
            ui.transform.SetParent(parent, false);
            UIMaps.Add(ui.GetType().Name, ui);
            ui.gameObject.SetActive(true);
            ui.Init();

            switch (ui.config.uiLayer)
            {
                case Layer.Hidden:
                    parent = layerHidden;
                    break;
                case Layer.Bottom:
                    parent = layerBottom;
                    break;
                case Layer.Medium:
                    parent = layerMedium;
                    break;
                case Layer.Top:
                    parent = layerTop;
                    break;
                case Layer.TopMost:
                    parent = layerTopMost;
                    break;
                default:
                    throw new Exception($"UI类型设置错误: uiName={ui.GetType().Name}");
            }
            // 初始化完成后设置层级
            ui.transform.SetParent(parent, false);
            ui.gameObject.SetActive(false);
            ui.InitUICallBack(openCall, closeCall);
        }



        public void Show(string uibaseName, bool isSaveShow = false, bool isClearAll = true)
        {

            if (!UIMaps.TryGetValue(uibaseName, out UIBase ui))
            {
                Log.PrintWarning($"已加载UI列表中不存在, 无法打开: uiName={uibaseName}");
                return;
            }
            else
            {
                switch (ui.config.uiType)
                {
                    //所打开的第一个页面永远是page
                    case UIType.Page:
                        Open(ui);
                        UIStack.Clear();
                        UIStack.Push(ui);
                        break;
                    case UIType.Panel:
                        UIStack.Push(ui);
                        Open(ui);
                        break;
                    case UIType.Window:
                        OpenWindow(ui);
                        break;
                }
            }
        }

        /// <summary>
        /// 返回
        /// </summary>
        public void GoBack()
        {
            //根据UIStack的顺序决定返回哪个页面
            if (UIStack.Count != 0)
            {
                UIBase ui = UIStack.Peek();
                Open(ui);
                UIStack.Pop();
            }

        }

        private void OpenWindow(UIBase uiWindow)
        {
            if (uiWindow.IsOpen) return;
            uiWindow.ShowUI();
            uiWindow.transform.SetAsLastSibling();
        }

        private void Open(UIBase ui)
        {
            if (ui.IsOpen) return;
            CloseAll();
            ui.ShowUI();
            currentUI = ui;
        }

        private void CloseAll()
        {
            foreach (var item in UIMaps.Values)
            {
                if (item.IsOpen)
                    Close(item.GetType().Name);
            }
        }


        public void Close(string uiName, bool isDestroy = false, object args = null)
        {
            if (UIMaps.TryGetValue(uiName, out var ui))
            {
                if (ui.IsOpen)
                {
                    ui.CloseUI();
                }

                if (isDestroy)
                {
                    UIMaps.Remove(uiName);
                    ui.Destroy();
                    if (!ui.config.isHotUpdateResources)
                    {
                        Resources.UnloadAsset(ui);
                    }
                    else
                    {
                        JResource.UnloadRes(ui.config.loadPath);
                    }

                }
            }
        }


        /// <summary>
        /// 获取对应UI
        /// </summary>
        /// <param name="uibaseName"></param>
        /// <returns></returns>
        public UIBase GetUI(string uibaseName)
        {
            UIMaps.TryGetValue(uibaseName, out var t);
            return t;
        }

        /// <summary>
        /// 是否存在某个UI
        /// </summary>
        /// <param name="uibaseName"></param>
        /// <returns></returns>
        public bool HasUI(string uibaseName)
        {
            return GetUI(uibaseName) != null;
        }

        public void TestReceive(TabData data)
        {
            Log.PrintWarning("has receive " + data);
        }
    }

}
