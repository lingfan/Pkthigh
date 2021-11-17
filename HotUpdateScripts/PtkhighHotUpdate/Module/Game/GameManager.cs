using HotUpdateScripts.PtkhighHotUpdate.Module.EventData;
using HotUpdateScripts.PtkhighHotUpdate.Module.Network;
using HotUpdateScripts.PtkhighHotUpdate.Module.Setting;
using HotUpdateScripts.PtkhighHotUpdate.Module.UI.Base;
using HotUpdateScripts.PtkhighHotUpdate.Module.UI.Manager;
using HotUpdateScripts.PtkhighHotUpdate.Module.UI.View;
using JEngine.Core;
using JEngine.Event;
using pbcmd;
using System.Collections.Generic;
using UnityEngine;
using static PbcmdHelper;

namespace HotUpdateScripts.PtkhighHotUpdate.Module.Game
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        [HideInInspector] public Dictionary<string, JEvent> registedEvents = new Dictionary<string, JEvent>();


        void Awake()
        {
            Instance = this;
            UnityEngine.Object.DontDestroyOnLoad(this);
        }

        void Start()
        {
            //JAction jAction = new JAction();
            //jAction.Delay(1).Do(() =>
            //{
            //    UIManager.instance.Show(nameof(Tabs));
            //}).Delay(2).Do(() =>
            //{
            //    UIManager.instance.Show(nameof(PopupTemplate));
            //}).Delay(2).Do(() =>
            //{
            //    UIManager.instance.Close(nameof(PopupTemplate));
            //}).Delay(2).Do(() =>
            //{
            //    UIManager.instance.Show(nameof(DirectoryTreeView));
            //}).Delay(2).Do(() =>
            //{
            //    UIManager.instance.Show(nameof(Tabs));
            //    TestEvent();
            //}).Execute(true);
            Loom.Initialize();
            EventManager.AddEvent(EventManager.socketOpen, OnSocketOpened);
        }

        public void OnSocketOpened()
        {
            JAction action = new JAction();
            action.Delay(0.5f).Do(() =>
            {
                UIManager.instance.Show(nameof(LoginPage));
            }).Execute(true);
        }


        public void ChangeLanguage()
        {
            string languageSet = JSaver.GetString(SettingConstData.languageSet);

            Debug.Log(languageSet == null);

            Localization.ChangeLanguage("en-us");
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
        Start,
    }
}