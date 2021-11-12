#region License

/*
 * Ack.cs
 *
 * The MIT License
 *
 * Copyright (c) 2014 Fabio Panettieri
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

#endregion

using System;
using WebSocketSharp;

namespace JEngine.Net
{
    /// <summary>
    /// 用于消息确认以及回调action
    /// </summary>
    public class Ack
    {
        public int packetId;
        public DateTime time;

        private Action<MessageEventArgs> action;
        private Action<PbcmdHelper.PbSocketEvent> onError;

        public Ack(int packetId, Action<MessageEventArgs> action, Action<PbcmdHelper.PbSocketEvent> onError = null)
        {
            this.packetId = packetId;
            time = DateTime.Now;
            this.action = action;
            this.onError = onError;
        }

        public void Invoke(MessageEventArgs ev)
        {
            action?.Invoke(ev);
        }

        public void InvokeTimeout()
        {
            onError?.Invoke(PbcmdHelper.PbSocketEvent.Timeout);
        }

        public override string ToString()
        {
            return string.Format("[Ack: packetId={0}, time={1}, action={2}]", packetId, time, action);
        }
    }
}