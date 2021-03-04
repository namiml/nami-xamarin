using System;
using CoreGraphics;
using Foundation;
using Messages;
using ObjCRuntime;
using StoreKit;
using UIKit;

namespace NamiML
{
	// @interface CustomerJourneyState : NSObject <NSCoding>
	[BaseType (typeof(NSObject), Name = "_TtC4Nami20CustomerJourneyState")]
	[DisableDefaultCtor]
	interface CustomerJourneyState : INSCoding
	{
		// @property (readonly, nonatomic) BOOL formerSubscriber;
		[Export("formerSubscriber")]
		bool FormerSubscriber();

		// @property (readonly, nonatomic) BOOL inGracePeriod;
		[Export("inGracePeriod")]
		bool InGracePeriod();

		// @property (readonly, nonatomic) BOOL inTrialPeriod;
		[Export("inTrialPeriod")]
		bool InTrialPeriod();

		// @property (readonly, nonatomic) BOOL inIntroOfferPeriod;
		[Export("inIntroOfferPeriod")]
		bool InIntroOfferPeriod();
	}


    // @interface Nami : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC4Nami4Nami")]
    [DisableDefaultCtor]
    interface Nami
    {
		// +(void)configureXamarinWithNamiConfig:(NamiConfiguration * _Nonnull)namiConfig;
		[Static]
		[Export("configureXamarinWithNamiConfig:")]
		void ConfigureWithNamiConfig(NamiConfiguration namiConfig);

		// +(void)registerNamiLoggerWithLogger:(id<NamiLoggerClient> _Nonnull)logger;
		[Static]
		[Export("registerNamiLoggerWithLogger:")]
		void RegisterNamiLoggerWithLogger(NamiLoggerClient logger);

		// +(void)doConfigBasedWorkWithWorker:(void (^ _Nonnull)(void))worker;
		[Static]
		[Export("doConfigBasedWorkWithWorker:")]
		void DoConfigBasedWorkWithWorker(Action worker);

		// +(void)setExternalIdentifierWithExternalIdentifier:(NSString * _Nullable)externalIdentifier type:(enum NamiExternalIdentifierType)type;
		[Static]
		[Export("setExternalIdentifierWithExternalIdentifier:type:")]
		void SetExternalIdentifier([NullAllowed] string externalIdentifier, NamiExternalIdentifierType type);

		// +(NSString * _Nullable)getExternalIdentifier __attribute__((warn_unused_result("")));
		[Static]
		[NullAllowed, Export("getExternalIdentifier")]
		string GetExternalIdentifier();

		// +(void)clearExternalIdentifier;
		[Static]
		[Export("clearExternalIdentifier")]
		void ClearExternalIdentifier();

		// +(void)setLogLevel:(enum NamiLogLevel)logLevel;
		[Static]
		[Export("setLogLevel:")]
		void SetLogLevel(NamiLogLevel logLevel);
	}

    // @interface NamiAnalyticsKeys : NSObject
    [BaseType (typeof(NSObject), Name = "_TtC4Nami17NamiAnalyticsKeys")]
	interface NamiAnalyticsKeys
	{
	}


	// @interface NamiCommand : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC4Nami11NamiCommand")]
	interface NamiCommand
	{
		// +(void)performQuery:(NSString * _Nonnull)queryString callback:(void (^ _Nonnull)(NSArray * _Nonnull))callback;
		[Static]
		[Export ("performQuery:callback:")]
		void PerformQuery (string queryString, Action<NSArray> callback);

		// +(void)performCommands:(NSArray<NSString *> * _Nonnull)commands;
		[Static]
		[Export ("performCommands:")]
		void PerformCommands (string[] commands);

		// +(void)performCommand:(NSString * _Nonnull)commandString;
		[Static]
		[Export ("performCommand:")]
		void PerformCommand (string commandString);
	}

	// @interface NamiConfiguration : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC4Nami17NamiConfiguration")]
	[DisableDefaultCtor]
	interface NamiConfiguration
	{
		// +(NamiConfiguration * _Nonnull)configurationForAppPlatformID:(NSString * _Nonnull)appPlatformID __attribute__((warn_unused_result("")));
		[Static]
		[Export ("configurationForAppPlatformID:")]
		NamiConfiguration ConfigurationForAppPlatformID (string appPlatformID);

		// @property (readonly, copy, nonatomic) NSString * _Nonnull appPlatformID;
		[Export ("appPlatformID")]
		string AppPlatformID { get; }

		// @property (nonatomic) BOOL passiveMode;
		[Export ("passiveMode")]
		bool PassiveMode { get; set; }

		// @property (nonatomic) BOOL applicationHandlesTransactions;
		[Export ("applicationHandlesTransactions")]
		bool ApplicationHandlesTransactions { get; set; }

		// @property (nonatomic) enum NamiLogLevel logLevel;
		[Export ("logLevel", ArgumentSemantic.Assign)]
		NamiLogLevel LogLevel { get; set; }

		// @property (nonatomic) BOOL bypassStore;
		[Export ("bypassStore")]
		bool BypassStore { get; set; }

		// @property (nonatomic) BOOL developmentMode;
		[Export ("developmentMode")]
		bool DevelopmentMode { get; set; }

		// @property (copy, nonatomic) NSArray<NSString *> * _Nonnull namiCommands;
		[Export ("namiCommands", ArgumentSemantic.Copy)]
		string[] NamiCommands { get; set; }
	}

	// @interface NamiCustomerManager : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC4Nami19NamiCustomerManager")]
	interface NamiCustomerManager
	{
		// +(CustomerJourneyState * _Nullable)currentCustomerJourneyState __attribute__((warn_unused_result("")));
		[Static]
		[NullAllowed, Export("currentCustomerJourneyState")]
		CustomerJourneyState CurrentCustomerJourneyState { get; }
	}

	// @interface NamiEntitlement : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC4Nami15NamiEntitlement")]
	[DisableDefaultCtor]
	interface NamiEntitlement : INativeObject
	{
		// @property (copy, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export ("name")]
		string Name { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable desc;
		[NullAllowed, Export ("desc")]
		string Desc { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable namiID;
		[NullAllowed, Export ("namiID")]
		string NamiID { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull referenceID;
		[Export ("referenceID")]
		string ReferenceID { get; set; }

		// @property (copy, nonatomic) NSArray<NamiSKU *> * _Nonnull relatedSKUs;
		[Export ("relatedSKUs", ArgumentSemantic.Copy)]
		NamiSKU[] RelatedSKUs { get; set; }

		// @property (copy, nonatomic) NSArray<NamiSKU *> * _Nonnull purchasedSKUs;
		[Export ("purchasedSKUs", ArgumentSemantic.Copy)]
		NamiSKU[] PurchasedSKUs { get; set; }

		// @property (copy, nonatomic) NSArray<NamiPurchase *> * _Nonnull activePurchases;
		[Export ("activePurchases", ArgumentSemantic.Copy)]
		NamiPurchase[] ActivePurchases { get; set; }
	}

	// @interface NamiEntitlementManager : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC4Nami22NamiEntitlementManager")]
	interface NamiEntitlementManager
    {
		// +(NSArray<NamiEntitlement *> * _Nonnull)getEntitlements __attribute__((warn_unused_result("")));
		[Static]
		[Export("getEntitlements")]
		NamiEntitlement[] GetEntitlements();

		// +(NSArray<NamiEntitlement *> * _Nonnull)activeEntitlements __attribute__((warn_unused_result("")));
		[Static]
		[Export("activeEntitlements")]
		NamiEntitlement[] ActiveEntitlements();

		// +(BOOL)isEntitlementActive:(NSString * _Nonnull)referenceID __attribute__((warn_unused_result("")));
		[Static]
		[Export("isEntitlementActive:")]
		bool IsEntitlementActive(string referenceID);

		// +(void)setEntitlements:(NSArray<NamiEntitlementSetter *> * _Nonnull)entitlements;
		[Static]
		[Export("setEntitlements:")]
		void SetEntitlements(NamiEntitlementSetter[] entitlements);

		// +(void)clearAllEntitlements;
		[Static]
		[Export("clearAllEntitlements")]
		void ClearAllEntitlements();

		// +(void)registerEntitlementsChangedHandler:(void (^ _Nullable)(NSArray<NamiEntitlement *> * _Nonnull))changeHandler;
		[Static]
		[Export("registerEntitlementsChangedHandler:")]
		void RegisterEntitlementsChangedHandler([NullAllowed] Action<NSArray<NamiEntitlement>> changeHandler);
	}

	// @interface NamiEntitlementSetter : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC4Nami21NamiEntitlementSetter")]
	[DisableDefaultCtor]
	interface NamiEntitlementSetter : INativeObject
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull referenceID;
		[Export ("referenceID")]
		string ReferenceID { get; }

		// @property (copy, nonatomic) NSString * _Nullable purchasedSKUid;
		[NullAllowed, Export ("purchasedSKUid")]
		string PurchasedSKUid { get; set; }

		// @property (copy, nonatomic) NSDate * _Nullable expires;
		[NullAllowed, Export ("expires", ArgumentSemantic.Copy)]
		NSDate Expires { get; set; }

		// @property (nonatomic) enum NamiPlatformType platform;
		[Export ("platform", ArgumentSemantic.Assign)]
		NamiPlatformType Platform { get; set; }

		// -(instancetype _Nonnull)initWithId:(NSString * _Nonnull)id;
		[Export ("initWithId:")]
		IntPtr Constructor (string id);

		// -(instancetype _Nonnull)initWithId:(NSString * _Nonnull)id platform:(enum NamiPlatformType)platform;
		[Export ("initWithId:platform:")]
		IntPtr Constructor (string id, NamiPlatformType platform);

		// -(instancetype _Nonnull)initWithId:(NSString * _Nonnull)id platform:(enum NamiPlatformType)platform purchasedSKUid:(NSString * _Nullable)purchasedSKUid expires:(NSDate * _Nullable)expires __attribute__((objc_designated_initializer));
		[Export ("initWithId:platform:purchasedSKUid:expires:")]
		[DesignatedInitializer]
		IntPtr Constructor (string id, NamiPlatformType platform, [NullAllowed] string purchasedSKUid, [NullAllowed] NSDate expires);
	}

	// @interface NamiExtensionManager : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC4Nami20NamiExtensionManager")]
	interface NamiExtensionManager
	{
		// @property (nonatomic, strong, class) NamiExtensionManager * _Nonnull shared;
		[Static]
		[Export ("shared", ArgumentSemantic.Strong)]
		NamiExtensionManager Shared { get; set; }

		// @property (nonatomic) BOOL requestFullScreenPaywalls;
		[Export ("requestFullScreenPaywalls")]
		bool RequestFullScreenPaywalls { get; set; }

		// -(void)startupNamiFromMessageExtensionWithMessageViewController:(MSMessagesAppViewController * _Nonnull)messageViewController applicationGroupName:(NSString * _Nullable)applicationGroupName;
		[Export ("startupNamiFromMessageExtensionWithMessageViewController:applicationGroupName:")]
		void StartupNamiFromMessageExtensionWithMessageViewController (MSMessagesAppViewController messageViewController, [NullAllowed] string applicationGroupName);

		// -(void)extensionDidResign;
		[Export ("extensionDidResign")]
		void ExtensionDidResign ();
	}

	// @protocol NamiLoggerClient <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol (Name = "_TtP4Nami16NamiLoggerClient_")]
	[BaseType (typeof(NSObject), Name = "_TtP4Nami16NamiLoggerClient_")]
	interface NamiLoggerClient
	{
		// @required -(void)logHTTPWithRequest:(NSURLRequest * _Nonnull)request response:(NSHTTPURLResponse * _Nonnull)response responseData:(NSData * _Nullable)responseData message:(NSString * _Nonnull)message;
		[Abstract]
		[Export ("logHTTPWithRequest:response:responseData:message:")]
		void LogHTTPWithRequest (NSUrlRequest request, NSHttpUrlResponse response, [NullAllowed] NSData responseData, string message);

		// @required -(void)logMessage:(NSString * _Nonnull)message;
		[Abstract]
		[Export ("logMessage:")]
		void LogMessage (string message);
	}

	// @interface NamiMLManager : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC4Nami13NamiMLManager")]
	interface NamiMLManager
	{
		// +(void)enterCoreContentWithLabels:(NSArray<NSString *> * _Nonnull)labels;
		[Static]
		[Export("enterCoreContentWithLabels:")]
		void EnterCoreContentWithLabels(string[] labels);

		// +(void)enterCoreContentWithLabel:(NSString * _Nonnull)label;
		[Static]
		[Export("enterCoreContentWithLabel:")]
		void EnterCoreContentWithLabel(string label);

		// +(void)exitCoreContentWithLabels:(NSArray<NSString *> * _Nonnull)labels;
		[Static]
		[Export("exitCoreContentWithLabels:")]
		void ExitCoreContentWithLabels(string[] labels);

		// +(void)exitCoreContentWithLabel:(NSString * _Nonnull)label;
		[Static]
		[Export("exitCoreContentWithLabel:")]
		void ExitCoreContentWithLabel(string label);

		// +(void)coreActionWithLabel:(NSString * _Nonnull)label;
		[Static]
		[Export("coreActionWithLabel:")]
		void CoreActionWithLabel(string label);
	}

	// @interface NamiPaywall : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC4Nami11NamiPaywall")]
	[DisableDefaultCtor]
	interface NamiPaywall : INativeObject
	{
		// @property (copy, nonatomic) NSString * _Nonnull paywallID;
		[Export ("paywallID")]
		string PaywallID { get; set; }

		// @property (copy, nonatomic) NSDictionary<NSString *,id> * _Nonnull namiPaywallInfoDict;
		[Export ("namiPaywallInfoDict", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> NamiPaywallInfoDict { get; set; }

		// @property (nonatomic, strong) UIImage * _Nullable backgroundImage;
		[NullAllowed, Export ("backgroundImage", ArgumentSemantic.Strong)]
		UIImage BackgroundImage { get; set; }

		// @property (readonly, nonatomic, strong) PaywallStyleData * _Nonnull styleData;
		[Export("styleData", ArgumentSemantic.Strong)]
		PaywallStyleData StyleData { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull developerPaywallID;
		[Export ("developerPaywallID")]
		string DeveloperPaywallID { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull title;
		[Export ("title")]
		string Title { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull body;
		[Export ("body")]
		string Body { get; }
	}

	// @interface NamiPaywallManager : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC4Nami18NamiPaywallManager")]
	//[DisableDefaultCtor]
	interface NamiPaywallManager
	{
		// +(void)paywallImpressionWithDeveloperID:(NSString * _Nonnull)developerID;
		[Static]
		[Export("paywallImpressionWithDeveloperID:")]
		void PaywallImpressionWithDeveloperID(string developerID);

		// +(void)presentNamiPaywallFromVC:(UIViewController * _Nullable)fromVC products:(NSArray<NamiSKU *> * _Nullable)products paywallMetadata:(NamiPaywall * _Nonnull)paywallMetadata backgroundImage:(UIImage * _Nullable)backgroundImage forNami:(BOOL)forNami;
		[Static]
		[Export("presentNamiPaywallFromVC:products:paywallMetadata:backgroundImage:forNami:")]
		void PresentNamiPaywallFromVC([NullAllowed] UIViewController fromVC, [NullAllowed] NamiSKU[] products, NamiPaywall paywallMetadata, [NullAllowed] UIImage backgroundImage, bool forNami);

		// +(void)registerAllowAutoRaisePaywallHandler:(BOOL (^ _Nullable)(void))allowAutoRaisePaywallHandler;
		[Static]
		[Export("registerAllowAutoRaisePaywallHandler:")]
		void RegisterAllowAutoRaisePaywallHandler([NullAllowed] Func<bool> allowAutoRaisePaywallHandler);

		//+(void) fetchCustomPaywallMetaForDeveloperID:(NSString* _Nonnull) developerPaywallID :(void (^ _Nonnull)(NSArray<NamiSKU*>* _Nullable, NSString* _Nonnull, NamiPaywall* _Nullable))namiCustomPaywallHandler;
		[Static]
		[Export("fetchCustomPaywallMetaForDeveloperID::")]
		void FetchCustomPaywallMetaForDeveloperID(string developerPaywallID, Action<NSArray<NamiSKU>, NSString, NamiPaywall> namiCustomPaywallHandler);

		// +(void)registerPaywallRaiseHandler:(void (^ _Nullable)(UIViewController * _Nullable, NSArray<NamiSKU *> * _Nullable, NSString * _Nonnull, NamiPaywall * _Nonnull))applicationPaywallHandler;
		[Static]
		[Export("registerPaywallRaiseHandler:")]
		void RegisterPaywallRaiseHandler([NullAllowed] Action<UIViewController, NSArray<NamiSKU>, NSString, NamiPaywall> applicationPaywallHandler);

		// +(void)registerSignInHandler:(void (^ _Nullable)(UIViewController * _Nullable, NSString * _Nonnull, NamiPaywall * _Nonnull))applicationSignInHandler;
		[Static]
		[Export("registerSignInHandler:")]
		void RegisterSignInHandler([NullAllowed] Action<UIViewController, NSString, NamiPaywall> applicationSignInHandler);

		// +(void)registerBlockingPaywallClosedHandler:(void (^ _Nullable)(void))blockingPaywallClosedHandler;
		[Static]
		[Export("registerBlockingPaywallClosedHandler:")]
		void RegisterBlockingPaywallClosedHandler([NullAllowed] Action blockingPaywallClosedHandler);		

		// +(BOOL)canRaisePaywall __attribute__((warn_unused_result("")));
		[Static]
		[Export("canRaisePaywall")]
		bool CanRaisePaywall { get; }

		// +(void)raisePaywallFromVC:(UIViewController * _Nullable)fromVC;
		[Static]
		[Export("raisePaywallFromVC:")]
		void RaisePaywallFromVC([NullAllowed] UIViewController fromVC);

		// +(void)raisePaywallWithDeveloperPaywallID:(NSString * _Nonnull)developerPaywallID fromVC:(UIViewController * _Nullable)fromVC;
		[Static]
		[Export("raisePaywallWithDeveloperPaywallID:fromVC:")]
		void RaisePaywallWithDeveloperPaywallID(string developerPaywallID, [NullAllowed] UIViewController fromVC);

		// +(void)dismissNamiPaywallIfOpenWithAnimated:(BOOL)animated completion:(void (^ _Nonnull)(void))completion;
		[Static]
		[Export("dismissNamiPaywallIfOpenWithAnimated:completion:")]
		void DismissNamiPaywallIfOpen(bool animated, Action completion);
	}

	// @interface NamiPurchase : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC4Nami12NamiPurchase")]
	[DisableDefaultCtor]
	interface NamiPurchase : INativeObject
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull skuID;
		[Export("skuID")]
		string SkuID();
			// @property (copy, nonatomic) NSString * _Nullable transactionIdentifier;
		[NullAllowed, Export ("transactionIdentifier")]
		string TransactionIdentifier { get; set; }

		// @property (copy, nonatomic) NSDate * _Nonnull purchaseInitiatedTimestamp;
		[Export ("purchaseInitiatedTimestamp", ArgumentSemantic.Copy)]
		NSDate PurchaseInitiatedTimestamp { get; set; }

		// @property (copy, nonatomic) NSDate * _Nullable expires;
		[NullAllowed, Export ("expires", ArgumentSemantic.Copy)]
		NSDate Expires { get; set; }

        // @property (nonatomic) enum NamiPurchaseSource purchaseSource;
        [Export("purchaseSource", ArgumentSemantic.Assign)]
        NamiPurchaseSource PurchaseSource { get; set; }

        // @property (nonatomic) NSInteger consumptionCount;
        [Export ("consumptionCount")]
		nint ConsumptionCount { get; set; }

		// @property (readonly, copy, nonatomic) NSArray<NamiEntitlement *> * _Nonnull entitlementsGranted;
		[Export ("entitlementsGranted", ArgumentSemantic.Copy)]
		NamiEntitlement[] EntitlementsGranted { get; }
	}

	// @interface NamiPurchaseManager : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC4Nami19NamiPurchaseManager")]
	interface NamiPurchaseManager
    {
		 //+(void) buySKU:(NamiSKU* _Nonnull) sku fromPaywall:(NamiPaywall* _Nullable) paywall responseHandler:(void (^ _Nonnull)(NSArray<NamiPurchase*>* _Nonnull, enum NamiPurchaseState, NSError* _Nullable))responseHandler;
		[Static]
        [Export("buySKU:fromPaywall:responseHandler:")]
        void BuySKU(NamiSKU sku, [NullAllowed] NamiPaywall paywall, Action<NSArray<NamiPurchase>, NamiPurchaseState, NSError> responseHandler);

        // +(void)clearBypassStorePurchases;
        [Static]
		[Export ("clearBypassStorePurchases")]
		void ClearBypassStorePurchases ();

		// +(void)clearAndCheckRestoreAllPurchases;
		[Static]
		[Export("clearAndCheckRestoreAllPurchases")]
		void ClearAndCheckRestoreAllPurchases();

		// +(BOOL)isSKUIDPurchased:(NSString * _Nonnull)skuID __attribute__((warn_unused_result("")));
		[Static]
		[Export ("isSKUIDPurchased:")]
		bool IsSKUIDPurchased (string skuID);

		// +(BOOL)anySKUIDPurchased:(NSArray<NSString *> * _Nonnull)skuIDs __attribute__((warn_unused_result("")));
		[Static]
		[Export ("anySKUIDPurchased:")]
		bool AnySKUIDPurchased (string[] skuIDs);

		// +(NamiPurchase * _Nullable)currentPurchaseRecordsForSKUWithSkuID:(NSString * _Nonnull)skuID __attribute__((warn_unused_result("")));
		[Static]
		[Export ("currentPurchaseRecordsForSKUWithSkuID:")]
		[return: NullAllowed]
		NamiPurchase CurrentPurchaseRecordsForSKUWithSkuID (string skuID);

        // +(void)skusForSKUIDsWithSkuIDs:(NSArray<NSString *> * _Nonnull)skuIDs productHandler:(void (^ _Nonnull)(BOOL, NSArray<NamiSKU *> * _Nullable, NSArray<NSString *> * _Nullable, NSError * _Nullable))productHandler;
        [Static]
        [Export("skusForSKUIDsWithSkuIDs:productHandler:")]
        void SkusForSKUIDsWithSkuIDs(string[] skuIDs, Action<bool, NSArray<NamiSKU>, NSArray<NSString>, NSError> productHandler);

        // +(NSArray<NamiPurchase *> * _Nonnull)allPurchases __attribute__((warn_unused_result("")));
        [Static]
		[Export ("allPurchases")]
		NamiPurchase[] AllPurchases { get; }

        // +(void)registerWithPurchasesChangedHandler:(void (^ _Nullable)(NSArray<NamiPurchase *> * _Nonnull, enum NamiPurchaseState, NSError * _Nullable))changeHandler;
        [Static]
        [Export("registerPurchasesChangedHandler:")]
        void RegisterPurchasesChangedHandler([NullAllowed] Action<NSArray<NamiPurchase>, NamiPurchaseState, NSError> changeHandler);

        // +(void)restorePurchasesWithHandler:(void (^ _Nonnull)(BOOL, NSError * _Nullable))handler;
        [Static]
		[Export ("restorePurchasesWithHandler:")]
		void RestorePurchasesWithHandler (Action<bool, NSError> handler);

		// +(void)consumePurchasedSKUWithSkuID:(NSString * _Nonnull)skuID;
		[Static]
		[Export ("consumePurchasedSKUWithSkuID:")]
		void ConsumePurchasedSKUWithSkuID (string skuID);

		// +(void)presentCodeRedemptionSheet;
		[Static]
		[Export("presentCodeRedemptionSheet")]
		void PresentCodeRedemptionSheet();
	}

	// @interface NamiReceiptIAPWrapper : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC4Nami21NamiReceiptIAPWrapper")]
	[DisableDefaultCtor]
	interface NamiReceiptIAPWrapper
	{
		// @property (copy, nonatomic) NSDictionary<NSString *,id> * _Nonnull iapJSONDict;
		[Export ("iapJSONDict", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> IapJSONDict { get; set; }
	}

	// @interface NamiReceiptWrapper : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC4Nami18NamiReceiptWrapper")]
	[DisableDefaultCtor]
	interface NamiReceiptWrapper
	{
		// @property (copy, nonatomic) NSDictionary<NSString *,id> * _Nonnull receiptJSONDict;
		[Export ("receiptJSONDict", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> ReceiptJSONDict { get; set; }

		// @property (readonly, nonatomic) BOOL hasReceiptData;
		[Export ("hasReceiptData")]
		bool HasReceiptData { get; }

		// @property (readonly, nonatomic) NSInteger statusCode;
		[Export ("statusCode")]
		nint StatusCode { get; }

		// @property (readonly, nonatomic) enum StoreKitEnvironmentObjC storeKitEnvironmentObjC;
		[Export ("storeKitEnvironmentObjC")]
		StoreKitEnvironmentObjC StoreKitEnvironmentObjC { get; }

		// -(NSString * _Nullable)originalApplicationVersion __attribute__((warn_unused_result("")));
		[NullAllowed, Export ("originalApplicationVersion")]
		string OriginalApplicationVersion { get; }

		// -(NSArray<NSDictionary<NSString *,id> *> * _Nullable)fullIAPReceiptInfoDict __attribute__((warn_unused_result("")));
		[NullAllowed, Export ("fullIAPReceiptInfoDict")]
		NSDictionary<NSString, NSObject>[] FullIAPReceiptInfoDict { get; }

		// -(NSArray<NSDictionary<NSString *,id> *> * _Nullable)latestReceiptInfoDict __attribute__((warn_unused_result("")));
		[NullAllowed, Export ("latestReceiptInfoDict")]
		NSDictionary<NSString, NSObject>[] LatestReceiptInfoDict { get; }

		// -(NSArray<NSDictionary<NSString *,id> *> * _Nullable)inAppItems __attribute__((warn_unused_result("")));
		[NullAllowed, Export ("inAppItems")]
		NSDictionary<NSString, NSObject>[] InAppItems { get; }

		// -(NSArray<NamiReceiptIAPWrapper *> * _Nonnull)sortedIAPItemsFromDate:(NSDate * _Nonnull)fromDate __attribute__((warn_unused_result("")));
		[Export ("sortedIAPItemsFromDate:")]
		NamiReceiptIAPWrapper[] SortedIAPItemsFromDate (NSDate fromDate);
	}

	// @interface NamiSKU : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC4Nami7NamiSKU")]
	[DisableDefaultCtor]
	interface NamiSKU : INativeObject
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull platformID;
		[Export ("platformID")]
		string PlatformID { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull skuID;
		[Export ("skuID")]
		string SkuID { get; }

		// @property (copy, nonatomic) NSString * _Nonnull storeID;
		[Export ("storeID")]
		string StoreID { get; set; }

		// @property (nonatomic, strong) SKProduct * _Nullable product;
		[NullAllowed, Export ("product", ArgumentSemantic.Strong)]
		SKProduct Product { get; set; }

		// @property (copy, nonatomic) NSDictionary<NSString *,id> * _Nullable productMetadata;
		[NullAllowed, Export ("productMetadata", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> ProductMetadata { get; set; }

		// @property (nonatomic) enum NamiPlatformType platform;
		[Export ("platform", ArgumentSemantic.Assign)]
		NamiPlatformType Platform { get; set; }

		// @property (nonatomic) enum NamiSKUType type;
		[Export ("type", ArgumentSemantic.Assign)]
		NamiSKUType Type { get; set; }
	}

	// @interface NamiServerConfiguration : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC4Nami23NamiServerConfiguration")]
	interface NamiServerConfiguration
	{
		// @property (nonatomic, class) BOOL mlEnabled;
		[Static]
		[Export ("mlEnabled")]
		bool MlEnabled { get; set; }

		// @property (nonatomic, class) BOOL analyticsEnabled;
		[Static]
		[Export ("analyticsEnabled")]
		bool AnalyticsEnabled { get; set; }
	}

	// @interface NamiStoreKitHelper : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC4Nami18NamiStoreKitHelper")]
	[DisableDefaultCtor]
	interface NamiStoreKitHelper
	{
		// @property (readonly, nonatomic, strong, class) NamiStoreKitHelper * _Nonnull shared;
		[Static]
		[Export ("shared", ArgumentSemantic.Strong)]
		NamiStoreKitHelper Shared { get; }

		// @property (readonly, copy, nonatomic, class) NSString * _Nonnull noProductIdentifier;
		[Static]
		[Export ("noProductIdentifier")]
		string NoProductIdentifier { get; }

		// @property (readonly, nonatomic) BOOL bypassStoreKit;
		[Export ("bypassStoreKit")]
		bool BypassStoreKit { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull objCStoreKitEnvironment;
		[Export ("objCStoreKitEnvironment")]
		string ObjCStoreKitEnvironment { get; }

		// -(void)verifyReceiptWithCompletion:(void (^ _Nonnull)(NamiReceiptWrapper * _Nullable))completion;
		[Export ("verifyReceiptWithCompletion:")]
		void VerifyReceiptWithCompletion (Action<NamiReceiptWrapper> completion);

        // -(void)productsForProductIdentifiersWithProductIDs:(NSArray<NSString *> * _Nonnull)productIDs productHandler:(void (^ _Nonnull)(BOOL, NSArray<NamiSKU *> * _Nullable, NSArray<NSString *> * _Nullable, NSError * _Nullable))productHandler;
        [Export("productsForProductIdentifiersWithProductIDs:productHandler:")]
        void ProductsForProductIdentifiersWithProductIDs(string[] productIDs, Action<bool, NSArray<NamiSKU>, NSArray<NSString>, NSError> productHandler);

        // -(void)registerWithPurchasesChangedHandler:(void (^ _Nullable)(NSArray<NamiPurchase *> * _Nonnull, enum NamiPurchaseState, NSError * _Nullable))changeHandler;
        [Export("registerWithPurchasesChangedHandler:")]
        void RegisterWithPurchasesChangedHandler([NullAllowed] Action<NSArray<NamiPurchase>, NamiPurchaseState, NSError> changeHandler);

        // +(NSData * _Nullable)appReceiptData __attribute__((warn_unused_result("")));
        [Static]
		[NullAllowed, Export ("appReceiptData")]
		NSData AppReceiptData { get; }

		// +(NSDictionary<NSString *,id> * _Nonnull)appReceiptJSON __attribute__((warn_unused_result("")));
		[Static]
		[Export ("appReceiptJSON")]
		NSDictionary<NSString, NSObject> AppReceiptJSON { get; }
	}

	// @interface NamiVersionUtils : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC4Nami16NamiVersionUtils")]
	interface NamiVersionUtils
	{
		// +(BOOL)isOriginalVersion:(NSString * _Nonnull)originalVersion lowerThanVersion:(NSString * _Nonnull)otherVersion __attribute__((warn_unused_result("")));
		[Static]
		[Export ("isOriginalVersion:lowerThanVersion:")]
		bool IsOriginalVersion (string originalVersion, string otherVersion);

		// +(NSString * _Nonnull)currentAppVersion __attribute__((warn_unused_result("")));
		[Static]
		[Export ("currentAppVersion")]
		string CurrentAppVersion { get; }
	}

	// @interface PaywallLifecycleNotifications : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC4Nami29PaywallLifecycleNotifications")]
	interface PaywallLifecycleNotifications
	{
		// @property (readonly, nonatomic, class) NSNotificationName _Nonnull NamiPaywallWillAppearNotification;
		[Static]
		[Export ("NamiPaywallWillAppearNotification")]
		string NamiPaywallWillAppearNotification { get; }

		// @property (readonly, nonatomic, class) NSNotificationName _Nonnull NamiPaywallDidDismissNoPurchaseNotification;
		[Static]
		[Export ("NamiPaywallDidDismissNoPurchaseNotification")]
		string NamiPaywallDidDismissNoPurchaseNotification { get; }

		// @property (readonly, nonatomic, class) NSNotificationName _Nonnull NamiPaywallDidDismissAfterPurchaseNotification;
		[Static]
		[Export ("NamiPaywallDidDismissAfterPurchaseNotification")]
		string NamiPaywallDidDismissAfterPurchaseNotification { get; }
	}

	// @interface PaywallStyleData : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC4Nami16PaywallStyleData")]
	interface PaywallStyleData
	{
		// @property (nonatomic, strong) UIColor * _Nonnull backgroundColor;
		[Export("backgroundColor", ArgumentSemantic.Strong)]
	UIColor BackgroundColor { get; set; }

	// @property (nonatomic) CGFloat bodyFontSize;
	[Export("bodyFontSize")]
	nfloat BodyFontSize { get; set; }

	// @property (nonatomic, strong) UIColor * _Nonnull bodyTextColor;
	[Export("bodyTextColor", ArgumentSemantic.Strong)]
	UIColor BodyTextColor { get; set; }

	// @property (nonatomic, strong) UIColor * _Nonnull bodyShadowColor;
	[Export("bodyShadowColor", ArgumentSemantic.Strong)]
	UIColor BodyShadowColor { get; set; }

	// @property (nonatomic) CGFloat bodyShadowRadius;
	[Export("bodyShadowRadius")]
	nfloat BodyShadowRadius { get; set; }

	// @property (nonatomic) CGFloat titleFontSize;
	[Export("titleFontSize")]
	nfloat TitleFontSize { get; set; }

	// @property (nonatomic, strong) UIColor * _Nonnull titleTextColor;
	[Export("titleTextColor", ArgumentSemantic.Strong)]
	UIColor TitleTextColor { get; set; }

	// @property (nonatomic, strong) UIColor * _Nonnull titleShadowColor;
	[Export("titleShadowColor", ArgumentSemantic.Strong)]
	UIColor TitleShadowColor { get; set; }

	// @property (nonatomic) CGFloat titleShadowRadius;
	[Export("titleShadowRadius")]
	nfloat TitleShadowRadius { get; set; }

	// @property (nonatomic) CGFloat closeButtonFontSize;
	[Export("closeButtonFontSize")]
	nfloat CloseButtonFontSize { get; set; }

	// @property (nonatomic, strong) UIColor * _Nonnull closeButtonTextColor;
	[Export("closeButtonTextColor", ArgumentSemantic.Strong)]
	UIColor CloseButtonTextColor { get; set; }

	// @property (nonatomic, strong) UIColor * _Nonnull closeButtonShadowColor;
	[Export("closeButtonShadowColor", ArgumentSemantic.Strong)]
	UIColor CloseButtonShadowColor { get; set; }

	// @property (nonatomic) CGFloat closeButtonShadowRadius;
	[Export("closeButtonShadowRadius")]
	nfloat CloseButtonShadowRadius { get; set; }

	// @property (nonatomic, strong) UIColor * _Nonnull bottomOverlayColor;
	[Export("bottomOverlayColor", ArgumentSemantic.Strong)]
	UIColor BottomOverlayColor { get; set; }

	// @property (nonatomic) CGFloat bottomOverlayCornerRadius;
	[Export("bottomOverlayCornerRadius")]
	nfloat BottomOverlayCornerRadius { get; set; }

	// @property (nonatomic, strong) UIColor * _Nonnull skuButtonColor;
	[Export("skuButtonColor", ArgumentSemantic.Strong)]
	UIColor SkuButtonColor { get; set; }

	// @property (nonatomic, strong) UIColor * _Nonnull skuButtonTextColor;
	[Export("skuButtonTextColor", ArgumentSemantic.Strong)]
	UIColor SkuButtonTextColor { get; set; }

	// @property (nonatomic, strong) UIColor * _Nonnull featuredSkusButtonColor;
	[Export("featuredSkusButtonColor", ArgumentSemantic.Strong)]
	UIColor FeaturedSkusButtonColor { get; set; }

	// @property (nonatomic, strong) UIColor * _Nonnull featuredSkusButtonTextColor;
	[Export("featuredSkusButtonTextColor", ArgumentSemantic.Strong)]
	UIColor FeaturedSkusButtonTextColor { get; set; }

	// @property (nonatomic) CGFloat signinButtonFontSize;
	[Export("signinButtonFontSize")]
	nfloat SigninButtonFontSize { get; set; }

	// @property (nonatomic, strong) UIColor * _Nonnull signinButtonTextColor;
	[Export("signinButtonTextColor", ArgumentSemantic.Strong)]
	UIColor SigninButtonTextColor { get; set; }

	// @property (nonatomic, strong) UIColor * _Nonnull signinButtonShadowColor;
	[Export("signinButtonShadowColor", ArgumentSemantic.Strong)]
	UIColor SigninButtonShadowColor { get; set; }

	// @property (nonatomic) CGFloat signinButtonShadowRadius;
	[Export("signinButtonShadowRadius")]
	nfloat SigninButtonShadowRadius { get; set; }

	// @property (nonatomic) CGFloat restoreButtonFontSize;
	[Export("restoreButtonFontSize")]
	nfloat RestoreButtonFontSize { get; set; }

	// @property (nonatomic, strong) UIColor * _Nonnull restoreButtonTextColor;
	[Export("restoreButtonTextColor", ArgumentSemantic.Strong)]
	UIColor RestoreButtonTextColor { get; set; }

	// @property (nonatomic, strong) UIColor * _Nonnull restoreButtonShadowColor;
	[Export("restoreButtonShadowColor", ArgumentSemantic.Strong)]
	UIColor RestoreButtonShadowColor { get; set; }

	// @property (nonatomic) CGFloat restoreButtonShadowRadius;
	[Export("restoreButtonShadowRadius")]
	nfloat RestoreButtonShadowRadius { get; set; }

	// @property (nonatomic) CGFloat purchaseTermsFontSize;
	[Export("purchaseTermsFontSize")]
	nfloat PurchaseTermsFontSize { get; set; }

	// @property (nonatomic, strong) UIColor * _Nonnull purchaseTermsTextColor;
	[Export("purchaseTermsTextColor", ArgumentSemantic.Strong)]
	UIColor PurchaseTermsTextColor { get; set; }

	// @property (nonatomic, strong) UIColor * _Nonnull purchaseTermsShadowColor;
	[Export("purchaseTermsShadowColor", ArgumentSemantic.Strong)]
	UIColor PurchaseTermsShadowColor { get; set; }

	// @property (nonatomic) CGFloat purchaseTermsShadowRadius;
	[Export("purchaseTermsShadowRadius")]
	nfloat PurchaseTermsShadowRadius { get; set; }

	// @property (nonatomic, strong) UIColor * _Nonnull termsLinkColor;
	[Export("termsLinkColor", ArgumentSemantic.Strong)]
	UIColor TermsLinkColor { get; set; }
}

// @interface Nami_Swift_2004 (SKProduct)
[Category]
	[BaseType (typeof(SKProduct))]
	interface SKProductInstance
	{
		// -(NSDictionary<NSString *,id> * _Nonnull)namiInfoDict __attribute__((warn_unused_result("")));
		[Export("namiInfoDict")]
		NSDictionary<NSString, NSObject> NamiInfoDict();

        // -(NSDictionary<NSString *,id> * _Nonnull)namiInfoDictWithPurchaseSource:(enum NamiPurchaseSource)purchaseSource __attribute__((warn_unused_result("")));
        [Export("namiInfoDictWithPurchaseSource:")]
        NSDictionary<NSString, NSObject> NamiInfoDictWithPurchaseSource(NamiPurchaseSource purchaseSource);

		// @property (nonatomic, strong, class) NSNumberFormatter * _Nonnull priceFormatter;
		[Static]
		[Export("priceFormatter", ArgumentSemantic.Strong)]
		NSNumberFormatter PriceFormatter { get; set; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable localizedPrice;
		[NullAllowed, Export("localizedPrice")]
		string LocalizedPrice();

		// @property (readonly, copy, nonatomic) NSString * _Nullable localizedPerUnitPrice;
		[NullAllowed, Export("localizedPerUnitPrice")]
		string LocalizedPerUnitPrice();

		// @property (readonly, copy, nonatomic) NSString * _Nullable localizedMultipliedPrice;
		[NullAllowed, Export("localizedMultipliedPrice")]
		string LocalizedMultipliedPrice();

		// @property (readonly, copy, nonatomic) SWIFT_AVAILABILITY(ios,introduced=11.2) NSString * localizedDuration __attribute__((availability(ios, introduced=11.2)));
		[iOS(11, 2)]
		[Export("localizedDuration")]
		string LocalizedDuration();

		// @property (readonly, copy, nonatomic) SWIFT_AVAILABILITY(ios,introduced=11.2) NSString * localizedDurationNoPer __attribute__((availability(ios, introduced=11.2)));
		[iOS(11, 2)]
		[Export("localizedDurationNoPer")]
		string LocalizedDurationNoPer();

		// @property (readonly, copy, nonatomic) SWIFT_AVAILABILITY(ios,introduced=11.2) NSString * localizedDurationSingular __attribute__((availability(ios, introduced=11.2)));
		[iOS(11, 2)]
		[Export("localizedDurationSingular")]
		string LocalizedDurationSingular();
	}

	// @interface StoreKitQueueHelper : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC4Nami19StoreKitQueueHelper")]
	interface StoreKitQueueHelper
	{
	}
}
