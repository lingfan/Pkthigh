using HotUpdateScripts.PtkhighHotUpdate.Module.UI.Manager;
using JEngine.Core;
using JEngine.Event;
using JEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UIConfig;

namespace HotUpdateScripts.PtkhighHotUpdate.Module.UI.Base
{
    public class UIBase : MonoBehaviour
    {
        [HideInInspector] public UIConfig config;

        public bool IsOpen => gameObject.activeSelf;

        public Action<UIBase> openCall { get; private set; }

        public Action<UIBase> closeCall { get; private set; }


        public virtual void Awake()
        {
            Log.Print("UIBase Awake");
        }

        public virtual void Start()
        {
            Log.Print("UIBase Start");
        }



        /// <summary>
        /// JUI绑定
        /// </summary>
        public List<JUI> JUIBinds;

        public virtual void Init()
        {
            config = this.GetComponent<UIConfig>();

            if (config == null)
            {
                Log.PrintError(gameObject.name + " UIConfig未挂载");
            }
            JUIBinds = new List<JUI>();

        }


        public void InitUICallBack(Action<UIBase> actionOpen = null, Action<UIBase> actionClose = null)
        {
            openCall = actionOpen;
            closeCall = actionClose;
        }

        public virtual void ShowUI()
        {
            gameObject.SetActive(true);
            openCall?.Invoke(this);
        }

        public virtual void CloseUI()
        {
            gameObject.SetActive(false);
            closeCall?.Invoke(this);
        }

        public virtual void AddDataBind<T>(BindableProperty<T> args, Action<T> onDataChange)
        {
            JUI jui = JUI.CreateOn(gameObject);//添加脚本 | Add JUI
            jui.Bind(args)//绑定数据 | Bind Data
                .onMessage<T>((j, value) =>
                {
                    onDataChange?.Invoke(value);
                })
                .Activate();//激活 | Run JUI
            JUIBinds.Add(jui);
        }

        public virtual void Refresh()
        {
            for (int i = 0; i < JUIBinds.Count; i++)
            {
                JUIBinds[i].End();
            }
        }
        private void OnEnable()
        {

        }

        public virtual void Destroy()
        {
            for (int i = 0; i < JUIBinds.Count; i++)
            {
                JUIBinds[i].End();
            }
        }

        private void OnDestroy()
        {
            Destroy();
        }
    }
}
