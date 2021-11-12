//
// SocketIOComponent.cs
//
// Author:
//       JasonXuDeveloper（傑） <jasonxudeveloper@gmail.com>
//
// Copyright (c) 2020 JEngine
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

#define SOCKET_IO_DEBUG // Uncomment this for debug
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using JEngine.Core;
using Module.Network.PBSocket;
using pbcmd;
using UnityEditor.VersionControl;
using UnityEngine;
using WebSocketSharp;
using Object = System.Object;
using Task = System.Threading.Tasks.Task;

namespace JEngine.Net
{
    public class JSocketConfig
    {
        public bool debug = false;
        public bool autoConnect = false;
        public int reconnectDelay = 5;
        public float ackExpirationTime = 30f;
        public float pingInterval = 5f;
        public float pingTimeout = 10f;
        public uint encrypt = 0;
        public string eventOpenName = "open";
        public string eventConnectName = "connect";
        public string eventDisconnectName = "disconnect";
        public string eventErrorName = "error";
        public string eventCloseName = "close";

        public static JSocketConfig Default()
        {
            return new JSocketConfig();
        }
    }

    public class SocketIOComponent : MonoBehaviour
    {
        #region Public Properties

        public string url; //ws://127.0.0.1:4567/socket.io/?EIO=3&transport=websocket
        public JSocketConfig config;
        public EventHandler<MessageEventArgs> OnMessage;

        public WebSocket socket
        {
            get { return ws; }
        }

        public string sid { get; set; }

        public bool IsConnected
        {
            get { return connected; }
        }

        /// <summary>
        /// heart beat flag
        /// </summary>
        public bool ThPinging
        {
            get => thPinging;
            set => thPinging = value;
        }

        #endregion

        #region Private Properties

        private volatile bool connected;
        private volatile bool thPinging;

        private volatile bool wsConnected;

        private Thread socketThread;
        private Thread pingThread;
        private WebSocket ws;

        private Encoder encoder;
        public Decoder decoder;
        private Parser parser;

        private Dictionary<string, List<Action<SocketIOEvent>>> handlers;
        private List<Ack> ackList;

        private int packetId;
        private const int HeartBeatPacketId = 0;

        private object eventQueueLock;
        private Queue<SocketIOEvent> eventQueue;

        private object ackQueueLock;
        private Queue<AckMessage> ackQueue;

        #endregion

#if SOCKET_IO_DEBUG
        public Action<string> debugMethod;
#endif

        #region Unity interface

        public void Init(string url, JSocketConfig config = null, Action<object, MessageEventArgs> onMessage = null)
        {
            if (config == null)
            {
                config = JSocketConfig.Default();
            }

            if (onMessage == null)
            {
                OnMessage = _OnMessage;
            }
            else
            {
                OnMessage = (sender, e) => onMessage(sender, e);
            }

            this.url = url;
            this.config = config;

            // encoder = new Encoder();
            // decoder = new Decoder();
            // parser = new Parser();

            handlers = new Dictionary<string, List<Action<SocketIOEvent>>>();
            ackList = new List<Ack>();
            sid = null;
            packetId = 0;

            eventQueueLock = new object();
            eventQueue = new Queue<SocketIOEvent>();

            ackQueueLock = new object();
            ackQueue = new Queue<AckMessage>();

            connected = false;

#if SOCKET_IO_DEBUG
            if (debugMethod == null)
            {
                debugMethod = delegate(string s)
                {
                    if (config.debug)
                    {
                        Log.Print(s);
                    }
                };
            }
#endif

            if (config.autoConnect)
            {
                Connect();
            }
        }

        public void Update()
        {
            lock (eventQueueLock)
            {
                while (eventQueue.Count > 0)
                {
                    EmitEvent(eventQueue.Dequeue());
                }
            }

            lock (ackQueueLock)
            {
                while (ackQueue.Count > 0)
                {
                    InvokeAck(ackQueue.Dequeue());
                }
            }

            if (wsConnected != ws.IsConnected)
            {
                wsConnected = ws.IsConnected;
                if (wsConnected)
                {
                    EmitEvent(config.eventConnectName);
                }
                else
                {
                    EmitEvent(config.eventDisconnectName);
                }
            }

            // GC expired acks
            if (ackList.Count == 0)
            {
                return;
            }
            
            if (DateTime.Now.Subtract(ackList[0].time).TotalSeconds < config.ackExpirationTime)
            {
                return;
            }

            ackList.RemoveAt(0);
        }

        public void OnDestroy()
        {
            if (socketThread != null)
            {
                socketThread.Abort();
            }

            if (pingThread != null)
            {
                pingThread.Abort();
            }
        }

        public void OnApplicationQuit()
        {
            Close();
        }

        #endregion

        #region Public Interface

        public void SetHeader(string header, string value)
        {
            ws.SetHeader(header, value);
        }

        public void Connect()
        {
            ws = new WebSocket(url);
            ws.OnOpen += OnOpen;
            ws.OnError += OnError;
            ws.OnClose += OnClose;
            ws.OnMessage += OnMessage;

            wsConnected = false;

            connected = true;

            socketThread = new Thread(RunSocketThread);
            socketThread.Start(ws);

            pingThread = new Thread(RunPingThread);
            pingThread.Start(ws);
        }

        private void _OnMessage(object sender, MessageEventArgs e)
        {
            try
            {
                PBHeader pbHeader = StringifyHelper.GetHeader(e.RawData);
                PBMainCmd mainCmd = (PBMainCmd) Enum.ToObject(typeof(PBMainCmd), pbHeader.mainCmd);
#if SOCKET_IO_DEBUG
                Log.Print("[SocketIO]:clientCtx:=" + pbHeader.clientCtx + "|cmd:= " + mainCmd);
#endif

                switch (mainCmd)
                {
                    case PBMainCmd.MCmd_HeartBeat:

                        break;
                    default:
                        HandleMessage(e, pbHeader);
                        break;
                }
            }
            catch (Exception exception)
            {
                Log.PrintError(exception);
                throw;
            }
        }

        public void Close()
        {
            connected = false;
        }

        public void On(string ev, Action<SocketIOEvent> callback)
        {
            if (!handlers.ContainsKey(ev))
            {
                handlers[ev] = new List<Action<SocketIOEvent>>();
            }

            handlers[ev].Add(callback);
        }

        public void Off(string ev, Action<SocketIOEvent> callback)
        {
            if (!handlers.ContainsKey(ev))
            {
#if SOCKET_IO_DEBUG
                debugMethod.Invoke("[SocketIO] No callbacks registered for event: " + ev);
#endif
                return;
            }

            List<Action<SocketIOEvent>> l = handlers[ev];
            if (!l.Contains(callback))
            {
#if SOCKET_IO_DEBUG
                debugMethod.Invoke("[SocketIO] Couldn't remove callback action for event: " + ev);
#endif
                return;
            }

            l.Remove(callback);
            if (l.Count == 0)
            {
                handlers.Remove(ev);
            }
        }


        /// <summary>
        /// send packet to server
        /// </summary>
        /// <param name="mainCmd"></param>
        /// <param name="subCmd"></param>
        /// <param name="pbBody"></param>
        /// <param name="action"></param>
        /// <param name="idx"></param>
        /// <typeparam name="T"></typeparam>
        public void Emit<TRequest, TResponse>(PBMainCmd mainCmd, Enum subCmd, TRequest pbBody,
            Action<PBPacket<TResponse>> action = null,
            PBMatchIndex idx = default
        ) where TRequest : class where TResponse : class
        {
            PBHeader pbHeader = new PBHeader()
            {
                mainCmd = (uint) mainCmd,
                subCmd = Convert.ToUInt32(subCmd),
                encrypt = config.encrypt,
                clientCtx = (uint) ++packetId,
                idx = idx
            };
            PBPacket<TRequest> pbPacket = new PBPacket<TRequest>(pbHeader, pbBody);
            EmitPbPacket(pbPacket);
            if (action != null)
            {
                Ack ack = new Ack(packetId, (ev) =>
                {
                    var data = new PBPacket<TResponse>(ev.RawData);
                    action.Invoke(data);
                });
                ackList.Add(ack);
            }
        }

        public void EmitAsync<TRequest, TResponse>(PBMainCmd mainCmd, Enum subCmd, TRequest pbBody,
            Action<bool> onComplete,
            Action<PBPacket<TResponse>> action = null,
            PBMatchIndex idx = default
        ) where TRequest : class where TResponse : class
        {
            PBHeader pbHeader = new PBHeader()
            {
                mainCmd = (uint) mainCmd,
                subCmd = Convert.ToUInt32(subCmd),
                encrypt = config.encrypt,
                clientCtx = (uint) ++packetId,
                idx = idx
            };
            PBPacket<TRequest> pbPacket = new PBPacket<TRequest>(pbHeader, pbBody);
            EmitPbPacketAsync(pbPacket, onComplete);
            if (action != null)
            {
                Ack ack = new Ack(packetId, (ev) =>
                {
                    var data = new PBPacket<TResponse>(ev.RawData);
                    action.Invoke(data);
                });
                ackList.Add(ack);
            }
        }

        public async Task<bool> EmitAsync<TRequest, TResponse>(PBMainCmd mainCmd, Enum subCmd, TRequest pbBody,
            Action<PBPacket<TResponse>> action = null,
            PBMatchIndex idx = default
        ) where TRequest : class where TResponse : class
        {
            PBHeader pbHeader = new PBHeader()
            {
                mainCmd = (uint) mainCmd,
                subCmd = Convert.ToUInt32(subCmd),
                encrypt = config.encrypt,
                clientCtx = (uint) ++packetId,
                idx = idx
            };
            PBPacket<TRequest> pbPacket = new PBPacket<TRequest>(pbHeader, pbBody);
            var result = await EmitPbPacketAsync(pbPacket);
            if (action != null)
            {
                Ack ack = new Ack(packetId, (ev) =>
                {
                    var data = new PBPacket<TResponse>(ev.RawData);
                    action.Invoke(data);
                });
                ackList.Add(ack);
            }

            return result;
        }

        #endregion

        #region Private Methods

        private async void RunSocketThread(object obj)
        {
            WebSocket webSocket = (WebSocket) obj;
            while (connected)
            {
                if (webSocket.IsConnected)
                {
                    await Task.Delay(config.reconnectDelay);
                }
                else
                {
                    webSocket.Connect();
                }
            }

            webSocket.Close();
        }

        private async void RunPingThread(object obj)
        {
            WebSocket webSocket = (WebSocket) obj;

            int timeoutMilis = Mathf.FloorToInt(config.pingTimeout * 1000);
            int intervalMilis = Mathf.FloorToInt(config.pingInterval * 1000);

            DateTime pingStart;

            while (connected)
            {
                if (!wsConnected)
                {
                    await Task.Delay(
                        config.reconnectDelay);
                }
                else
                {
                    thPinging = true;

                    PBHeader header = new PBHeader()
                    {
                        mainCmd = (uint) PBMainCmd.MCmd_HeartBeat,
                        subCmd = (uint) PBMainCmdHeartBeatSubCmd.HB_Send,
                        encrypt = config.encrypt,
                        clientCtx = HeartBeatPacketId,
                        idx = default,
                    };

                    var hearBeat = new PBHearBeat();
                    TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);

                    hearBeat.timestamp = (ulong) ts.TotalMilliseconds;

                    PBPacket<PBHearBeat> pbPacket = new PBPacket<PBHearBeat>(header, hearBeat);
                    EmitPbPacket(pbPacket);
                    pingStart = DateTime.Now;

                    while (webSocket.IsConnected && thPinging &&
                           (DateTime.Now.Subtract(pingStart).TotalMilliseconds < timeoutMilis))
                    {
                        await Task.Delay(200);
                    }

                    await Task.Delay(intervalMilis);
                }
            }

#if SOCKET_IO_DEBUG
            debugMethod.Invoke("[SocketIO] heartBeat Thread websocket closed ");
#endif
            webSocket.Close();
        }


        /// <summary>
        /// send PbPacket sync
        /// </summary>
        /// <param name="packet"></param>
        private void EmitPbPacket<T>(PBPacket<T> packet) where T : class
        {
#if SOCKET_IO_DEBUG
            debugMethod.Invoke("[SocketIO] " + packet);
#endif
            try
            {
                ws.Send(packet.ByteArray);
            }
            catch (SocketIOException ex)
            {
#if SOCKET_IO_DEBUG
                debugMethod.Invoke(ex.ToString());
#endif
            }
        }

        /// <summary>
        /// send PbPacket async
        /// </summary>
        /// <param name="packet"></param>
        /// <param name="onComplete"></param>
        private void EmitPbPacketAsync<T>(PBPacket<T> packet, Action<bool> onComplete) where T : class
        {
#if SOCKET_IO_DEBUG
            debugMethod.Invoke("[SocketIO] " + packet);
#endif
            try
            {
                ws.SendAsync(packet.ByteArray, onComplete);
            }
            catch (SocketIOException ex)
            {
#if SOCKET_IO_DEBUG
                debugMethod.Invoke(ex.ToString());
#endif
            }
        }

        /// <summary>
        /// send PbPacket async
        /// </summary>
        /// <param name="packet"></param>
        /// <param name="onComplete"></param>
        private async Task<bool> EmitPbPacketAsync<T>(PBPacket<T> packet) where T : class
        {
#if SOCKET_IO_DEBUG
            debugMethod.Invoke("[SocketIO] " + packet);
#endif
            bool complete = false;
            bool result = false;
            Action<bool> onComplete = b =>
            {
                complete = true;
                result = b;
            };

            try
            {
                ws.SendAsync(packet.ByteArray, onComplete);
            }
            catch (SocketIOException ex)
            {
#if SOCKET_IO_DEBUG
                debugMethod.Invoke(ex.ToString());
#endif
            }

            while (wsConnected && !complete)
            {
                await Task.Delay(10);
            }

            return result;
        }


        private void OnOpen(object sender, EventArgs e)
        {
            EmitEvent(config.eventOpenName);
        }


        public void HandleMessage(MessageEventArgs eventArgs, PBHeader pbHeader)
        {
            for (int i = 0; i < ackList.Count; i++)
            {
                if (ackList[i].packetId != pbHeader.clientCtx)
                {
                    continue;
                }

                lock (ackQueueLock)
                {
                    ackQueue.Enqueue(new AckMessage(eventArgs));
                }

                return;
            }

            //TODO 事件队列
            // if (packet.socketPacketType == SocketPacketType.EVENT)
            // {
            //     SocketIOEvent e = parser.Parse(packet.json);
            //     lock (eventQueueLock)
            //     {
            //         eventQueue.Enqueue(e);
            //     }
            // }
        }

        private void OnError(object sender, ErrorEventArgs e)
        {
            if (Application.isPlaying)
                EmitEvent(new SocketIOEvent(config.eventErrorName, JSONObject.CreateStringObject(e.Message)));
        }

        private void OnClose(object sender, CloseEventArgs e)
        {
            EmitEvent(config.eventCloseName);
        }

        public void EmitEvent(string type)
        {
            EmitEvent(new SocketIOEvent(type));
        }

        private void EmitEvent(SocketIOEvent ev)
        {
            if (!handlers.ContainsKey(ev.name))
            {
                return;
            }

            foreach (Action<SocketIOEvent> handler in handlers[ev.name])
            {
                try
                {
                    handler(ev);
                }
                catch (Exception ex)
                {
#if SOCKET_IO_DEBUG
                    debugMethod.Invoke(ex.ToString());
#endif
                }
            }
        }

        private void InvokeAck(AckMessage ackMessage)
        {
            Ack ack;
            for (int i = 0; i < ackList.Count; i++)
            {
                if (ackList[i].packetId != ackMessage.PacketId)
                {
                    continue;
                }

                ack = ackList[i];
                ackList.RemoveAt(i);
                Loom.RunAsync(() => { ack.Invoke(ackMessage.MessageEventArgs); });
                return;
            }
        }

        #endregion
    }
}