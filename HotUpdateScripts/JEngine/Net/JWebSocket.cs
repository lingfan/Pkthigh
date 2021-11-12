//
// JWebSocket.cs
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

using System;
using System.Threading.Tasks;
using JEngine.Core;
using Module.Network.PBSocket;
using pbcmd;
using UnityEngine;
using WebSocketSharp;

namespace JEngine.Net
{
    public class JWebSocket
    {
        private static GameObject mgr;

        private SocketIOComponent socket;

        public bool Connected => socket.IsConnected;

        private bool hasConnected = false;
        private Action onReconnect;

        /// <summary>
        /// 连接websokcet服务器，如果使用的socket-io，请给isSocketIO参数设置为true（socketio是nodejs服务器使用的一个websocket插件）
        /// </summary>
        /// <param name="url"></param>
        /// <param name="config"></param>
        /// <param name="isSocketIO"></param>
        public JWebSocket(string url, JSocketConfig config = null, Action<object, MessageEventArgs> OnMessage = null)
        {
            if (mgr == null)
            {
                mgr = new GameObject("JEngine.Net");
                UnityEngine.Object.DontDestroyOnLoad(mgr);
            }

            socket = mgr.AddComponent<SocketIOComponent>();

            socket.Init(url, config, OnMessage);
        }

        /// <summary>
        /// Connect to server, this method doesn't block the context
        /// 连接服务器，此方法不阻塞
        /// </summary>
        public void Connect()
        {
            socket.Connect();
        }

        public void OnOpen(Action<SocketIOEvent> socketIOEvent)
        {
            socket.On(socket.config.eventOpenName, socketIOEvent);
        }

        public void OnConnect(Action<SocketIOEvent> socketIOEvent)
        {
            Action<SocketIOEvent> todo = (e) =>
            {
                socketIOEvent(e);
                if (!hasConnected)
                {
                    hasConnected = true;
                }
                else
                {
                    onReconnect?.Invoke();
                }
            };
            socket.On(socket.config.eventConnectName, todo);
        }

        public void OnReconnect(Action socketIOEvent)
        {
            onReconnect = socketIOEvent;
        }

        public void OnDisconnect(Action<SocketIOEvent> socketIOEvent)
        {
            socket.On(socket.config.eventDisconnectName, socketIOEvent);
        }

        public void OnClose(Action<SocketIOEvent> socketIOEvent)
        {
            socket.On(socket.config.eventCloseName, socketIOEvent);
        }

        public void OnError(Action<SocketIOEvent> socketIOEvent)
        {
            socket.On(socket.config.eventErrorName, socketIOEvent);
        }

        public void Send<TRequest, TResponse>(PBMainCmd mainCmd, Enum subCmd, TRequest pbBody,
            Action<PBPacket<TResponse>> action = null,
            Action<PbcmdHelper.PbSocketEvent> onError = null,
            PBMatchIndex idx = default
        ) where TRequest : class where TResponse : class
        {
            socket.Emit(mainCmd, subCmd, pbBody, action, onError, idx);
        }

        public void SendAysnc<TRequest, TResponse>(PBMainCmd mainCmd, Enum subCmd, TRequest pbBody,
            Action<bool> onComplete,
            Action<PBPacket<TResponse>> action = null,
            Action<PbcmdHelper.PbSocketEvent> onError = null,
            PBMatchIndex idx = default
        ) where TRequest : class where TResponse : class
        {
            socket.EmitAsync(mainCmd, subCmd, pbBody, onComplete, action, onError, idx);
        }

        public async Task<bool> SendAysnc<TRequest, TResponse>(PBMainCmd mainCmd, Enum subCmd, TRequest pbBody,
            Action<PBPacket<TResponse>> action = null,
            Action<PbcmdHelper.PbSocketEvent> onError = null,
            PBMatchIndex idx = default) where TRequest : class where TResponse : class
        {
            var result = await socket.EmitAsync(mainCmd, subCmd, pbBody, action, onError, idx);
            return result;
        }

    }
}