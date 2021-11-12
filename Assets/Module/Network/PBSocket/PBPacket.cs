using System;
using System.Linq;
using JEngine.Core;
using pbcmd;

namespace Module.Network.PBSocket
{
    public class PBPacket<T> where T : class
    {
        public PBHeader PBHeader
        {
            get => _PBHeader;
        }

        public T PBBody
        {
            get => _PBBody;
        }

        public byte[] ByteArray
        {
            get => _bytesArray;
        }

        #region private properties

        private int _packetId;

        private Type _PBType;

        public Type PBType => _PBType;

        public int PacketId => _packetId;
        public PBMainCmd MainCmd => _mainCmd;


        private PBHeader _PBHeader;
        private T _PBBody;
        private byte[] _bytesArray;
        private PBMainCmd _mainCmd;

        #endregion

        public PBPacket(PBHeader pbHeader, T pbBody)
        {
            _PBHeader = pbHeader;
            _PBBody = pbBody;
            _packetId = (int) pbHeader.clientCtx;
            _mainCmd = (PBMainCmd) Enum.ToObject(typeof(PBMainCmd), pbHeader.mainCmd);
            _PBType = typeof(T);

            byte[] headerBytes = StringifyHelper.ProtoSerialize(pbHeader);
            byte[] bodyBytes = StringifyHelper.ProtoSerialize(pbBody);

            // Log.Print("headSize: " + headerBytes.Length);
            // Log.Print("bodySize: " + bodyBytes.Length);

            int totalSize = headerBytes.Length + bodyBytes.Length + 1;
            _bytesArray = new byte[totalSize];
            _bytesArray[0] = Convert.ToByte(headerBytes.Length);
            headerBytes.CopyTo(_bytesArray, 1);
            bodyBytes.CopyTo(_bytesArray, headerBytes.Length + 1);
        }

        public PBPacket(byte[] bytes)
        {
            _bytesArray = bytes;
            int headSize = Convert.ToInt32(_bytesArray[0]);
            byte[] headBytes = _bytesArray.Skip(1).Take(headSize).ToArray();
            _PBHeader = StringifyHelper.ProtoDeSerialize<PBHeader>(headBytes);
            byte[] bodyBytes = _bytesArray.Skip(headSize + 1).Take(_bytesArray.Length - headSize - 1).ToArray();
            _PBBody = StringifyHelper.ProtoDeSerialize<T>(bodyBytes);
            _PBType = typeof(T);

            _mainCmd = (PBMainCmd) Enum.ToObject(typeof(PBMainCmd), _PBHeader.mainCmd);

            _packetId = (int) _PBHeader.clientCtx;
        }

        public override string ToString()
        {
            return " PBHeader: " + StringifyHelper.JSONSerliaze(_PBHeader) + Environment.NewLine + " PBBody: " +
                   typeof(T).FullName +
                   ":" + StringifyHelper.JSONSerliaze(_PBBody);
        }
    }
}