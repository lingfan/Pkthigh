// This file was generated by a tool; you should avoid making direct changes.
// Consider using 'partial classes' to extend these types
// Input: msg.proto

#pragma warning disable CS1591, CS0612, CS3021

namespace pbcmd
{
    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public partial class PBReqPromoNotifyList
    {
        [global::ProtoBuf.ProtoMember(1, IsRequired = true)]
        public PBCommParam comm { get; set; }

        [global::ProtoBuf.ProtoMember(2)]
        [global::System.ComponentModel.DefaultValue("")]
        public string offset
        {
            get { return __pbn__offset ?? ""; }
            set { __pbn__offset = value; }
        }
        public bool ShouldSerializeoffset() => __pbn__offset != null;
        public void Resetoffset() => __pbn__offset = null;
        private string __pbn__offset;

        [global::ProtoBuf.ProtoMember(3)]
        public uint type
        {
            get { return __pbn__type.GetValueOrDefault(); }
            set { __pbn__type = value; }
        }
        public bool ShouldSerializetype() => __pbn__type != null;
        public void Resettype() => __pbn__type = null;
        private uint? __pbn__type;

        [global::ProtoBuf.ProtoMember(4)]
        public uint clear
        {
            get { return __pbn__clear.GetValueOrDefault(); }
            set { __pbn__clear = value; }
        }
        public bool ShouldSerializeclear() => __pbn__clear != null;
        public void Resetclear() => __pbn__clear = null;
        private uint? __pbn__clear;

    }

    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public partial class PBRespPromoNotifyList
    {
        [global::ProtoBuf.ProtoMember(1, IsRequired = true)]
        public PBCommResult ret { get; set; }

        [global::ProtoBuf.ProtoMember(2, IsRequired = true)]
        public PBPromoNotify list { get; set; }

        [global::ProtoBuf.ProtoMember(3)]
        [global::System.ComponentModel.DefaultValue("")]
        public string offset
        {
            get { return __pbn__offset ?? ""; }
            set { __pbn__offset = value; }
        }
        public bool ShouldSerializeoffset() => __pbn__offset != null;
        public void Resetoffset() => __pbn__offset = null;
        private string __pbn__offset;

    }

    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public partial class PBPromoNotify
    {
        [global::ProtoBuf.ProtoMember(1, IsRequired = true)]
        public uint id { get; set; }

        [global::ProtoBuf.ProtoMember(2, IsRequired = true)]
        public string title { get; set; }

        [global::ProtoBuf.ProtoMember(3)]
        public uint ctime
        {
            get { return __pbn__ctime.GetValueOrDefault(); }
            set { __pbn__ctime = value; }
        }
        public bool ShouldSerializectime() => __pbn__ctime != null;
        public void Resetctime() => __pbn__ctime = null;
        private uint? __pbn__ctime;

        [global::ProtoBuf.ProtoMember(4)]
        [global::System.ComponentModel.DefaultValue("")]
        public string content
        {
            get { return __pbn__content ?? ""; }
            set { __pbn__content = value; }
        }
        public bool ShouldSerializecontent() => __pbn__content != null;
        public void Resetcontent() => __pbn__content = null;
        private string __pbn__content;

        [global::ProtoBuf.ProtoMember(5)]
        [global::System.ComponentModel.DefaultValue("")]
        public string pic
        {
            get { return __pbn__pic ?? ""; }
            set { __pbn__pic = value; }
        }
        public bool ShouldSerializepic() => __pbn__pic != null;
        public void Resetpic() => __pbn__pic = null;
        private string __pbn__pic;

    }

}

#pragma warning restore CS1591, CS0612, CS3021
