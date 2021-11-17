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

namespace HotUpdateScripts.PtkhighHotUpdate.Module.UI.View
{
    public class RegisterPage : UIBase
    {

        public Button backButton;
        public Button registerButton;

        public override void Awake()
        {
            base.Awake();
        }

        public override void Start()
        {
            base.Start();
            backButton.onClick.AddListener(() =>
            {
                UIManager.instance.Show(nameof(LoginPage));
            });

            registerButton.onClick.AddListener(TestRegister);
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
}
