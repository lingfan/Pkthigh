// This file was generated by a tool; you should avoid making direct changes.
// Consider using 'partial classes' to extend these types
// Input: notification.proto

#pragma warning disable CS1591, CS0612, CS3021

namespace pbcmd
{
    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public partial class PBNotifyMsg
    {
        [global::ProtoBuf.ProtoMember(1, IsRequired = true)]
        public uint type { get; set; }

        [global::ProtoBuf.ProtoMember(2)]
        public byte[] data
        {
            get { return __pbn__data; }
            set { __pbn__data = value; }
        }
        public bool ShouldSerializedata() => __pbn__data != null;
        public void Resetdata() => __pbn__data = null;
        private byte[] __pbn__data;

        [global::ProtoBuf.ProtoMember(3)]
        public uint time
        {
            get { return __pbn__time.GetValueOrDefault(); }
            set { __pbn__time = value; }
        }
        public bool ShouldSerializetime() => __pbn__time != null;
        public void Resettime() => __pbn__time = null;
        private uint? __pbn__time;

    }

    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public partial class PBNotifyMsgData
    {
        [global::ProtoBuf.ProtoMember(1)]
        [global::System.ComponentModel.DefaultValue("")]
        public string text
        {
            get { return __pbn__text ?? ""; }
            set { __pbn__text = value; }
        }
        public bool ShouldSerializetext() => __pbn__text != null;
        public void Resettext() => __pbn__text = null;
        private string __pbn__text;

    }

    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public partial class PBNotifyMsgToClient
    {
        [global::ProtoBuf.ProtoMember(1, TypeName = "pbcmd.PBNotifyMsg")]
        public global::System.Collections.Generic.List<PBNotifyMsg> msgs { get; } = new global::System.Collections.Generic.List<PBNotifyMsg>();

    }

    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public partial class PBNotifyMsgCountToClient
    {
        [global::ProtoBuf.ProtoMember(1, IsRequired = true)]
        public uint count { get; set; }

    }

    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public partial class PBReqFetchNotifys
    {
    }

    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public partial class PBRespFetchNotifys
    {
        [global::ProtoBuf.ProtoMember(1, IsRequired = true)]
        public PBCommResult ret { get; set; }

        [global::ProtoBuf.ProtoMember(2, TypeName = "pbcmd.PBNotifyMsg")]
        public global::System.Collections.Generic.List<PBNotifyMsg> msgs { get; } = new global::System.Collections.Generic.List<PBNotifyMsg>();

    }

    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public partial class PBReqBulletin
    {
        [global::ProtoBuf.ProtoMember(1)]
        [global::System.ComponentModel.DefaultValue("")]
        public string versionCode
        {
            get { return __pbn__versionCode ?? ""; }
            set { __pbn__versionCode = value; }
        }
        public bool ShouldSerializeversionCode() => __pbn__versionCode != null;
        public void ResetversionCode() => __pbn__versionCode = null;
        private string __pbn__versionCode;

    }

    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public partial class Bulletin
    {
        [global::ProtoBuf.ProtoMember(1)]
        public int bulletinType
        {
            get { return __pbn__bulletinType.GetValueOrDefault(); }
            set { __pbn__bulletinType = value; }
        }
        public bool ShouldSerializebulletinType() => __pbn__bulletinType != null;
        public void ResetbulletinType() => __pbn__bulletinType = null;
        private int? __pbn__bulletinType;

        [global::ProtoBuf.ProtoMember(2)]
        [global::System.ComponentModel.DefaultValue("")]
        public string title
        {
            get { return __pbn__title ?? ""; }
            set { __pbn__title = value; }
        }
        public bool ShouldSerializetitle() => __pbn__title != null;
        public void Resettitle() => __pbn__title = null;
        private string __pbn__title;

        [global::ProtoBuf.ProtoMember(3)]
        [global::System.ComponentModel.DefaultValue("")]
        public string content
        {
            get { return __pbn__content ?? ""; }
            set { __pbn__content = value; }
        }
        public bool ShouldSerializecontent() => __pbn__content != null;
        public void Resetcontent() => __pbn__content = null;
        private string __pbn__content;

        [global::ProtoBuf.ProtoMember(4)]
        [global::System.ComponentModel.DefaultValue("")]
        public string link
        {
            get { return __pbn__link ?? ""; }
            set { __pbn__link = value; }
        }
        public bool ShouldSerializelink() => __pbn__link != null;
        public void Resetlink() => __pbn__link = null;
        private string __pbn__link;

        [global::ProtoBuf.ProtoMember(5)]
        [global::System.ComponentModel.DefaultValue("")]
        public string contentEn
        {
            get { return __pbn__contentEn ?? ""; }
            set { __pbn__contentEn = value; }
        }
        public bool ShouldSerializecontentEn() => __pbn__contentEn != null;
        public void ResetcontentEn() => __pbn__contentEn = null;
        private string __pbn__contentEn;

        [global::ProtoBuf.ProtoMember(6)]
        [global::System.ComponentModel.DefaultValue("")]
        public string titleEn
        {
            get { return __pbn__titleEn ?? ""; }
            set { __pbn__titleEn = value; }
        }
        public bool ShouldSerializetitleEn() => __pbn__titleEn != null;
        public void ResettitleEn() => __pbn__titleEn = null;
        private string __pbn__titleEn;

    }

    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public partial class PBRespBulletin
    {
        [global::ProtoBuf.ProtoMember(1)]
        public PBCommResult ret { get; set; }

        [global::ProtoBuf.ProtoMember(2, TypeName = "pbcmd.Bulletin")]
        public global::System.Collections.Generic.List<Bulletin> bulletins { get; } = new global::System.Collections.Generic.List<Bulletin>();

    }

    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public partial class PBActivityInfo
    {
        [global::ProtoBuf.ProtoMember(1)]
        public uint activityId
        {
            get { return __pbn__activityId.GetValueOrDefault(); }
            set { __pbn__activityId = value; }
        }
        public bool ShouldSerializeactivityId() => __pbn__activityId != null;
        public void ResetactivityId() => __pbn__activityId = null;
        private uint? __pbn__activityId;

        [global::ProtoBuf.ProtoMember(2)]
        public uint activityType
        {
            get { return __pbn__activityType.GetValueOrDefault(); }
            set { __pbn__activityType = value; }
        }
        public bool ShouldSerializeactivityType() => __pbn__activityType != null;
        public void ResetactivityType() => __pbn__activityType = null;
        private uint? __pbn__activityType;

        [global::ProtoBuf.ProtoMember(3)]
        public ActivityHandsProgress handsProgress { get; set; }

        [System.Serializable]
        [global::ProtoBuf.ProtoContract()]
        public partial class ActivityHandsProgress
        {
            [global::ProtoBuf.ProtoMember(1)]
            public uint playedHandsNum
            {
                get { return __pbn__playedHandsNum.GetValueOrDefault(); }
                set { __pbn__playedHandsNum = value; }
            }
            public bool ShouldSerializeplayedHandsNum() => __pbn__playedHandsNum != null;
            public void ResetplayedHandsNum() => __pbn__playedHandsNum = null;
            private uint? __pbn__playedHandsNum;

            [global::ProtoBuf.ProtoMember(2)]
            public uint drawHandsNum
            {
                get { return __pbn__drawHandsNum.GetValueOrDefault(); }
                set { __pbn__drawHandsNum = value; }
            }
            public bool ShouldSerializedrawHandsNum() => __pbn__drawHandsNum != null;
            public void ResetdrawHandsNum() => __pbn__drawHandsNum = null;
            private uint? __pbn__drawHandsNum;

            [global::ProtoBuf.ProtoMember(3)]
            public bool canDraw
            {
                get { return __pbn__canDraw.GetValueOrDefault(); }
                set { __pbn__canDraw = value; }
            }
            public bool ShouldSerializecanDraw() => __pbn__canDraw != null;
            public void ResetcanDraw() => __pbn__canDraw = null;
            private bool? __pbn__canDraw;

        }

    }

    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public partial class PBMoneyNotifyInfo
    {
        [global::ProtoBuf.ProtoMember(1)]
        public ulong timeCoin
        {
            get { return __pbn__timeCoin.GetValueOrDefault(); }
            set { __pbn__timeCoin = value; }
        }
        public bool ShouldSerializetimeCoin() => __pbn__timeCoin != null;
        public void ResettimeCoin() => __pbn__timeCoin = null;
        private ulong? __pbn__timeCoin;

        [global::ProtoBuf.ProtoMember(2)]
        public ulong pktCoin
        {
            get { return __pbn__pktCoin.GetValueOrDefault(); }
            set { __pbn__pktCoin = value; }
        }
        public bool ShouldSerializepktCoin() => __pbn__pktCoin != null;
        public void ResetpktCoin() => __pbn__pktCoin = null;
        private ulong? __pbn__pktCoin;

    }

    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public partial class PBRespRechargeCallback
    {
        [global::ProtoBuf.ProtoMember(1, IsRequired = true)]
        public PBCommResult ret { get; set; }

        [global::ProtoBuf.ProtoMember(2)]
        [global::System.ComponentModel.DefaultValue("")]
        public string oid
        {
            get { return __pbn__oid ?? ""; }
            set { __pbn__oid = value; }
        }
        public bool ShouldSerializeoid() => __pbn__oid != null;
        public void Resetoid() => __pbn__oid = null;
        private string __pbn__oid;

        [global::ProtoBuf.ProtoMember(3)]
        public uint uid
        {
            get { return __pbn__uid.GetValueOrDefault(); }
            set { __pbn__uid = value; }
        }
        public bool ShouldSerializeuid() => __pbn__uid != null;
        public void Resetuid() => __pbn__uid = null;
        private uint? __pbn__uid;

        [global::ProtoBuf.ProtoMember(4)]
        [global::System.ComponentModel.DefaultValue("")]
        public string address
        {
            get { return __pbn__address ?? ""; }
            set { __pbn__address = value; }
        }
        public bool ShouldSerializeaddress() => __pbn__address != null;
        public void Resetaddress() => __pbn__address = null;
        private string __pbn__address;

        [global::ProtoBuf.ProtoMember(5)]
        public long orderTime
        {
            get { return __pbn__orderTime.GetValueOrDefault(); }
            set { __pbn__orderTime = value; }
        }
        public bool ShouldSerializeorderTime() => __pbn__orderTime != null;
        public void ResetorderTime() => __pbn__orderTime = null;
        private long? __pbn__orderTime;

        [global::ProtoBuf.ProtoMember(6)]
        [global::System.ComponentModel.DefaultValue("")]
        public string moneyType
        {
            get { return __pbn__moneyType ?? ""; }
            set { __pbn__moneyType = value; }
        }
        public bool ShouldSerializemoneyType() => __pbn__moneyType != null;
        public void ResetmoneyType() => __pbn__moneyType = null;
        private string __pbn__moneyType;

        [global::ProtoBuf.ProtoMember(7, IsRequired = true)]
        public uint status { get; set; }

        [global::ProtoBuf.ProtoMember(8)]
        public ulong amount
        {
            get { return __pbn__amount.GetValueOrDefault(); }
            set { __pbn__amount = value; }
        }
        public bool ShouldSerializeamount() => __pbn__amount != null;
        public void Resetamount() => __pbn__amount = null;
        private ulong? __pbn__amount;

    }

    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public partial class PBFaceRecognitionVIPBonusNotify
    {
        [global::ProtoBuf.ProtoMember(1, IsRequired = true)]
        public long bonus { get; set; }

    }

    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public partial class PBRespGiveMoneyCurrency
    {
        [global::ProtoBuf.ProtoMember(1, IsRequired = true)]
        public long currencyTime { get; set; }

        [global::ProtoBuf.ProtoMember(2, IsRequired = true)]
        public string currency { get; set; }

        [global::ProtoBuf.ProtoMember(3, IsRequired = true)]
        public string nickname { get; set; }

        [global::ProtoBuf.ProtoMember(4, IsRequired = true)]
        public uint uid { get; set; }

    }

    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public partial class PBRespGiveMoney
    {
        [global::ProtoBuf.ProtoMember(1, IsRequired = true)]
        public string head { get; set; }

        [global::ProtoBuf.ProtoMember(2, IsRequired = true)]
        public string nickname { get; set; }

        [global::ProtoBuf.ProtoMember(3, IsRequired = true)]
        public int uid { get; set; }

        [global::ProtoBuf.ProtoMember(4, IsRequired = true)]
        public double money { get; set; }

        [global::ProtoBuf.ProtoMember(5, IsRequired = true)]
        public long giveTime { get; set; }

    }

    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public enum PBNotifyMsgType
    {
        BuyinRequest = 1,
        JoinClubRequet = 2,
        JoinClubResponse = 3,
        NotifyClubMatch = 4,
        GuessNewNotify = 5,
        WeiboPraiseNotify = 6,
        WeiboReviewNotify = 7,
        WeiboRelayNotify = 8,
        WeiboFansNotify = 9,
        NotifyMultiUser = 10,
        WeiboNewFeedNotify = 11,
        PromoActivityDone = 12,
        PromoPayDoneAward = 13,
        PromoCommNotify = 14,
        ClubUpdateUserRole = 15,
        StopServerNotify = 16,
        NoticeUpdateNotify = 17,
        JoinUnionRequest = 18,
        JoinUnionResponse = 19,
        UnionUpdateAdminLevel = 20,
        ActivityNotify = 21,
        MoneyNotify = 22,
        MidnightNotify = 23,
        ActivityStatusNotify = 24,
        SnapshotNotify = 25,
        RechargeNotify = 26,
        FaceRecognitionVIPBonusNotify = 27,
        FaceRecognitionBindPassNotify = 28,
        FaceRecognitionRepeatFaceNotify = 29,
        GiveMoneyCurrencyNotify = 30,
        GiveMoneyNotify = 31,
    }

}

#pragma warning restore CS1591, CS0612, CS3021
