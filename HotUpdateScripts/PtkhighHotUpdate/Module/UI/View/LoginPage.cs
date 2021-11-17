using HotUpdateScripts.PtkhighHotUpdate.Module.Network;
using HotUpdateScripts.PtkhighHotUpdate.Module.UI.Base;
using HotUpdateScripts.PtkhighHotUpdate.Module.UI.Manager;
using JEngine.Core;
using pbcmd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;
using static PbcmdHelper;

namespace HotUpdateScripts.PtkhighHotUpdate.Module.UI.View
{
    public class LoginPage : UIBase
    {
        public Button goRegisterButton;

        public Button loginButton;

        public override void Awake()
        {
            base.Awake();
        }
        public override void Start()
        {
            base.Start();

            goRegisterButton.onClick.AddListener(() =>
            {
                UIManager.instance.Show(nameof(RegisterPage));
            });

            loginButton.onClick.AddListener(TestLogin);
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
                    });
                });

            });
        }
    }
}
