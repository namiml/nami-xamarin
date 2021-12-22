using ObjCRuntime;

namespace NamiML
{
    [Native]
    public enum NamiAnalyticsActionType : long
    {
        paywallRaise = 0,
        purchaseActivity = 1
    }

    [Native]
    public enum NamiAnalyticsPurchaseActivityType : long
    {
        NewPurchase = 0,
        Cancelled = 1,
        Resubscribe = 2,
        Restored = 3
    }

    [Native]
    public enum NamiExternalIdentifierType : long
    {
        Sha256 = 0,
        Uuid = 1
    }

    [Native]
    public enum NamiLogLevel : long
    {
        Error = 0,
        Warn = 1,
        Info = 2,
        Debug = 3
    }

    [Native]
    public enum NamiPlatformType : long
    {
        Other = 0,
        Android = 1,
        Apple = 2,
        Roku = 3,
        Web = 4
    }

    [Native]
    public enum NamiPurchaseResult : long
    {
        Purchased = 0,
        Renewed = 1,
        Deferred = 2,
        Retrying = 3,
        Canceled = 4,
        Blocked = 5,
        Failed = 6
    }

    [Native]
    public enum NamiPurchaseSource : long
    {
        External = 0,
        NamiPaywall = 1,
        Application = 2,
        Unknown = 3
    }

    [Native]
    public enum NamiPurchaseState : ulong
    {
        Pending = 0,
        Purchased = 1,
        Consumed = 2,
        Resubscribed = 3,
        Unsubscribed = 4,
        Deferred = 5,
        Failed = 6,
        Cancelled = 7,
        Unknown = 8
    }

    [Native]
    public enum NamiSKUType : long
    {
        Unknown = 0,
        One_time_purchase = 1,
        Subscription = 2
    }

    [Native]
    public enum SandboxAccelerationItemUnit : long
    {
        Hour = 0,
        Week = 1,
        Month = 2,
        SixMonth = 3,
        Year = 4
    }

    [Native]
    public enum StoreKitEnvironmentObjC : long
    {
        Production = 0,
        Sandbox = 1,
        NamiStoreKitBypass = 2,
        EnvironmentNotYetDetected = 3
    }

    [Native]
    public enum StoreKitStatusCodes : long
    {
        StatusOK = 0,
        UnreadableJSON = 21000,
        ReceiptMalformed = 21002,
        ReceiptAuthFailed = 21003,
        SharedSecretInvalid = 21004,
        ReceiptServerUnavailable = 21005,
        SubscriptionExpired = 21006,
        ReceiptFromSandboxEnvironment = 21007,
        ReceiptFromProdEnvironent = 21008,
        NamiError = 99999
    }
 
    public struct NamiLanguageCode
    {
        public const string AF = "af";
        public const string AR = "ar";
        public const string AR_DZ = "ar-dz";
        public const string AST = "ast";
        public const string AZ = "az";
        public const string BG = "bg";
        public const string BE = "be";
        public const string BN = "bn";
        public const string BR = "br";
        public const string BS = "bs";
        public const string CA = "ca";
        public const string CS = "cs";
        public const string CY = "cy";
        public const string DA = "da";
        public const string DE = "de";
        public const string DSB = "dsb";
        public const string EL = "el";
        public const string EN = "en";
        public const string EN_AU = "en-au";
        public const string EN_GB = "en-gb";
        public const string EO = "eo";
        public const string ES = "es";
        public const string ES_AR = "es-ar";
        public const string ES_CO = "es-co";
        public const string ES_MX = "es-mx";
        public const string ES_NI = "es-ni";
        public const string ES_VE = "es-ve";
        public const string ET = "et";
        public const string EU = "eu";
        public const string FA = "fa";
        public const string FI = "fi";
        public const string FR = "fr";
        public const string FY = "fy";
        public const string GA = "ga";
        public const string GD = "gd";
        public const string GL = "gl";
        public const string HE = "he";
        public const string HI = "hi";
        public const string HR = "hr";
        public const string HSB = "hsb";
        public const string HU = "hu";
        public const string HY = "hy";
        public const string IA = "ia";
        public const string ID = "id";
        public const string IG = "ig";
        public const string IO = "io";
        public const string IS = "is";
        public const string IT = "it";
        public const string JA = "ja";
        public const string KA = "ka";
        public const string KAB = "kab";
        public const string KK = "kk";
        public const string KM = "km";
        public const string KN = "kn";
        public const string KO = "ko";
        public const string KY = "ky";
        public const string LB = "lb";
        public const string LT = "lt";
        public const string LV = "lv";
        public const string MK = "mk";
        public const string ML = "ml";
        public const string MN = "mn";
        public const string MR = "mr";
        public const string MY = "my";
        public const string NB = "nb";
        public const string NE = "ne";
        public const string NL = "nl";
        public const string NN = "nn";
        public const string OS = "os";
        public const string PA = "pa";
        public const string PL = "pl";
        public const string PT = "pt";
        public const string PT_BR = "pt-br";
        public const string RO = "ro";
        public const string RU = "ru";
        public const string SK = "sk";
        public const string SL = "sl";
        public const string SQ = "sq";
        public const string SR = "sr";
        public const string SR_LATN = "sr-latn";
        public const string SV = "sv";
        public const string SW = "sw";
        public const string TA = "ta";
        public const string TE = "te";
        public const string TG = "tg";
        public const string TH = "th";
        public const string TK = "tk";
        public const string TR = "tr";
        public const string TT = "tt";
        public const string UDM = "udm";
        public const string UK = "uk";
        public const string UR = "ur";
        public const string UZ = "uz";
        public const string VI = "vi";
        public const string ZH_HANS = "zh-hans";
    }
}
