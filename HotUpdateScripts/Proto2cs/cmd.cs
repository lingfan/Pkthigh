// This file was generated by a tool; you should avoid making direct changes.
// Consider using 'partial classes' to extend these types
// Input: cmd.proto

#pragma warning disable CS1591, CS0612, CS3021

namespace pbcmd
{
    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public partial class PBHeader
    {
        [global::ProtoBuf.ProtoMember(1, IsRequired = true)]
        public uint mainCmd { get; set; }

        [global::ProtoBuf.ProtoMember(2, IsRequired = true)]
        public uint subCmd { get; set; }

        [global::ProtoBuf.ProtoMember(3)]
        public uint encrypt
        {
            get { return __pbn__encrypt.GetValueOrDefault(); }
            set { __pbn__encrypt = value; }
        }
        public bool ShouldSerializeencrypt() => __pbn__encrypt != null;
        public void Resetencrypt() => __pbn__encrypt = null;
        private uint? __pbn__encrypt;

        [global::ProtoBuf.ProtoMember(4)]
        public uint clientCtx
        {
            get { return __pbn__clientCtx.GetValueOrDefault(); }
            set { __pbn__clientCtx = value; }
        }
        public bool ShouldSerializeclientCtx() => __pbn__clientCtx != null;
        public void ResetclientCtx() => __pbn__clientCtx = null;
        private uint? __pbn__clientCtx;

        [global::ProtoBuf.ProtoMember(5)]
        public PBMatchIndex idx { get; set; }

    }

    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public partial class PBMatchIndex
    {
        [global::ProtoBuf.ProtoMember(1, IsRequired = true)]
        public uint svrID { get; set; }

        [global::ProtoBuf.ProtoMember(2, IsRequired = true)]
        public uint matchID { get; set; }

        [global::ProtoBuf.ProtoMember(3)]
        public uint gameType
        {
            get { return __pbn__gameType.GetValueOrDefault(); }
            set { __pbn__gameType = value; }
        }
        public bool ShouldSerializegameType() => __pbn__gameType != null;
        public void ResetgameType() => __pbn__gameType = null;
        private uint? __pbn__gameType;

        [global::ProtoBuf.ProtoMember(4)]
        public uint kind
        {
            get { return __pbn__kind.GetValueOrDefault(); }
            set { __pbn__kind = value; }
        }
        public bool ShouldSerializekind() => __pbn__kind != null;
        public void Resetkind() => __pbn__kind = null;
        private uint? __pbn__kind;

        [global::ProtoBuf.ProtoMember(5)]
        public uint tid
        {
            get { return __pbn__tid.GetValueOrDefault(); }
            set { __pbn__tid = value; }
        }
        public bool ShouldSerializetid() => __pbn__tid != null;
        public void Resettid() => __pbn__tid = null;
        private uint? __pbn__tid;

    }

    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public partial class PBCommParam
    {
        [global::ProtoBuf.ProtoMember(1, IsRequired = true)]
        public uint cid { get; set; }

        [global::ProtoBuf.ProtoMember(2, IsRequired = true)]
        public uint uid { get; set; }

        [global::ProtoBuf.ProtoMember(3, IsRequired = true)]
        public string token { get; set; }

        [global::ProtoBuf.ProtoMember(4, IsRequired = true)]
        public string version { get; set; }

        [global::ProtoBuf.ProtoMember(5)]
        public uint channel
        {
            get { return __pbn__channel.GetValueOrDefault(); }
            set { __pbn__channel = value; }
        }
        public bool ShouldSerializechannel() => __pbn__channel != null;
        public void Resetchannel() => __pbn__channel = null;
        private uint? __pbn__channel;

        [global::ProtoBuf.ProtoMember(6)]
        public uint lang
        {
            get { return __pbn__lang.GetValueOrDefault(); }
            set { __pbn__lang = value; }
        }
        public bool ShouldSerializelang() => __pbn__lang != null;
        public void Resetlang() => __pbn__lang = null;
        private uint? __pbn__lang;

        [global::ProtoBuf.ProtoMember(7)]
        public PBDeviceInfo device { get; set; }

        [global::ProtoBuf.ProtoMember(8)]
        [global::System.ComponentModel.DefaultValue("")]
        public string pkgName
        {
            get { return __pbn__pkgName ?? ""; }
            set { __pbn__pkgName = value; }
        }
        public bool ShouldSerializepkgName() => __pbn__pkgName != null;
        public void ResetpkgName() => __pbn__pkgName = null;
        private string __pbn__pkgName;

    }

    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public partial class PBDeviceInfo
    {
        [global::ProtoBuf.ProtoMember(1)]
        [global::System.ComponentModel.DefaultValue("")]
        public string network
        {
            get { return __pbn__network ?? ""; }
            set { __pbn__network = value; }
        }
        public bool ShouldSerializenetwork() => __pbn__network != null;
        public void Resetnetwork() => __pbn__network = null;
        private string __pbn__network;

        [global::ProtoBuf.ProtoMember(2)]
        [global::System.ComponentModel.DefaultValue("")]
        public string osType
        {
            get { return __pbn__osType ?? ""; }
            set { __pbn__osType = value; }
        }
        public bool ShouldSerializeosType() => __pbn__osType != null;
        public void ResetosType() => __pbn__osType = null;
        private string __pbn__osType;

        [global::ProtoBuf.ProtoMember(3)]
        [global::System.ComponentModel.DefaultValue("")]
        public string osVersion
        {
            get { return __pbn__osVersion ?? ""; }
            set { __pbn__osVersion = value; }
        }
        public bool ShouldSerializeosVersion() => __pbn__osVersion != null;
        public void ResetosVersion() => __pbn__osVersion = null;
        private string __pbn__osVersion;

        [global::ProtoBuf.ProtoMember(4)]
        [global::System.ComponentModel.DefaultValue("")]
        public string deviceType
        {
            get { return __pbn__deviceType ?? ""; }
            set { __pbn__deviceType = value; }
        }
        public bool ShouldSerializedeviceType() => __pbn__deviceType != null;
        public void ResetdeviceType() => __pbn__deviceType = null;
        private string __pbn__deviceType;

        [global::ProtoBuf.ProtoMember(5)]
        [global::System.ComponentModel.DefaultValue("")]
        public string imei
        {
            get { return __pbn__imei ?? ""; }
            set { __pbn__imei = value; }
        }
        public bool ShouldSerializeimei() => __pbn__imei != null;
        public void Resetimei() => __pbn__imei = null;
        private string __pbn__imei;

        [global::ProtoBuf.ProtoMember(6)]
        [global::System.ComponentModel.DefaultValue("")]
        public string macAddr
        {
            get { return __pbn__macAddr ?? ""; }
            set { __pbn__macAddr = value; }
        }
        public bool ShouldSerializemacAddr() => __pbn__macAddr != null;
        public void ResetmacAddr() => __pbn__macAddr = null;
        private string __pbn__macAddr;

    }

    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public partial class PBCommResult
    {
        [global::ProtoBuf.ProtoMember(1, IsRequired = true)]
        public int code { get; set; }

        [global::ProtoBuf.ProtoMember(2)]
        [global::System.ComponentModel.DefaultValue("")]
        public string desc
        {
            get { return __pbn__desc ?? ""; }
            set { __pbn__desc = value; }
        }
        public bool ShouldSerializedesc() => __pbn__desc != null;
        public void Resetdesc() => __pbn__desc = null;
        private string __pbn__desc;

    }

    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public partial class PBHearBeat
    {
        [global::ProtoBuf.ProtoMember(1, IsRequired = true)]
        public ulong timestamp { get; set; }

    }

    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public partial class PBServiceNotFound
    {
        [global::ProtoBuf.ProtoMember(1, IsRequired = true)]
        public uint svrType { get; set; }

        [global::ProtoBuf.ProtoMember(2, IsRequired = true)]
        public uint clientCtx { get; set; }

        [global::ProtoBuf.ProtoMember(3)]
        public uint mainCmd
        {
            get { return __pbn__mainCmd.GetValueOrDefault(); }
            set { __pbn__mainCmd = value; }
        }
        public bool ShouldSerializemainCmd() => __pbn__mainCmd != null;
        public void ResetmainCmd() => __pbn__mainCmd = null;
        private uint? __pbn__mainCmd;

        [global::ProtoBuf.ProtoMember(4)]
        public uint subCmd
        {
            get { return __pbn__subCmd.GetValueOrDefault(); }
            set { __pbn__subCmd = value; }
        }
        public bool ShouldSerializesubCmd() => __pbn__subCmd != null;
        public void ResetsubCmd() => __pbn__subCmd = null;
        private uint? __pbn__subCmd;

        [global::ProtoBuf.ProtoMember(5)]
        public uint reason
        {
            get { return __pbn__reason.GetValueOrDefault(); }
            set { __pbn__reason = value; }
        }
        public bool ShouldSerializereason() => __pbn__reason != null;
        public void Resetreason() => __pbn__reason = null;
        private uint? __pbn__reason;

    }

    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public enum PBMainCmd
    {
        MCmd_HeartBeat = 0,
        MCmd_Account = 1,
        MCmd_Guess = 2,
        MCmd_Texas = 3,
        MCmd_MatchList = 4,
        MCmd_Club = 5,
        MCmd_Gamelog = 6,
        MCmd_Weibo = 7,
        MCmd_Rank = 8,
        MCmd_Mall = 9,
        MCmd_Promo = 10,
        MCmd_Notification = 11,
        MCmd_HunTexas = 12,
        MCmd_Short = 14,
        MCmd_Agent = 15,
        MCmd_Pay = 16,
        MCmd_PKT = 17,
        MCmd_Poker = 18,
        MCmd_ClubNew = 19,
        MCmd_Chat = 20,
        MCmd_Union = 21,
        MCmd_MatchMgr = 22,
        MCmd_LuckyCard = 23,
        MCmd_Profile = 24,
        MCmd_Fish = 25,
        MCmd_FaceRecognition = 26,
        MCmd_Registry = 27,
        MCmd_Access = 4097,
        MCmd_State = 4098,
        MCmd_Statistic = 4099,
        MCmd_Monitor = 57345,
    }

    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public enum PBMainCmdHeartBeatSubCmd
    {
        HB_Send = 1,
        HB_Response = 2,
    }

    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public enum PBMainCmdAccessSubCmd
    {
        ServiceNotFound = 1,
        Access_ReqLogout = 4097,
        Access_RespLogout = 4098,
    }

    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public enum PBMainCmdAccountSubCmd
    {
        Account_ReqLogin = 1,
        Account_RespLogin = 2,
        Account_ReqInfo = 3,
        Account_RespInfo = 4,
        Account_ReqModifyInfo = 5,
        Account_RespModifyInfo = 6,
        Account_ReqAccountIsChargeChangeName = 117,
        Account_RespAccountIsChargeChangeName = 118,
        Account_ReqMobileCode = 7,
        Account_RespMobileCode = 8,
        Account_ReqMobileAuth = 9,
        Account_RespMobileAuth = 10,
        Account_ReqMobileRepwd = 11,
        Account_RespMobileRepwd = 12,
        Account_ReqAccountCheckCode = 115,
        Account_RespAccountCheckCode = 116,
        Account_ReqWeixinAuth = 13,
        Account_RespWeixinAuth = 14,
        Account_ReqMobileSecret = 15,
        Account_RespMobileSecret = 16,
        Account_ReqMoney = 17,
        Account_RespMoney = 18,
        Account_ReqOssParam = 19,
        Account_RespOssParam = 20,
        Account_ReqUserProps = 21,
        Account_RespUserProps = 22,
        Account_ReqSetDeviceToken = 23,
        Account_RespSetDeviceToken = 24,
        Account_ReqFeedback = 25,
        Account_RespFeedback = 26,
        Account_ReqSetLocation = 27,
        Account_RespSetLocation = 28,
        Account_ReqGetAvcSign = 29,
        Account_RespGetAvcSign = 30,
        Account_ReqPrelogin = 31,
        Account_RespPrelogin = 32,
        Account_ReqBlackList = 33,
        Account_RespBlackList = 34,
        Account_ReqBlackEdit = 35,
        Account_RespBlackEdit = 36,
        Account_ReqBlackCount = 37,
        Account_RespBlackCount = 38,
        Account_ReqHuaweiAuth = 39,
        Account_RespHuaweiAuth = 40,
        Account_ReqOppoAuth = 43,
        Account_RespOppoAuth = 44,
        Account_ReqVivoAuth = 45,
        Account_RespVivoAuth = 46,
        Account_ReqWxGameAuth = 47,
        Account_RespWxGameAuth = 48,
        Account_ReqAccountVhkdapiVhkdLogIn = 49,
        Account_RespAccountVhkdapiVhkdLogIn = 50,
        Account_ReqAccountVhkdapiVhkdSetPin = 51,
        Account_RespAccountVhkdapiVhkdSetPin = 52,
        Account_ReqAccountVhkdapiVhkdGetAssets = 53,
        Account_RespAccountVhkdapiVhkdGetAssets = 54,
        Account_ReqAccountVhkdapiUpdateAssets = 55,
        Account_RespAccountVhkdapiUpdateAssets = 56,
        Account_ReqAccountVhkdapiGetFlowList = 57,
        Account_RespAccountVhkdapiGetFlowList = 58,
        Account_ReqAccountVhkdapiVhkdIsHasPin = 59,
        Account_RespAccountVhkdapiVhkdIsHasPin = 60,
        Account_ReqAccountVhkdapiVhkdwebViewControl = 61,
        Account_RespAccountVhkdapiVhkdwebViewControl = 62,
        Account_ReqAccountVhkdapiDigitalMoneyMallControl = 74,
        Account_RespAccountVhkdapiDigitalMoneyMallControl = 75,
        Account_ReqAccountVhkdapiGetBTCExchangeRate = 65,
        Account_RespAccountVhkdapiGetBTCExchangeRate = 66,
        Account_ReqAccountVhkdapiGetConfig = 69,
        Account_RespAccountVhkdapiGetConfig = 70,
        Account_ReqAccountVhkdapiGiveMoney = 73,
        Account_RespAccountVhkdapiGiveMoney = 80,
        Account_ReqAccountGetRecordLog = 84,
        Account_RespAccountGetRecordLog = 85,
        Account_ReqAccountVGPayUpdateAssets = 86,
        Account_RespAccountVGPayUpdateAssets = 87,
        Account_ReqAccountVGPayGetAddress = 88,
        Account_RespAccountVGPayGetAddress = 89,
        Account_ReqAccountVGPayGetWithdrawConfig = 90,
        Account_RespAccountVGPayGetWithdrawConfig = 91,
        Account_ReqAccountVGPayApplyTransactionOut = 92,
        Account_RespAccountVGPayApplyTransactionOut = 93,
        Account_ReqAccountVGPayGetAssetsRecordPageList = 94,
        Account_RespAccountVGPayGetAssetsRecordPageList = 95,
        Account_ReqAccountVGPayVhkdToMoney = 112,
        Account_RespAccountVGPayVhkdToMoney = 113,
        Ftpay_ReqFtpayGetPayList = 96,
        Ftpay_RespFtpayGetPayList = 97,
        Ftpay_ReqFtpayPaySubmitAct = 98,
        Ftpay_RespFtpayPaySubmitAct = 99,
        Ftpay_ReqFtpayGetBaId = 100,
        Ftpay_RespFtpayGetBaId = 101,
        Ftpay_ReqFtpayLaunchWithdraw = 102,
        Ftpay_RespFtpayLaunchWithdraw = 103,
        Ftpay_ReqFtpayGetFlowList = 104,
        Ftpay_RespFtpayGetFlowList = 105,
        Ftpay_ReqFtpayGetHistoryCardInfo = 108,
        Ftpay_RespFtpayGetHistoryCardInfo = 109,
        Ftpay_ReqGetPayStatus = 110,
        Ftpay_RespGetPayStatus = 111,
        Ftpay_ReqFtpayGetLaunchWithdrawFee = 119,
        Ftpay_RespFtpayGetLaunchWithdrawFee = 120,
        Ftpay_ReqCheckPIN = 106,
        Ftpay_RespCheckPIN = 107,
        Account_ReqAccountCheckPhoneOrEmail = 81,
        Account_RespAccountCheckPhoneOrEmail = 82,
        Account_ReqGetAutoHeadImg = 128,
        Account_RespGetAutoHeadImg = 129,
        Account_ReqCheckPayDisable = 130,
        Account_RespCheckPayDisable = 131,
        Account_ReqGetVGPayConf = 132,
        Account_RespGetVGPayConf = 133,
        Account_ReqCheckIpLimit = 134,
        Account_RespCheckIpLimit = 135,
        Account_KickUser = 61440,
    }

    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public enum PBMainCmdGuessSubCmd
    {
        Guess_ReqList = 1,
        Guess_RespList = 2,
        Guess_ReqInfo = 3,
        Guess_RespInfo = 4,
        Guess_ReqMake = 5,
        Guess_RespMake = 6,
        Guess_ReqGuesserList = 7,
        Guess_RespGuesserList = 8,
        Guess_ReqNewsList = 9,
        Guess_RespNewsList = 10,
        Guess_ReqStarMarkList = 11,
        Guess_RespStarMarkList = 12,
        Guess_ReqPraise = 13,
        Guess_RespPraise = 14,
        Guess_ReqReview = 15,
        Guess_RespReview = 16,
        Guess_ReqReviewList = 17,
        Guess_RespReviewList = 18,
        Guess_ReqReportReview = 19,
        Guess_RespReportReview = 20,
        Guess_ReqRecordList = 21,
        Guess_RespRecordList = 22,
        Guess_ReqNotifyList = 23,
        Guess_RespNotifyList = 24,
        Guess_ReqNotifyRead = 25,
        Guess_RespNotifyRead = 26,
        Guess_ReqPraisers = 27,
        Guess_RespPraisers = 28,
        Guess_ReqMessageList = 29,
        Guess_RespMessageList = 30,
        Guess_ReqMessageRead = 31,
        Guess_RespMessageRead = 32,
        Guess_ReqNews = 33,
        Guess_RespNews = 34,
        Guess_ReqPokerList = 35,
        Guess_RespPokerList = 36,
        Guess_ReqPokerMake = 37,
        Guess_RespPokerMake = 38,
        Guess_ReqPokerRecordList = 39,
        Guess_RespPokerRecordList = 40,
        Guess_ReqPokerRecordInfo = 41,
        Guess_RespPokerRecordInfo = 42,
        Guess_ReqInfoList = 43,
        Guess_RespInfoList = 44,
    }

    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public enum PBMainCmdWeiboSubCmd
    {
        Weibo_ReqHome = 1,
        Weibo_RespHome = 2,
        Weibo_ReqProfile = 3,
        Weibo_RespProfile = 4,
        Weibo_ReqPublish = 5,
        Weibo_RespPublish = 6,
        Weibo_ReqRemove = 7,
        Weibo_RespRemove = 8,
        Weibo_ReqList = 9,
        Weibo_RespList = 10,
        Weibo_ReqPraise = 11,
        Weibo_RespPraise = 12,
        Weibo_ReqReview = 13,
        Weibo_RespReview = 14,
        Weibo_ReqRelay = 15,
        Weibo_RespRelay = 16,
        Weibo_ReqReport = 17,
        Weibo_RespReport = 18,
        Weibo_ReqReviewList = 19,
        Weibo_RespReviewList = 20,
        Weibo_ReqRelationList = 21,
        Weibo_RespRelationList = 22,
        Weibo_ReqFeed = 23,
        Weibo_RespFeed = 24,
        Weibo_ReqPraisers = 25,
        Weibo_RespPraisers = 26,
        Weibo_ReqNotifyList = 27,
        Weibo_RespNotifyList = 28,
        Weibo_ReqRelationFollow = 29,
        Weibo_RespRelationFollow = 30,
        Weibo_ReqRelation = 31,
        Weibo_RespRelation = 32,
        Weibo_ReqRemoveReview = 33,
        Weibo_RespRemoveReview = 34,
        Weibo_ReqHotUsers = 35,
        Weibo_RespHotUsers = 36,
    }

    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public enum PBMainCmdRankSubCmd
    {
        Rank_ReqList = 1,
        Rank_RespList = 2,
    }

    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public enum PBMainCmdPromoSubCmd
    {
        Promo_ReqProfile = 1,
        Promo_RespProfile = 2,
        Promo_ReqClubList = 3,
        Promo_RespClubList = 4,
        Promo_ReqShareUrl = 5,
        Promo_RespShareUrl = 6,
        Promo_ReqNotifyList = 7,
        Promo_RespNotifyList = 8,
        Promo_ReqNotifyRead = 9,
        Promo_RespNotifyRead = 10,
        Promo_ReqAppSettings = 11,
        Promo_RespAppSettings = 12,
        Promo_ReqRelief = 13,
        Promo_RespRelief = 14,
        Promo_ReqLuckyboxGet = 15,
        Promo_RespLuckyboxGet = 16,
        Promo_ReqLuckyboxOpen = 17,
        Promo_RespLuckyboxOpen = 18,
        Promo_ReqNotifyAward = 19,
        Promo_RespNotifyAward = 20,
        Promo_ReqActivityList = 21,
        Promo_RespActivityList = 22,
        Promo_ReqActivityAward = 23,
        Promo_RespActivityAward = 24,
        Promo_ReqAutoRestart = 25,
        Promo_RespAutoRestart = 26,
        Promo_ReqGetFoundOnlineList = 27,
        Promo_RespGetFoundOnlineList = 28,
    }

    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public enum PBMainCmdMallSubCmd
    {
        Mall_ReqList = 1,
        Mall_RespList = 2,
        Mall_ReqApplePayCreate = 3,
        Mall_RespApplePayCreate = 4,
        Mall_ReqApplePayDeliver = 5,
        Mall_RespApplePayDeliver = 6,
        Mall_ReqPropBuy = 7,
        Mall_RespPropBuy = 8,
        Mall_ReqWeixinPayCreate = 9,
        Mall_RespWeixinPayCreate = 10,
        Mall_ReqAliPayCreate = 11,
        Mall_RespAliPayCreate = 12,
        Mall_ReqHuaweiPayCreate = 13,
        Mall_RespHuaweiPayCreate = 14,
        Mall_ReqVivoPayCreate = 15,
        Mall_RespVivoPayCreate = 16,
        Mall_ReqGiftList = 17,
        Mall_RespGiftList = 18,
        Mall_ReqUserAddrGet = 19,
        Mall_RespUserAddrGet = 20,
        Mall_ReqUserAddrSet = 21,
        Mall_RespUserAddrSet = 22,
        Mall_ReqGiftExchange = 23,
        Mall_RespGiftExchange = 24,
        Mall_ReqGiftExchangeList = 25,
        Mall_RespGiftExchangeList = 26,
        Mall_ReqOppoPayCreate = 27,
        Mall_RespOppoPayCreate = 28,
        Mall_ReqMallGetPracticeGoodsList = 32,
        Mall_RespMallGetPracticeGoodsList = 33,
        Mall_ReqMallBuyPracticeProp = 34,
        Mall_RespMallBuyPracticeProp = 35,
    }

    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public enum PBMainCmdTexasSubCmd
    {
        Texas_ReqJoinTable = 1,
        Texas_ReqLeaveTable = 2,
        Texas_ReqSit = 3,
        Texas_ReqStand = 4,
        Texas_ReqChipin = 5,
        Texas_ReqTabelInfo = 6,
        Texas_ReqShowCard = 7,
        Texas_ReqChat = 8,
        Texas_ReqBuyin = 9,
        Texas_ReqStartMatch = 10,
        Texas_ReqBuyinHistory = 11,
        Texas_ReqGameLog = 12,
        Texas_ReqRegisterAutoAction = 13,
        Texas_ReqBuyInsurance = 14,
        Texas_ReqCloseMatch = 15,
        Texas_ReqExtendThinkingTime = 16,
        Texas_ReqChangeMuckOption = 17,
        Texas_ReqChangeInsuranceNotifyOption = 18,
        Texas_ReqLikeAMatch = 19,
        Texas_ReqUnlikeAMatch = 20,
        Texas_ReqKickUser = 21,
        Texas_ReqProcessBuyinRequest = 22,
        Texas_ReqSendInteractiveItem = 23,
        Texas_ReqSNGConfig = 24,
        Texas_ReqSNGChipRank = 25,
        Texas_ReqSNGMatchBoard = 32,
        Texas_ReqBuyDeposit = 33,
        Texas_ReqShowPublicCards = 34,
        Texas_ReqShowAllHands = 35,
        Texas_ReqRecordNum = 36,
        Texas_ReqPrepareAddDeposit = 37,
        Texas_ReqPrepareCheckout = 38,
        Texas_ReqCheckout = 39,
        Texas_ReqPrivateInfo = 40,
        Texas_NotifyJoinTable = 4097,
        Texas_NotifyLeaveTable = 4098,
        Texas_NotifyUserSit = 4099,
        Texas_NotifyUserStand = 4100,
        Texas_NotifyStartChipin = 4101,
        Texas_NotifyEndChipin = 4102,
        Texas_NotifyTableInfo = 4103,
        Texas_NotifyShowCard = 4104,
        Texas_NotifyChat = 4105,
        Texas_NotifyGameStart = 4112,
        Texas_NotifyDealFlop = 4113,
        Texas_NotifyDealTurn = 4114,
        Texas_NotifyDealRiver = 4115,
        Texas_NotifyStartDealCard = 4116,
        Texas_NotifyDealHoleCard = 4117,
        Texas_NotifySyncSeatInfo = 4118,
        Texas_NotifyGameResult = 4119,
        Texas_NotifyUpdatePots = 4120,
        Texas_NotifyUserPutAnte = 4121,
        Texas_NotifyUserInvalidAction = 4128,
        Texas_NotifySyncCardType = 4129,
        Texas_NotifyUserBuyin = 4130,
        Texas_NotifyStartMatch = 4131,
        Texas_NotifyMatchOver = 4132,
        Texas_NotifyBuyinHistory = 4133,
        Texas_NotifyGameLog = 4134,
        Texas_NotifyRegisterAutoAction = 4135,
        Texas_NotifyEnterInsuranceMode = 4136,
        Texas_NotifyUserBuyInsurance = 4137,
        Texas_NotifyUserEndBuyInsurance = 4144,
        Texas_NotifyUserInsurancePayment = 4145,
        Texas_NotifyUserDisableInsurance = 4146,
        Texas_NotifyAllSeatsInfo = 4147,
        Texas_NotifyMatchWillClose = 4148,
        Texas_NotifyExtendThinkingTimeResult = 4149,
        Texas_NotifyUpdateThinkingTime = 4150,
        Texas_NotifyChangeMuckOption = 4151,
        Texas_NotifyShowCardResp = 4152,
        Texas_NotifyChangeInsuranceNotifyOption = 4153,
        Texas_NotifyLikeAMatchResp = 4160,
        Texas_NotifyUnlikeAMatchResp = 4161,
        Texas_NotifyRespKickUser = 4162,
        Texas_NotifyProcessBuyinRequest = 4163,
        Texas_NotifyUpdateMatchCloseTime = 4164,
        Texas_NotifySyncInteractiveItemConfig = 4165,
        Texas_NotifySendInteractiveItemResp = 4166,
        Texas_NotifyUserSendInteractiveItem = 4167,
        Texas_NotifyUserUpdateMatchConfig = 4168,
        Texas_NotifyUserMatchCloseTimeRemind = 4169,
        Texas_NotifyRaiseBlind = 4176,
        Texas_NotifyUserOut = 4177,
        Texas_NotifySNGConfig = 4178,
        Texas_NotifySNGChipRank = 4179,
        Texas_NotifySNGMatchBoard = 4180,
        Texas_NotifyStartMatchResult = 4181,
        Texas_NotifyBuyDeposit = 4182,
        Texas_NotifyDepositChange = 4183,
        Texas_NotifyDepositOver = 4184,
        Texas_NotifyShowPublicCards = 4185,
        Texas_RespShowPublicCards = 4192,
        Texas_NotifyWhoShowPublicCards = 4193,
        Texas_NotifyShowAllHands = 4194,
        Texas_RespShowAllHands = 4195,
        Texas_RespRecordNum = 4196,
        Texas_RespPrepareAddDeposit = 4197,
        Texas_RespPrepareCheckout = 4198,
        Texas_RespCheckout = 4199,
        Texas_RespPrivateInfo = 4200,
        Texas_NotifyLogout = 4201,
        Texas_NotifyUesrNotJoinTable = 8193,
    }

    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public enum PBMainCmdShortSubCmd
    {
        Short_ReqJoinTable = 1,
        Short_ReqLeaveTable = 2,
        Short_ReqSit = 3,
        Short_ReqStand = 4,
        Short_ReqChipin = 5,
        Short_ReqTabelInfo = 6,
        Short_ReqShowCard = 7,
        Short_ReqChat = 8,
        Short_ReqBuyin = 9,
        Short_ReqStartMatch = 10,
        Short_ReqBuyinHistory = 11,
        Short_ReqGameLog = 12,
        Short_ReqRegisterAutoAction = 13,
        Short_ReqBuyInsurance = 14,
        Short_ReqCloseMatch = 15,
        Short_ReqExtendThinkingTime = 16,
        Short_ReqChangeMuckOption = 17,
        Short_ReqChangeInsuranceNotifyOption = 18,
        Short_ReqLikeAMatch = 19,
        Short_ReqUnlikeAMatch = 20,
        Short_ReqKickUser = 21,
        Short_ReqProcessBuyinRequest = 22,
        Short_ReqSendInteractiveItem = 23,
        Short_ReqSNGConfig = 24,
        Short_ReqSNGChipRank = 25,
        Short_ReqSNGMatchBoard = 32,
        Short_ReqBuyDeposit = 33,
        Short_ReqShowPublicCards = 34,
        Short_ReqShowAllHands = 35,
        Short_ReqRecordNum = 36,
        Short_ReqPrepareAddDeposit = 37,
        Short_ReqPrepareCheckout = 38,
        Short_ReqCheckout = 39,
        Short_ReqPrivateInfo = 40,
        Short_NotifyJoinTable = 4097,
        Short_NotifyLeaveTable = 4098,
        Short_NotifyUserSit = 4099,
        Short_NotifyUserStand = 4100,
        Short_NotifyStartChipin = 4101,
        Short_NotifyEndChipin = 4102,
        Short_NotifyTableInfo = 4103,
        Short_NotifyShowCard = 4104,
        Short_NotifyChat = 4105,
        Short_NotifyGameStart = 4112,
        Short_NotifyDealFlop = 4113,
        Short_NotifyDealTurn = 4114,
        Short_NotifyDealRiver = 4115,
        Short_NotifyStartDealCard = 4116,
        Short_NotifyDealHoleCard = 4117,
        Short_NotifySyncSeatInfo = 4118,
        Short_NotifyGameResult = 4119,
        Short_NotifyUpdatePots = 4120,
        Short_NotifyUserPutAnte = 4121,
        Short_NotifyUserInvalidAction = 4128,
        Short_NotifySyncCardType = 4129,
        Short_NotifyUserBuyin = 4130,
        Short_NotifyStartMatch = 4131,
        Short_NotifyMatchOver = 4132,
        Short_NotifyBuyinHistory = 4133,
        Short_NotifyGameLog = 4134,
        Short_NotifyRegisterAutoAction = 4135,
        Short_NotifyEnterInsuranceMode = 4136,
        Short_NotifyUserBuyInsurance = 4137,
        Short_NotifyUserEndBuyInsurance = 4144,
        Short_NotifyUserInsurancePayment = 4145,
        Short_NotifyUserDisableInsurance = 4146,
        Short_NotifyAllSeatsInfo = 4147,
        Short_NotifyMatchWillClose = 4148,
        Short_NotifyExtendThinkingTimeResult = 4149,
        Short_NotifyUpdateThinkingTime = 4150,
        Short_NotifyChangeMuckOption = 4151,
        Short_NotifyShowCardResp = 4152,
        Short_NotifyChangeInsuranceNotifyOption = 4153,
        Short_NotifyLikeAMatchResp = 4160,
        Short_NotifyUnlikeAMatchResp = 4161,
        Short_NotifyRespKickUser = 4162,
        Short_NotifyProcessBuyinRequest = 4163,
        Short_NotifyUpdateMatchCloseTime = 4164,
        Short_NotifySyncInteractiveItemConfig = 4165,
        Short_NotifySendInteractiveItemResp = 4166,
        Short_NotifyUserSendInteractiveItem = 4167,
        Short_NotifyUserUpdateMatchConfig = 4168,
        Short_NotifyUserMatchCloseTimeRemind = 4169,
        Short_NotifyRaiseBlind = 4176,
        Short_NotifyUserOut = 4177,
        Short_NotifySNGConfig = 4178,
        Short_NotifySNGChipRank = 4179,
        Short_NotifySNGMatchBoard = 4180,
        Short_NotifyStartMatchResult = 4181,
        Short_NotifyBuyDeposit = 4182,
        Short_NotifyDepositChange = 4183,
        Short_NotifyDepositOver = 4184,
        Short_NotifyShowPublicCards = 4185,
        Short_RespShowPublicCards = 4192,
        Short_NotifyWhoShowPublicCards = 4193,
        Short_NotifyShowAllHands = 4194,
        Short_RespShowAllHands = 4195,
        Short_RespRecordNum = 4196,
        Short_RespPrepareAddDeposit = 4197,
        Short_RespPrepareCheckout = 4198,
        Short_RespCheckout = 4199,
        Short_RespPrivateInfo = 4200,
        Short_NotifyLogout = 4201,
        Short_NotifyUesrNotJoinTable = 8193,
    }

    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public enum PBMainCmdMatchListSubCmd
    {
        ML_ReqMatchList = 1,
        ML_RespMatchList = 2,
        ML_ReqCreateMatch = 3,
        ML_RespCreateMatch = 4,
        ML_ReqMatchIndex = 5,
        ML_RespMatchIndex = 6,
        ML_ReqClubMatchList = 7,
        ML_RespClubMatchList = 8,
        ML_ReqQuickJoinMatch = 9,
        ML_RespQuickJoinMatch = 10,
        ML_ReqMatchListByGroup = 11,
        ML_RespMatchListByGroup = 12,
        ML_ReqJoinGroupMatch = 13,
        ML_RespJoinGroupMatch = 14,
        ML_ReqGetCreateMatchConfig = 15,
        ML_RespGetCreateMatchConfig = 16,
        ML_ReqCreateSNG = 17,
        ML_RespCreateSNG = 18,
        ML_ReqCreateShort = 19,
        ML_RespCreateShort = 20,
        ML_ReqFetchMsg = 4097,
        ML_RespFetchMsg = 4098,
    }

    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public enum PBMainCmdGLogSubCmd
    {
        GLog_ReqUserMatchRecord = 1,
        GLog_RespUserMatchRecord = 2,
        GLog_ReqMatchDetail = 3,
        GLog_RespMatchDetail = 4,
        GLog_ReqMatchLog = 5,
        GLog_RespMatchLog = 6,
        GLog_ReqFetchFavMatchLogs = 7,
        GLog_RespFetchFavMatchLogs = 8,
        GLog_ReqFavMatchLogDetail = 9,
        GLog_RespFavMatchLogDetail = 10,
        GLog_ReqDeleteFavMatchLog = 11,
        GLog_RespDeleteFavMatchLog = 12,
        GLog_ReqFavMatchLog = 13,
        GLog_RespFavMatchLog = 14,
        GLog_ReqQueryFavMatchCount = 15,
        GLog_RespQueryFavMatchCount = 16,
        GLog_ReqQueryUserGameData = 17,
        GLog_RespQueryUserGameData = 18,
        GLog_ReqClubMatchRecord = 19,
        GLog_ReqClubMatchSuperStat = 20,
        GLog_RespClubMatchSuperStat = 21,
        GLog_RespClubMatchRecord = 22,
        GLog_ReqUnionMatchRecord = 23,
        GLog_RespUnionMatchRecord = 24,
        GLog_ReqUnionMatchDetail = 25,
        GLog_RespUnionMatchDetail = 32,
        GLog_ReqUnionMatchSuperStat = 33,
        GLog_RespUnionMatchSuperStat = 34,
        GLog_ReqUnionMatchSummary = 35,
        GLog_RespUnionMatchSummary = 36,
        GLog_ReqClubMatchSummary = 37,
        GLog_RespClubMatchSummary = 38,
        GLog_UserPokerDataReq = 39,
        GLog_UserPokerDataResp = 40,
        GLog_KeepHandReq = 41,
        GLog_KeepHandResp = 48,
        GLog_FavoriteHandsReq = 49,
        GLog_FavoriteHandsResp = 50,
        GLog_ViewFavoriteHandReq = 51,
        GLog_ViewFavoriteHandResp = 52,
        GLog_ShowFavoriteHandsReq = 53,
        GLog_ShowFavoriteHandsResp = 54,
        GLog_ShowFavPublicCardsReq = 55,
        GLog_ShowFavPublicCardsResp = 56,
        GLog_FishHandResultReq = 57,
        GLog_FishHandResultResp = 64,
        GLog_FishHandStatReq = 65,
        GLog_FishHandStatResp = 66,
    }

    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public enum PBMainCmdNotifySubCmd
    {
        Notify_SyncNotification = 1,
        Notify_SyncNotificationOnLogin = 2,
        Notify_ReqFetchNotifys = 3,
        Notify_RespFetchNotifys = 4,
        Notify_ReqBulletin = 5,
        Notify_RespBulletin = 6,
    }

    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public enum PBMainCmdHunTexasSubCmd
    {
        HunTexas_ReqJoinTable = 1,
        HunTexas_ReqLeaveTable = 2,
        HunTexas_ReqSit = 3,
        HunTexas_ReqStand = 4,
        HunTexas_ReqTabelInfo = 5,
        HunTexas_ReqChipin = 6,
        HunTexas_ReqChat = 7,
        HunTexas_ReqHistory = 8,
        HunTexas_ReqOnlooker = 9,
        HunTexas_NotifyJoinTable = 4097,
        HunTexas_NotifyLeaveTable = 4098,
        HunTexas_NotifyUserSit = 4099,
        HunTexas_NotifyUserStand = 4100,
        HunTexas_NotifyTableInfo = 4101,
        HunTexas_NotifyUserChipin = 4102,
        HunTexas_SyncOtherChipin = 4103,
        HunTexas_NotifyPrepare = 4104,
        HunTexas_NotifyDealCard = 4105,
        HunTexas_NotifyStartBetting = 4112,
        HunTexas_NotifyOpenCard = 4113,
        HunTexas_NotifyPayBet = 4114,
        HunTexas_NotifyUserChat = 4115,
        HunTexas_SyncSeatUserChipin = 4116,
        HunTexas_SyncBonusPot = 4117,
        HunTexas_SyncSeatInfo = 4118,
        HunTexas_SyncPlayerNum = 4119,
        HunTexas_RespHistory = 4120,
        HunTexas_RespOnlooker = 4121,
        HunTexas_ReqQuickJoin = 8193,
        HunTexas_RespQuickJoin = 8194,
    }

    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public enum PBMainCmdChatSubCmd
    {
        Chat_RegisterChannelReq = 1,
        Chat_RegisterChannelResp = 2,
        Chat_UnRegisterChannelReq = 3,
        Chat_UnRegisterChannelResp = 4,
        Chat_SendChatReq = 5,
        Chat_SendChatResp = 6,
        Chat_SendChatPush = 7,
        Chat_SendInteractivePropReq = 8,
        Chat_SendInteractivePropResp = 9,
        Chat_SendInteractivePropPush = 10,
    }

    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public enum Poker
    {
        CmdLoginReq = 1,
        CmdLoginResp = 2,
        CmdLogoutReq = 3,
        CmdLogoutResp = 4,
        CmdPlayInfoReq = 5,
        CmdPlayInfoResp = 6,
        CmdSitdownReq = 7,
        CmdSitdownResp = 8,
        CmdStandupReq = 9,
        CmdStandupResp = 10,
        CmdActionReq = 11,
        CmdActionResp = 12,
        CmdShowHandsReq = 13,
        CmdShowHandsResp = 14,
        CmdBuyInsReq = 15,
        CmdBuyInsResp = 16,
        CmdSetLeaveStatusReq = 17,
        CmdSetLeaveStatusResp = 18,
        CmdHandHistoryReq = 19,
        CmdHandHistoryResp = 20,
        CmdGetOnlookerListReq = 21,
        CmdGetOnlookerListResp = 22,
        CmdShowPublicCardsReq = 23,
        CmdShowPublicCardsResp = 24,
        CmdShowAllHandsReq = 25,
        CmdShowAllHandsResp = 26,
        CmdGetRoomFeeReq = 27,
        CmdGetRoomFeeResp = 28,
        CmdExtendTimeReq = 29,
        CmdExtendTimeResp = 30,
        CmdKeepHistoryHandReq = 31,
        CmdKeepHistoryHandResp = 32,
        CmdGetPointsReq = 33,
        CmdGetPointsResp = 34,
        CmdLoadPoinstReq = 35,
        CmdLoadPointsResp = 36,
        CmdLoginPush = 4097,
        CmdLogoutPush = 4098,
        CmdSitdownPush = 4099,
        CmdStandupPush = 4100,
        CmdGameReadyPush = 4101,
        CmdGameStartPush = 4102,
        CmdAntePush = 4103,
        CmdDealPush = 4104,
        CmdStartActionPush = 4105,
        CmdActionPush = 4106,
        CmdRefundPush = 4107,
        CmdRoundEndPush = 4108,
        CmdFlopPush = 4109,
        CmdTurnPush = 4110,
        CmdRiverPush = 4111,
        CmdGameOverPush = 4112,
        CmdShowHandsPush = 4113,
        CmdPreShowHandsPush = 4114,
        CmdBuyinPush = 4115,
        CmdEnterInsPush = 4116,
        CmdStartBuyInsPush = 4117,
        CmdBuyInsPush = 4118,
        CmdPayInsPush = 4119,
        CmdDisableInsPush = 4120,
        CmdSetLeaveStatusPush = 4121,
        CmdCanShowPublicCardsPush = 4122,
        CmdWhoShowPublicCardsPush = 4123,
        CmdCanShowAllHandsPush = 4124,
        CmdBuyInCountdownPush = 4125,
        CmdExtendTimePush = 4126,
        CmdLuckyCardPush = 4127,
        CmdPointChangePush = 4128,
        CmdPreFaceCheckPush = 4129,
        CmdFaceCheckStartPush = 4130,
        CmdFaceCheckEndPush = 4131,
        CmdFaceCheckLeftChangePush = 4132,
        CmdFaceCheckCountdownPush = 4133,
    }

    [System.Serializable]
    [global::ProtoBuf.ProtoContract()]
    public enum MatchMgr
    {
        getMatchConfigReq = 1,
        getMatchConfigResp = 2,
        createMatchReq = 3,
        createMatchResp = 4,
        searchMatchReq = 5,
        searchMatchResp = 6,
        getMatchListReq = 7,
        getMatchListResp = 8,
        matchBalanceReq = 9,
        matchBalanceResp = 10,
        buyinReq = 11,
        buyinResp = 12,
        closeMatchReq = 13,
        closeMatchResp = 14,
        getRealtimeDataReq = 15,
        getRealtimeDataResp = 16,
        startMatchReq = 17,
        startMatchResp = 18,
        settlementDeTailReq = 19,
        settlementDeTailResp = 20,
        settlementReq = 21,
        settlementResp = 22,
        checkPenaltyReq = 23,
        checkPenaltyResp = 24,
        matchOverPush = 4097,
        settlementPush = 4098,
        closeMatchPush = 4099,
        closeMatchRemindPush = 4100,
        startMatchPush = 4101,
    }

}

#pragma warning restore CS1591, CS0612, CS3021
