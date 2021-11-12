using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using pbcmd;
using UnityEngine;

public class PbcmdHelper : MonoBehaviour
{
    public static PbcmdHelper Instance;

    public const string localAccount = "LocalAccount";

    #region enums
    
    

    public enum PbSocketEvent
    {
        Timeout,
        Error,
    }

    public enum Lerpable
    {
        Location,
        Scale,
        Rotation,
        Color,
        Float,
        Double
    }

    public enum LerpSpace
    {
        Local,
        World,
        Screen
    }

    public enum Operator
    {
        Add,
        Subtract,
        Multiply,
        Divide,
    }

    public enum DeltaTimeType
    {
        DeltaTime,
        Fixed,
        Unscaled,
        FixedUnscaled,
        Capture,
        Maximum,
        MaximumParticle,
        Smooth
    }

    public enum LanguageType
    {
        ChineseSimplified,
        English
    }

    public enum ProcessPurpose
    {
        Login,
        Registration
    }

    public enum LoadingMode
    {
        Serializable,
        Json
    }

    public enum UrlDestination
    {
        CustomerService
    }

    public enum PanelHeadType
    {
        unknown,
        auto,
        iPhoneX
    }

    public enum ClientDeviceType
    {
        Android = 1,
        iOS = 2
    }

    public enum Channel
    {
        Official = 0,
        ClosedPayMethod = 100,
        ApplePackage = 1000
    }

    public enum CoinType
    {
        Time = 0,
        Poker = 1
    }

    public enum VerifType
    {
        PhoneRegistration = 1,
        PhoneLogin = 2,
        EmailRegistration = 3,
        EmailLogin = 4
    }

    public enum AuthType
    {
        Unknown = 0,
        Phone = 1,
        Email = 2
    }

    public enum EndPointOption
    {
        TestTest1,
        TestDev2,
        TestTest3
    }

    public enum GameType
    {
        Unknown = 0,
        Texas = 1,
        Short = 2,
        Fishing = 3,
        Omaha = 4
    }

    public enum SwitchTabStyle
    {
        None,
        ImageSwapSprite,
        ImageEnable
    }

    public enum SwitchTableContentStyle
    {
        Disable,
        Destroy,
        DontDestroy
    }

    public enum NlheLevel
    {
        Unknown,
        Micro,
        Low,
        Middle,
        High,
        HalfByOne
    }

    public enum ShortLevel
    {
        Unknown,
        Micro,
        Low,
        Middle,
        High
    }

    public enum OmahaLevel
    {
        Unknown,
        Micro,
        Low,
        Middle,
        High
    }

    public enum SortBy
    {
        None,
        Level,
        Players,
        Time,
        Club
    }

    public enum Gender
    {
        Unknown,
        Male,
        Female
    }

    public enum ClubMemberLevel
    {
        Owner = 100,
        Admin = 10,
        Member = 1
    }

    public enum CreateMatchCategory
    {
        Private = 1,
        Club = 2,
        Union = 3,
        SuperUnion = 4
    }

    public enum LeaveStatus
    {
        NORMAL = 0,
        TIMEOUT = 1,
        FORCEDLEAVE = 2,
        SETTLED = 3
    }

    public enum BlindType
    {
        DealerButton,
        SmallBlind,
        BigBlind
    }

    public enum Feature
    {
        ClubCanSee,
        Insurance,
        LuckyCard,
        Position
    }

    public enum SeatPosition
    {
        Top,
        Right,
        Bottom,
        Left
    }

    #endregion

    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }


    public PBCommParam getPBCommParam()
    {
        return new PBCommParam()
        {
            cid = (Application.platform == RuntimePlatform.IPhonePlayer)
                ? (uint) ClientDeviceType.Android
                : (uint) ClientDeviceType.iOS,
            uid = 0,
            token = "",
            version = Application.version,
            channel = (uint) Channel.Official,
            lang = 0,
            pkgName = Application.identifier,
            device = new PBDeviceInfo()
            {
                network = "PC",
                osType = Application.platform.ToString(),
                osVersion = SystemInfo.operatingSystem,
                deviceType = SystemInfo.deviceType.ToString(),
                imei = SystemInfo.deviceUniqueIdentifier,
                macAddr = GetMacAddress()
            }
        };
    }

    private static string GetMacAddress()
    {
        string physicalAddress = "";

        NetworkInterface[] nice = NetworkInterface.GetAllNetworkInterfaces();

        foreach (NetworkInterface adaper in nice)
        {
            //  Debug.Log(adaper.Description);

            if (adaper.Description == "en0")
            {
                physicalAddress = adaper.GetPhysicalAddress().ToString();
                break;
            }
            else
            {
                physicalAddress = adaper.GetPhysicalAddress().ToString();

                if (physicalAddress != "")
                {
                    break;
                }

                ;
            }
        }

        return physicalAddress;
    }
}