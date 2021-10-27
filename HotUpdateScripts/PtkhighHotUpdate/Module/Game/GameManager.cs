using HotUpdateScripts.PtkhighHotUpdate.Module.EventData;
using HotUpdateScripts.PtkhighHotUpdate.Module.Network;
using HotUpdateScripts.PtkhighHotUpdate.Module.UI.Base;
using HotUpdateScripts.PtkhighHotUpdate.Module.UI.Manager;
using HotUpdateScripts.PtkhighHotUpdate.Module.UI.View;
using JEngine.Core;
using JEngine.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HotUpdateScripts.PtkhighHotUpdate.Module.Game
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        [HideInInspector] public Dictionary<string, JEvent> registedEvents = new Dictionary<string, JEvent>();


        void Awake()
        {

            instance = this;
            UnityEngine.Object.DontDestroyOnLoad(this);
        }

        void Start()
        {
            JAction jAction = new JAction();
            jAction.Delay(1).Do(() =>
            {
                UIManager.instance.Show(nameof(Tabs));
            }).Delay(2).Do(() =>
            {
                UIManager.instance.Show(nameof(PopupTemplate));
            }).Delay(2).Do(() =>
            {
                UIManager.instance.Close(nameof(PopupTemplate));
            }).Delay(2).Do(() =>
            {
                UIManager.instance.Show(nameof(DirectoryTreeView));
            }).Delay(2).Do(() =>
            {
                UIManager.instance.Show(nameof(Tabs));
                TestEvent();
            }).Execute(true);

            NetworkManager.InitSocket();
        }

        void TestEvent()
        {
            TabData data = new TabData
            {
                text = "test",
            };
            EventManager.DispatchEvent<TabData>(nameof(Tabs), data);
        }

    }


    public enum GameStatus
    {

    }
}
