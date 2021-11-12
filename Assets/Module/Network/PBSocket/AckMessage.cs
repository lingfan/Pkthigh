using System;
using System.Collections;
using System.Collections.Generic;
using JEngine.Core;
using UnityEngine;
using WebSocketSharp;

/// <summary>
/// for ack queue to reduce serialize times 
/// </summary>
public class AckMessage
{
    public AckMessage(MessageEventArgs messageEventArgs)
    {
        _messageEventArgs = messageEventArgs;
        _packetId = (int) StringifyHelper.GetHeader(messageEventArgs.RawData).clientCtx;
    }

    public MessageEventArgs MessageEventArgs
    {
        get => _messageEventArgs;
    }

    public int PacketId
    {
        get => _packetId;
    }

    private MessageEventArgs _messageEventArgs;
    private int _packetId;
}