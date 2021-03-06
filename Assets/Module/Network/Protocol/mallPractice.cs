// This file was generated by a tool; you should avoid making direct changes.
// Consider using 'partial classes' to extend these types
// Input: mallPractice.proto

#pragma warning disable CS1591, CS0612, CS3021

namespace pbcmd
{
    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public partial class PBReqMallGetPracticeGoodsList
    {
        [global::ProtoBuf.ProtoMember(1, IsRequired = true)]
        public PBCommParam comm { get; set; }

    }

    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public partial class PBPracticeGoodsList
    {
        [global::ProtoBuf.ProtoMember(1)]
        public uint id
        {
            get { return __pbn__id.GetValueOrDefault(); }
            set { __pbn__id = value; }
        }
        public bool ShouldSerializeid() => __pbn__id != null;
        public void Resetid() => __pbn__id = null;
        private uint? __pbn__id;

        [global::ProtoBuf.ProtoMember(2)]
        [global::System.ComponentModel.DefaultValue("")]
        public string name
        {
            get { return __pbn__name ?? ""; }
            set { __pbn__name = value; }
        }
        public bool ShouldSerializename() => __pbn__name != null;
        public void Resetname() => __pbn__name = null;
        private string __pbn__name;

        [global::ProtoBuf.ProtoMember(3)]
        [global::System.ComponentModel.DefaultValue("")]
        public string pic
        {
            get { return __pbn__pic ?? ""; }
            set { __pbn__pic = value; }
        }
        public bool ShouldSerializepic() => __pbn__pic != null;
        public void Resetpic() => __pbn__pic = null;
        private string __pbn__pic;

        [global::ProtoBuf.ProtoMember(4)]
        public uint practice
        {
            get { return __pbn__practice.GetValueOrDefault(); }
            set { __pbn__practice = value; }
        }
        public bool ShouldSerializepractice() => __pbn__practice != null;
        public void Resetpractice() => __pbn__practice = null;
        private uint? __pbn__practice;

        [global::ProtoBuf.ProtoMember(5)]
        public uint give
        {
            get { return __pbn__give.GetValueOrDefault(); }
            set { __pbn__give = value; }
        }
        public bool ShouldSerializegive() => __pbn__give != null;
        public void Resetgive() => __pbn__give = null;
        private uint? __pbn__give;

        [global::ProtoBuf.ProtoMember(6)]
        public uint price
        {
            get { return __pbn__price.GetValueOrDefault(); }
            set { __pbn__price = value; }
        }
        public bool ShouldSerializeprice() => __pbn__price != null;
        public void Resetprice() => __pbn__price = null;
        private uint? __pbn__price;

        [global::ProtoBuf.ProtoMember(7)]
        public uint status
        {
            get { return __pbn__status.GetValueOrDefault(); }
            set { __pbn__status = value; }
        }
        public bool ShouldSerializestatus() => __pbn__status != null;
        public void Resetstatus() => __pbn__status = null;
        private uint? __pbn__status;

        [global::ProtoBuf.ProtoMember(8)]
        public uint deletedAt
        {
            get { return __pbn__deletedAt.GetValueOrDefault(); }
            set { __pbn__deletedAt = value; }
        }
        public bool ShouldSerializedeletedAt() => __pbn__deletedAt != null;
        public void ResetdeletedAt() => __pbn__deletedAt = null;
        private uint? __pbn__deletedAt;

    }

    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public partial class PBRespMallGetPracticeGoodsList
    {
        [global::ProtoBuf.ProtoMember(1, IsRequired = true)]
        public PBCommResult ret { get; set; }

        [global::ProtoBuf.ProtoMember(2, TypeName = "pbcmd.PBPracticeGoodsList")]
        public global::System.Collections.Generic.List<PBPracticeGoodsList> list { get; } = new global::System.Collections.Generic.List<PBPracticeGoodsList>();

    }

    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public partial class PBReqMallBuyPracticeProp
    {
        [global::ProtoBuf.ProtoMember(1, IsRequired = true)]
        public PBCommParam comm { get; set; }

        [global::ProtoBuf.ProtoMember(2)]
        public uint propId
        {
            get { return __pbn__propId.GetValueOrDefault(); }
            set { __pbn__propId = value; }
        }
        public bool ShouldSerializepropId() => __pbn__propId != null;
        public void ResetpropId() => __pbn__propId = null;
        private uint? __pbn__propId;

    }

    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public partial class PBRespMallBuyPracticeProp
    {
        [global::ProtoBuf.ProtoMember(1, IsRequired = true)]
        public PBCommResult ret { get; set; }

    }

}

#pragma warning restore CS1591, CS0612, CS3021
