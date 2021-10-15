using HotUpdateScripts.PtkhighHotUpdate.Module.EventData;
using HotUpdateScripts.PtkhighHotUpdate.Module.UI.Base;
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

        public void TestReceive(TabData data)
        {
            tabText.text = data.text;
        }

    }
}
