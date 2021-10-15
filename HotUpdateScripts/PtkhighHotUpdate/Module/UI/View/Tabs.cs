using HotUpdateScripts.PtkhighHotUpdate.Module.EventData;
using HotUpdateScripts.PtkhighHotUpdate.Module.UI.Base;
using JEngine.Core;
using JEngine.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;

namespace HotUpdateScripts.PtkhighHotUpdate.Module.UI.View
{

    public class Tabs : UIBase
    {
        public Text tabText;

        public Button button;

        public override void Awake()
        {
            base.Awake();
            EventManager.AddEvent<TabData>(nameof(Tabs), TestEvent);
        }

        public override void Start()
        {
            base.Start();
            button.onClick.AddListener(ChangeLanguage);
        }

        public async void TestEvent(TabData data)
        {
            tabText.text = data.text;
            await Task.Delay(2000);
            tabText.text = Localization.GetString("DemoText");

        }

        public async void ChangeLanguage()
        {
            await Task.Delay(1000);
            Localization.ChangeLanguage("en-us");
            tabText.text = Localization.GetString("DemoText");
        }

    }
}
