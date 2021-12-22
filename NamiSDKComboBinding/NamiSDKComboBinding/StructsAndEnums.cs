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
}
