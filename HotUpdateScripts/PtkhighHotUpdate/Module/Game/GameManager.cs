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

        public void TestLogin()
        {
            //secret
            var req = new PBReqAccountMobileSecret()
            {
                comm = NetworkManager.Instance.pBCommParam,
                number = "",
            };


            var mainCmdSecret = PBMainCmd.MCmd_Account;
            var subCmdSecret = PBMainCmdAccountSubCmd.Account_ReqMobileSecret;


            NetworkManager.Instance.Send<PBReqAccountMobileSecret, PBRespAccountMobileSecret>(mainCmdSecret, subCmdSecret, req, (respSecret) =>
            {
                Log.Print("收到 secret 回调:" + ReturnCode.codeDesc[respSecret.PBBody.ret.code].chineseSimplified);
                Log.Print("收到 secret 回调:" + respSecret.PBBody.ret.code);
                //auth
                string encryptedPwd = PbcmdHelper.EncryptPassword(PbcmdHelper.PasswordType.Login, "abcd1234", NetworkManager.salt, respSecret.PBBody.secret, NetworkManager.RSAParams);

                PBReqAccountMobileAuth mobileAuth = new PBReqAccountMobileAuth()
                {
                    comm = NetworkManager.Instance.pBCommParam,
                    number = "phone::+86:19988888888",
                    pwd = encryptedPwd,
                    code = "",
                    type = (int)VerifType.PhoneLogin
                };

                var mainCmdAuth = PBMainCmd.MCmd_Account;
                var subCmdAuth = PBMainCmdAccountSubCmd.Account_ReqMobileAuth;

                NetworkManager.Instance.Send<PBReqAccountMobileAuth, PBRespAccountMobileAuth>(mainCmdAuth, subCmdAuth, mobileAuth, (respAuth) =>
                {
                    Log.Print("收到 auth 回调:" + ReturnCode.codeDesc[respAuth.PBBody.ret.code].chineseSimplified);
                    Log.Print("收到 auth 回调:" + respAuth.PBBody.ret.code);

                    //login
                    var mainCmdLogin = PBMainCmd.MCmd_Account;
                    var subCmdLogin = PBMainCmdAccountSubCmd.Account_ReqLogin;
                    var mobileLogin = new PBReqAccountLogin()
                    {
                        comm = NetworkManager.Instance.pBCommParam,
                    };

                    NetworkManager.Instance.Send<PBReqAccountLogin, PBRespAccountLogin>(mainCmdLogin, subCmdLogin, mobileLogin, (respLogin) =>
                    {
                        Log.Print("收到 login 回调:" + ReturnCode.codeDesc[respLogin.PBBody.ret.code].chineseSimplified);
                        Log.Print("收到 login 回调:" + respLogin.PBBody.ret.code);


                        //if (respLogin.PBBody.ret.code != 1)
                        //{
                        //    TestLogin();
                        //}
                    });
                });

            });

        }


        public void TestRegister()
        {
            var mainCmd = PBMainCmd.MCmd_Account;
            var subCmd = PBMainCmdAccountSubCmd.Account_ReqMobileCode;

            //+86:19912121212::register

            PBReqAccountMobileCode req = new PBReqAccountMobileCode()
            {
                comm = NetworkManager.Instance.pBCommParam,
                number = "phone::+86:19912121211::register"
            };

            NetworkManager.Instance.SendAysnc<PBReqAccountMobileCode, PBRespAccountMobileCode>(mainCmd, subCmd, req, (isDone) =>
            {
                Log.Print("register 是否发送完成:" + isDone);

            }, (resp) =>
            {
                Log.Print("收到 register 回调:" + ReturnCode.codeDesc[resp.PBBody.ret.code].chineseSimplified);
                Log.Print("收到 register 回调:" + resp.PBBody.ret.code);

            });
        }
    }


    public enum GameStatus
    {
        Start,
    }
}