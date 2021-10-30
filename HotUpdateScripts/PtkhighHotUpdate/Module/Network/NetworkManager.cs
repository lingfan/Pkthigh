using JEngine.Core;
using JEngine.Net;
using pbcmd;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotUpdateScripts.PtkhighHotUpdate.Module.Network
{
    public class NetworkManager
    {

        public const string salt = @"0PQy5IK1#XcMoCWx";

        public const string modulusHex = @"BDDDC884D7C025AC87D2DD67BBAA1B9F835D9E46E6E7E3634E3763406D90B8F8EA9CE5327687D3341E1A337DF43E797F2004494A6A0F6C13F3EEF2FE3B755F1EB19DD44C4C191FEEA5DFDC7210F9ED83DC57965AC1D041D5C67A023199E5D6DCA9213D849630769111E638E85932C9136CC7633D757AB1E72FDF6A0A029F1417";
        public static readonly byte[] modulusBytes = HexToByteArray(modulusHex);
        public static readonly byte[] exponentBytes = new byte[] { 1, 0, 1 };

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




        public static void InitSocket()
        {
            JSocketConfig config = new JSocketConfig();
            config.pingInterval = 5.0f;
            config.pingTimeout = 10f;
            config.reconnectDelay = 2;
            config.debug = true;

            JWebSocket socket = new JWebSocket(URL_ENDPOINT_TEST_DEV2, config, (sender, eventArgs) =>
            {
                Log.Print("收到服务端消息");
                Log.Print(eventArgs);
                
            }); //使用默认配置连接非基于socket-io（非nodeJS）实现的服务端，需要自己实现接收方法

            socket.OnConnect((e) =>
            {
                Log.Print("服务端连接成功");
            });

            socket.OnError(e =>
            {
                Log.PrintError(e);
            });

            socket.OnDisconnect((e) =>
            {
                Log.Print("服务端连接关闭");
            });

            //此方法不阻塞
            socket.Connect();

            //断线重连事件
            socket.OnReconnect(() =>
            {
                Log.Print("断开连接后重连成功");
            });
        }



        public static IEnumerator HeartBeatEnumerator()
        {
            DateTime last = DateTime.Now;

            while (true)
            {
                yield return new WaitForSeconds(TIMER_HEARTBEAT);
                var request = new PBHearBeat();
                request.Timestamp = (ulong)DateTime.UtcNow.Ticks;
                yield return EnumeratorSend<PBHearBeat, PBHearBeat>(
                    PBMainCmd.MCmd_HeartBeat, PBMainCmdHeartBeatSubCmd.HB_Send,
                    request, null, 0,
                    null,
                    (resp) =>
                    {
                        last = DateTime.UtcNow;
                        Debug.Log("HeartBeat");
                        Debug.Log(resp);
                        //spanHeartBeat = DateTime.UtcNow - new DateTime((long)request.Timestamp);
                        //if (spanHeartBeat.TotalSeconds > TIMEOUT_HEARTBEAT)
                        //{
                        //    OnHeartBeatTimeout?.Invoke(null, request);
                        //}
                    },
                    (clienCtx) =>
                    {
                        //heartbeat timeout. should reconnect.
                        //OnHeartBeatTimeout?.Invoke(null, request);
                    });
                spanHeartBeat = DateTime.UtcNow - last;
                if (spanHeartBeat.TotalSeconds > TIMEOUT_HEARTBEAT)
                {
                    OnHeartBeatTimeout?.Invoke(null, request);
                }
                if (spanHeartBeat.TotalSeconds > TIMEOUT_HEARTBEAT_MAX_TOLERANT)
                {
                    OnHeartBeatTimeoutMaxTolerant?.Invoke(null, request);
                }
            }

        }


        public static byte[] HexToByteArray(string hex)
        {
            if (hex.Length % 2 == 1)
            {
                hex = '0' + hex;
            }
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }


    }
}
