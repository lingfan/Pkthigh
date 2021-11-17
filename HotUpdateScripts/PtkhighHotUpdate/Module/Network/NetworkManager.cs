using JEngine.Core;
using JEngine.Net;
using pbcmd;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HotUpdateScripts.PtkhighHotUpdate.Module.UI.Manager;
using HotUpdateScripts.PtkhighHotUpdate.Module.UI.View;
using Module.Network.PBSocket;
using UnityEngine;
using HotUpdateScripts.PtkhighHotUpdate.Module.Game;
using System.Security.Cryptography;

namespace HotUpdateScripts.PtkhighHotUpdate.Module.Network
{
    public class NetworkManager : MonoBehaviour
    {

        public static NetworkManager Instance;

        public const string salt = @"0PQy5IK1#XcMoCWx";

        public const string modulusHex =
            @"BDDDC884D7C025AC87D2DD67BBAA1B9F835D9E46E6E7E3634E3763406D90B8F8EA9CE5327687D3341E1A337DF43E797F2004494A6A0F6C13F3EEF2FE3B755F1EB19DD44C4C191FEEA5DFDC7210F9ED83DC57965AC1D041D5C67A023199E5D6DCA9213D849630769111E638E85932C9136CC7633D757AB1E72FDF6A0A029F1417";

        public static readonly byte[] modulusBytes = PbcmdHelper.HexToByteArray(modulusHex);
        public static readonly byte[] exponentBytes = new byte[] { 1, 0, 1 };

        public static readonly RSAParameters RSAParams = new RSAParameters()
        {
            Exponent = exponentBytes,
            Modulus = modulusBytes,
        };

        public readonly PBCommParam pBCommParam = PbcmdHelper.getPBCommParam();

        /// <summary>
        /// Test endpoint dev1
        /// </summary>
        public const string URL_ENDPOINT_TEST_TEST1 = @"wss://tt-cf-ws.zjhxfb.com/ws";

        /// <summary>
        /// Test endpoint dev2
        /// </summary>
        public const string URL_ENDPOINT_TEST_DEV2 = @"ws://tt-gamews.weladder.cc/ws";

        /// <summary>
        /// Test endpoint dev3
        /// </summary>
        public const string URL_ENDPOINT_TEST_DEV3 = @"wss://poseidon-ws.teampkt.co/ws";


        Action onOpened;

        private JWebSocket webSocket;

        void Awake()
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

        void Start()
        {
            onOpened += TestLogin;
            InitSocket();
        }

        public void TestLogin()
        {
            //GameManager.Instance.TestLogin();
            GameManager.Instance.TestRegister();
        }

        public void InitSocket()
        {
            JSocketConfig config = new JSocketConfig();
            config.pingInterval = 5.0f;
            config.pingTimeout = 10f;
            config.ackExpirationTime = 10f;
            config.reconnectDelay = 2;
            config.encrypt = 0;
            config.debug = true;

            try
            {
                //OnMessage 

                JWebSocket
                    socket = new JWebSocket(URL_ENDPOINT_TEST_DEV2,
                        config, (obj, eventArgs) =>
                        {
                            PBMainCmd mainCmd = (PBMainCmd)Enum.ToObject(typeof(PBMainCmd), StringifyHelper.GetHeader(eventArgs.RawData).mainCmd);
                        });

                socket.OnConnect((e) => { Log.Print("websocket connected"); });

                socket.OnOpen((e) =>
                {
                    Log.Print("websocket open");
                    Loom.QueueOnMainThread((e) =>
                    {
                        onOpened.Invoke();
                    }, null);

                });

                socket.OnError(e => { Log.PrintError(e); });

                socket.OnClose((e) => { Log.Print("websocket close"); });

                socket.OnDisconnect((e) => { Log.Print("websocket disconnect"); });

                //断线重连事件
                socket.OnReconnect(() => { Log.Print("websocket reconnect"); });

                webSocket = socket;
            }
            catch (Exception e)
            {
                Log.PrintError(e);
                throw;
            }
            webSocket.Connect();
            // socketThread = new Thread(RunSocketThread);
            // socketThread.Start(webSocket);
        }

        public void Send<TRequest, TResponse>(PBMainCmd mainCmd, Enum subCmd, TRequest pbBody,
        Action<PBPacket<TResponse>> action = null,
           Action<PbcmdHelper.PbSocketEvent> onError = null,
    PBMatchIndex idx = default
) where TRequest : class where TResponse : class
        {
            webSocket.Send(mainCmd, subCmd, pbBody, action, onError, idx);
        }

        public void SendAysnc<TRequest, TResponse>(PBMainCmd mainCmd, Enum subCmd, TRequest pbBody,
    Action<bool> onComplete,
    Action<PBPacket<TResponse>> action = null,
           Action<PbcmdHelper.PbSocketEvent> onError = null,
    PBMatchIndex idx = default
) where TRequest : class where TResponse : class
        {
            webSocket.SendAysnc(mainCmd, subCmd, pbBody, onComplete, action, onError, idx);
        }

        public async Task<bool> SendAysncAwait<TRequest, TResponse>(PBMainCmd mainCmd, Enum subCmd, TRequest pbBody,
            Action<PBPacket<TResponse>> action = null,
            Action<PbcmdHelper.PbSocketEvent> onError = null,
            PBMatchIndex idx = default) where TRequest : class where TResponse : class
        {
            var result = await webSocket.SendAysnc(mainCmd, subCmd, pbBody, action, onError,idx);
            return result;
        }



    }
}