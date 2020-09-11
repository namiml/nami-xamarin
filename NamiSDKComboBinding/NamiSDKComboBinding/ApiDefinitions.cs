using System;
using CoreGraphics;
using Foundation;
using Messages;
using ObjCRuntime;
using StoreKit;
using UIKit;

namespace Binding
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

		//// -(instancetype _Nonnull)initWithFormerSubscriber:(BOOL)formerSubscriber inGracePeriod:(BOOL)inGracePeriod inTrialPeriod:(BOOL)inTrialPeriod inIntroOfferPeriod:(BOOL)inIntroOfferPeriod __attribute__((objc_designated_initializer));
		//[Export ("initWithFormerSubscriber:inGracePeriod:inTrialPeriod:inIntroOfferPeriod:")]
		//[DesignatedInitializer]
		//IntPtr Constructor (bool formerSubscriber, bool inGracePeriod, bool inTrialPeriod, bool inIntroOfferPeriod);

		//// -(instancetype _Nonnull)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
		//[Export ("initWithCoder:")]
		//[DesignatedInitializer]
		//IntPtr Constructor (NSCoder aDecoder);

		//// -(void)encodeWithCoder:(NSCoder * _Nonnull)coder;
		//[Export ("encodeWithCoder:")]
		//void EncodeWithCoder (NSCoder coder);
	}

	// @interface MockPayment : SKPayment
	//[BaseType (typeof(SKPayment), Name = "_TtC4Nami11MockPayment")]
	//interface MockPayment
	//{
	//	// @property (readonly, copy, nonatomic) NSString * _Nonnull productIdentifier;
	//	[Export ("productIdentifier")]
	//	string ProductIdentifier { get; }
	//}

	// @interface MockPayment2 : SKPayment
	[BaseType (typeof(SKPayment), Name = "_TtC4Nami12MockPayment2")]
	interface MockPayment2
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull productIdentifier;
		[Export ("productIdentifier")]
		string ProductIdentifier { get; }
	}

	// @interface MockPaymentTransactionPending : SKPaymentTransaction
	[BaseType (typeof(SKPaymentTransaction), Name = "_TtC4Nami29MockPaymentTransactionPending")]
	interface MockPaymentTransactionPending
	{
		// @property (readonly, nonatomic, strong) SKPayment * _Nonnull payment;
		[Export ("payment", ArgumentSemantic.Strong)]
		SKPayment Payment { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable transactionIdentifier;
		[NullAllowed, Export ("transactionIdentifier")]
		string TransactionIdentifier { get; }

		// @property (readonly, nonatomic) SKPaymentTransactionState transactionState;
		[Export ("transactionState")]
		SKPaymentTransactionState TransactionState { get; }

		// @property (readonly, copy, nonatomic) NSDate * _Nullable transactionDate;
		[NullAllowed, Export ("transactionDate", ArgumentSemantic.Copy)]
		NSDate TransactionDate { get; }
	}

	// @interface MockPaymentTransaction : MockPaymentTransactionPending
	[BaseType (typeof(MockPaymentTransactionPending), Name = "_TtC4Nami22MockPaymentTransaction")]
	interface MockPaymentTransaction
	{
		// @property (readonly, nonatomic) SKPaymentTransactionState transactionState;
		[Export ("transactionState")]
		SKPaymentTransactionState TransactionState { get; }

		// @property (readonly, nonatomic, strong) SKPayment * _Nonnull payment;
		[Export ("payment", ArgumentSemantic.Strong)]
		SKPayment Payment { get; }
	}

	// @interface MockPaymentTransaction2 : MockPaymentTransactionPending
	[BaseType (typeof(MockPaymentTransactionPending), Name = "_TtC4Nami23MockPaymentTransaction2")]
	interface MockPaymentTransaction2
	{
		// @property (readonly, nonatomic) SKPaymentTransactionState transactionState;
		[Export ("transactionState")]
		SKPaymentTransactionState TransactionState { get; }

		// @property (readonly, nonatomic, strong) SKPayment * _Nonnull payment;
		[Export ("payment", ArgumentSemantic.Strong)]
		SKPayment Payment { get; }
	}

	// @interface MockPaymentTransactionFailed : MockPaymentTransactionPending
	[BaseType (typeof(MockPaymentTransactionPending), Name = "_TtC4Nami28MockPaymentTransactionFailed")]
	interface MockPaymentTransactionFailed
	{
		// @property (readonly, nonatomic) SKPaymentTransactionState transactionState;
		[Export ("transactionState")]
		SKPaymentTransactionState TransactionState { get; }
	}

	// @interface MockPaymentTransactionPending2 : MockPaymentTransactionPending
	[BaseType (typeof(MockPaymentTransactionPending), Name = "_TtC4Nami30MockPaymentTransactionPending2")]
	interface MockPaymentTransactionPending2
	{
		// @property (readonly, nonatomic, strong) SKPayment * _Nonnull payment;
		[Export ("payment", ArgumentSemantic.Strong)]
		SKPayment Payment { get; }
	}

	//// @interface Nami : NSObject
	//[BaseType (typeof(NSObject), Name = "_TtC4Nami4Nami")]
	//[DisableDefaultCtor]
	//interface Nami
	//{
	//	// @property (readonly, nonatomic, strong, class) Nami * _Nonnull shared;
	//	[Static]
	//	[Export ("shared", ArgumentSemantic.Strong)]
	//	Nami Shared { get; }
	//}

	//// @interface Nami_Swift_1345 (Nami)
	//[Category]
	//[BaseType (typeof(Nami))]
	//interface Nami_Nami_Swift_1345
	//{
	//	// +(void)configureWithNamiConfig:(NamiConfiguration * _Nonnull)namiConfig;
	//	[Static]
	//	[Export ("configureWithNamiConfig:")]
	//	void ConfigureWithNamiConfig (NamiConfiguration namiConfig);

	//	// +(void)registerNamiLoggerWithLogger:(id<NamiLoggerClient> _Nonnull)logger;
	//	[Static]
	//	[Export ("registerNamiLoggerWithLogger:")]
	//	void RegisterNamiLoggerWithLogger (NamiLoggerClient logger);

	//	// +(void)doConfigBasedWorkWithWorker:(void (^ _Nonnull)(void))worker;
	//	[Static]
	//	[Export ("doConfigBasedWorkWithWorker:")]
	//	void DoConfigBasedWorkWithWorker (Action worker);

	//	// +(void)setExternalIdentifierWithExternalIdentifier:(NSString * _Nullable)externalIdentifier type:(enum NamiExternalIdentifierType)type;
	//	[Static]
	//	[Export ("setExternalIdentifierWithExternalIdentifier:type:")]
	//	void SetExternalIdentifierWithExternalIdentifier ([NullAllowed] string externalIdentifier, NamiExternalIdentifierType type);

	//	// +(NSString * _Nullable)getExternalIdentifier __attribute__((warn_unused_result("")));
	//	[Static]
	//	[NullAllowed, Export ("getExternalIdentifier")]
	//	[Verify (MethodToProperty)]
	//	string ExternalIdentifier { get; }

	//	// +(void)clearExternalIdentifier;
	//	[Static]
	//	[Export ("clearExternalIdentifier")]
	//	void ClearExternalIdentifier ();

	//	// +(void)setLogLevel:(enum NamiLogLevel)logLevel;
	//	[Static]
	//	[Export ("setLogLevel:")]
	//	void SetLogLevel (NamiLogLevel logLevel);
	//}

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

	//// @interface NamiCorrectiveFlowLayout : UICollectionViewFlowLayout
	//[BaseType (typeof(UICollectionViewFlowLayout), Name = "_TtC4Nami24NamiCorrectiveFlowLayout")]
	//interface NamiCorrectiveFlowLayout
	//{
	//	// -(BOOL)shouldInvalidateLayoutForBoundsChange:(CGRect)newBounds __attribute__((warn_unused_result("")));
	//	[Export ("shouldInvalidateLayoutForBoundsChange:")]
	//	bool ShouldInvalidateLayoutForBoundsChange (CGRect newBounds);

	//	// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)coder __attribute__((objc_designated_initializer));
	//	[Export ("initWithCoder:")]
	//	[DesignatedInitializer]
	//	IntPtr Constructor (NSCoder coder);
	//}

	// @interface NamiCustomerManager : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC4Nami19NamiCustomerManager")]
	interface NamiCustomerManager
	{
	}

	// @interface Nami_Swift_1457 (NamiCustomerManager)
	[Category]
	[BaseType (typeof(NamiCustomerManager))]
	interface NamiCustomerManager_Nami_Swift_1457
	{
		// +(CustomerJourneyState * _Nullable)currentCustomerJourneyState __attribute__((warn_unused_result("")));
		[Static]
		[NullAllowed, Export ("currentCustomerJourneyState")]
		CustomerJourneyState CurrentCustomerJourneyState { get; }
	}

	// @interface NamiEntitlement : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC4Nami15NamiEntitlement")]
	[DisableDefaultCtor]
	interface NamiEntitlement
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
		// -(void)registerWithEntitlementsChangedHandler:(void (^ _Nullable)(NSArray<NamiEntitlement *> * _Nonnull))changeHandler;
		//[Export ("registerWithEntitlementsChangedHandler:")]
		//void RegisterWithEntitlementsChangedHandler ([NullAllowed] Action<NSArray<NamiEntitlement>> changeHandler);
	}

	// @interface Nami_Swift_1494 (NamiEntitlementManager)
	[Category]
	[BaseType (typeof(NamiEntitlementManager))]
	interface NamiEntitlementManager_Nami_Swift_1494
	{
		// +(NSArray<NamiEntitlement *> * _Nonnull)getEntitlements __attribute__((warn_unused_result("")));
		[Static]
		[Export("getEntitlements")]
		NamiEntitlement[] Entitlements();

		// +(NSArray<NamiEntitlement *> * _Nonnull)activeEntitlements __attribute__((warn_unused_result("")));
		[Static]
		[Export("activeEntitlements")]
		NamiEntitlement[] ActiveEntitlements();

		// +(BOOL)isEntitlementActive:(NSString * _Nonnull)referenceID __attribute__((warn_unused_result("")));
		[Static]
		[Export ("isEntitlementActive:")]
		bool IsEntitlementActive (string referenceID);

		// +(void)setEntitlements:(NSArray<NamiEntitlementSetter *> * _Nonnull)entitlements;
		[Static]
		[Export ("setEntitlements:")]
		void SetEntitlements (NamiEntitlementSetter[] entitlements);

		// +(void)clearAllEntitlements;
		[Static]
		[Export ("clearAllEntitlements")]
		void ClearAllEntitlements ();

		// +(void)registerChangeHandlerWithEntitlementsChangedHandler:(void (^ _Nullable)(NSArray<NamiEntitlement *> * _Nonnull))changeHandler;
		//[Static]
		//[Export ("registerChangeHandlerWithEntitlementsChangedHandler:")]
		//void RegisterChangeHandlerWithEntitlementsChangedHandler ([NullAllowed] Action<NSArray<NamiEntitlement>> changeHandler);
	}

	// @interface NamiEntitlementSetter : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC4Nami21NamiEntitlementSetter")]
	[DisableDefaultCtor]
	interface NamiEntitlementSetter
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
	}

	// @interface Nami_Swift_1607 (NamiMLManager)
	[Category]
	[BaseType (typeof(NamiMLManager))]
	interface NamiMLManager_Nami_Swift_1607
	{
		// +(void)enterCoreContentWithLabels:(NSArray<NSString *> * _Nonnull)labels;
		[Static]
		[Export ("enterCoreContentWithLabels:")]
		void EnterCoreContentWithLabels (string[] labels);

		// +(void)enterCoreContentWithLabel:(NSString * _Nonnull)label;
		[Static]
		[Export ("enterCoreContentWithLabel:")]
		void EnterCoreContentWithLabel (string label);

		// +(void)exitCoreContentWithLabels:(NSArray<NSString *> * _Nonnull)labels;
		[Static]
		[Export ("exitCoreContentWithLabels:")]
		void ExitCoreContentWithLabels (string[] labels);

		// +(void)exitCoreContentWithLabel:(NSString * _Nonnull)label;
		[Static]
		[Export ("exitCoreContentWithLabel:")]
		void ExitCoreContentWithLabel (string label);

		// +(void)coreActionWithLabel:(NSString * _Nonnull)label;
		[Static]
		[Export ("coreActionWithLabel:")]
		void CoreActionWithLabel (string label);
	}

	// @interface NamiPaywall : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC4Nami11NamiPaywall")]
	[DisableDefaultCtor]
	interface NamiPaywall
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
	[DisableDefaultCtor]
	interface NamiPaywallManager
	{
	}

	// @interface Nami_Swift_1660 (NamiPaywallManager)
	[Category]
	[BaseType (typeof(NamiPaywallManager))]
	interface NamiPaywallManager_Nami_Swift_1660
	{
		// +(void)paywallImpressionWithDeveloperID:(NSString * _Nonnull)developerID;
		[Static]
		[Export ("paywallImpressionWithDeveloperID:")]
		void PaywallImpressionWithDeveloperID (string developerID);

		// +(void)presentNamiPaywallFromVC:(UIViewController * _Nullable)fromVC products:(NSArray<NamiSKU *> * _Nullable)products paywallMetadata:(NamiPaywall * _Nonnull)paywallMetadata backgroundImage:(UIImage * _Nullable)backgroundImage forNami:(BOOL)forNami;
		[Static]
		[Export ("presentNamiPaywallFromVC:products:paywallMetadata:backgroundImage:forNami:")]
		void PresentNamiPaywallFromVC ([NullAllowed] UIViewController fromVC, [NullAllowed] NamiSKU[] products, NamiPaywall paywallMetadata, [NullAllowed] UIImage backgroundImage, bool forNami);

		// +(void)registerApplicationAutoRaisePaywallBlocker:(BOOL (^ _Nullable)(void))applicationAutoRaisePaywallBlocker;
		[Static]
		[Export ("registerApplicationAutoRaisePaywallBlocker:")]
		void RegisterApplicationAutoRaisePaywallBlocker ([NullAllowed] Func<bool> applicationAutoRaisePaywallBlocker);

		// +(void)fetchCustomPaywallMetaForDeveloperID:(NSString * _Nonnull)developerPaywallID :(void (^ _Nonnull)(NSArray<NamiSKU *> * _Nullable, NSString * _Nonnull, NamiPaywall * _Nullable))namiCustomPaywallHandler;
		//[Static]
		//[Export ("fetchCustomPaywallMetaForDeveloperID::")]
		//void FetchCustomPaywallMetaForDeveloperID (string developerPaywallID, Action<NSArray<NamiSKU>, NSString, NamiPaywall> namiCustomPaywallHandler);

		// +(void)registerWithApplicationPaywallProvider:(void (^ _Nullable)(UIViewController * _Nullable, NSArray<NamiSKU *> * _Nullable, NSString * _Nonnull, NamiPaywall * _Nonnull))applicationPaywallProvider;
		//[Static]
		//[Export ("registerWithApplicationPaywallProvider:")]
		//void RegisterWithApplicationPaywallProvider ([NullAllowed] Action<UIViewController, NSArray<NamiSKU>, NSString, NamiPaywall> applicationPaywallProvider);

		// +(void)registerWithApplicationSignInProvider:(void (^ _Nullable)(UIViewController * _Nullable, NSString * _Nonnull, NamiPaywall * _Nonnull))applicationSignInProvider;
		[Static]
		[Export ("registerWithApplicationSignInProvider:")]
		void RegisterWithApplicationSignInProvider ([NullAllowed] Action<UIViewController, NSString, NamiPaywall> applicationSignInProvider);

		// +(void)registerWithApplicationBlockingPaywallClosedHandler:(void (^ _Nullable)(void))applicationBlockingPaywallClosedHandler;
		[Static]
		[Export ("registerWithApplicationBlockingPaywallClosedHandler:")]
		void RegisterWithApplicationBlockingPaywallClosedHandler ([NullAllowed] Action applicationBlockingPaywallClosedHandler);

		// +(BOOL)canRaisePaywall __attribute__((warn_unused_result("")));
		[Static]
		[Export ("canRaisePaywall")]
		bool CanRaisePaywall { get; }

		// +(void)raisePaywallFromVC:(UIViewController * _Nullable)fromVC;
		[Static]
		[Export ("raisePaywallFromVC:")]
		void RaisePaywallFromVC ([NullAllowed] UIViewController fromVC);

		// +(void)raisePaywallFromVC:(UIViewController * _Nullable)fromVC forNami:(BOOL)forNami;
		[Static]
		[Export ("raisePaywallFromVC:forNami:")]
		void RaisePaywallFromVC ([NullAllowed] UIViewController fromVC, bool forNami);

		// +(void)dismissNamiPaywallIfOpenWithAnimated:(BOOL)animated completion:(void (^ _Nonnull)(void))completion;
		[Static]
		[Export ("dismissNamiPaywallIfOpenWithAnimated:completion:")]
		void DismissNamiPaywallIfOpenWithAnimated (bool animated, Action completion);
	}

	// @interface NamiPaywallTextFieldCell : UICollectionViewCell <UITextViewDelegate>
	//[BaseType (typeof(UICollectionViewCell), Name = "_TtC4Nami24NamiPaywallTextFieldCell")]
	//interface NamiPaywallTextFieldCell : IUITextViewDelegate
	//{
	//	// -(BOOL)textView:(UITextView * _Nonnull)textView shouldInteractWithURL:(NSURL * _Nonnull)URL inRange:(NSRange)characterRange interaction:(UITextItemInteraction)interaction __attribute__((warn_unused_result("")));
	//	[Export ("textView:shouldInteractWithURL:inRange:interaction:")]
	//	bool TextView (UITextView textView, NSUrl URL, NSRange characterRange, UITextItemInteraction interaction);

	//	// -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
	//	[Export ("initWithFrame:")]
	//	[DesignatedInitializer]
	//	IntPtr Constructor (CGRect frame);

	//	// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)coder __attribute__((objc_designated_initializer));
	//	[Export ("initWithCoder:")]
	//	[DesignatedInitializer]
	//	IntPtr Constructor (NSCoder coder);
	//}

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

		// @property (copy, nonatomic) NSDate * _Nullable exipres;
		[NullAllowed, Export ("exipres", ArgumentSemantic.Copy)]
		NSDate Exipres { get; set; }

		// @property (nonatomic) enum NamiPurchaseSource purchaseSource;
		//[Export ("purchaseSource", ArgumentSemantic.Assign)]
		//NamiPurchaseSource PurchaseSource { get; set; }

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
		//[Static]
		//[Export ("skusForSKUIDsWithSkuIDs:productHandler:")]
		//void SkusForSKUIDsWithSkuIDs (string[] skuIDs, Action<bool, NSArray<NamiSKU>, NSArray<NSString>, NSError> productHandler);

		// +(NSArray<NamiPurchase *> * _Nonnull)allPurchases __attribute__((warn_unused_result("")));
		[Static]
		[Export ("allPurchases")]
		NamiPurchase[] AllPurchases { get; }

		// +(void)registerWithPurchasesChangedHandler:(void (^ _Nullable)(NSArray<NamiPurchase *> * _Nonnull, enum NamiPurchaseState, NSError * _Nullable))changeHandler;
		//[Static]
		//[Export ("registerWithPurchasesChangedHandler:")]
		//void RegisterWithPurchasesChangedHandler ([NullAllowed] Action<NSArray<NamiPurchase>, NamiPurchaseState, NSError> changeHandler);

		// +(void)restorePurchasesWithHandler:(void (^ _Nonnull)(BOOL, NSError * _Nullable))handler;
		[Static]
		[Export ("restorePurchasesWithHandler:")]
		void RestorePurchasesWithHandler (Action<bool, NSError> handler);

		// +(void)consumePurchasedSKUWithSkuID:(NSString * _Nonnull)skuID;
		[Static]
		[Export ("consumePurchasedSKUWithSkuID:")]
		void ConsumePurchasedSKUWithSkuID (string skuID);
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
	interface NamiSKU
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
		//[Export ("productsForProductIdentifiersWithProductIDs:productHandler:")]
		//void ProductsForProductIdentifiersWithProductIDs (string[] productIDs, Action<bool, NSArray<NamiSKU>, NSArray<NSString>, NSError> productHandler);

		// -(void)registerWithPurchasesChangedHandler:(void (^ _Nullable)(NSArray<NamiPurchase *> * _Nonnull, enum NamiPurchaseState, NSError * _Nullable))changeHandler;
		//[Export ("registerWithPurchasesChangedHandler:")]
		//void RegisterWithPurchasesChangedHandler ([NullAllowed] Action<NSArray<NamiPurchase>, NamiPurchaseState, NSError> changeHandler);

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

	//// @interface ProductOptionCell : UICollectionViewCell
	//[BaseType (typeof(UICollectionViewCell), Name = "_TtC4Nami17ProductOptionCell")]
	//interface ProductOptionCell
	//{
	//	// @property (nonatomic, weak) RoundedView * _Nullable backgroundRoundedView __attribute__((iboutlet));
	//	[NullAllowed, Export ("backgroundRoundedView", ArgumentSemantic.Weak)]
	//	RoundedView BackgroundRoundedView { get; set; }

	//	// @property (nonatomic, weak) UILabel * _Nullable descriptionLabel __attribute__((iboutlet));
	//	[NullAllowed, Export ("descriptionLabel", ArgumentSemantic.Weak)]
	//	UILabel DescriptionLabel { get; set; }

	//	// @property (nonatomic, weak) UILabel * _Nullable priceLabel __attribute__((iboutlet));
	//	[NullAllowed, Export ("priceLabel", ArgumentSemantic.Weak)]
	//	UILabel PriceLabel { get; set; }

	//	// @property (nonatomic, weak) UILabel * _Nullable durationLabel __attribute__((iboutlet));
	//	[NullAllowed, Export ("durationLabel", ArgumentSemantic.Weak)]
	//	UILabel DurationLabel { get; set; }

	//	// @property (nonatomic, weak) UILabel * _Nullable durationMultiplierLabel __attribute__((iboutlet));
	//	[NullAllowed, Export ("durationMultiplierLabel", ArgumentSemantic.Weak)]
	//	UILabel DurationMultiplierLabel { get; set; }

	//	// -(void)awakeFromNib __attribute__((objc_requires_super));
	//	[Export ("awakeFromNib")]
	//	[RequiresSuper]
	//	void AwakeFromNib ();

	//	// -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
	//	[Export ("initWithFrame:")]
	//	[DesignatedInitializer]
	//	IntPtr Constructor (CGRect frame);

	//	// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)coder __attribute__((objc_designated_initializer));
	//	[Export ("initWithCoder:")]
	//	[DesignatedInitializer]
	//	IntPtr Constructor (NSCoder coder);
	//}

	// @interface RoundedView : UIView
	//[BaseType (typeof(UIView), Name = "_TtC4Nami11RoundedView")]
	//interface RoundedView
	//{
	//	// -(void)awakeFromNib __attribute__((objc_requires_super));
	//	[Export ("awakeFromNib")]
	//	[RequiresSuper]
	//	void AwakeFromNib ();

	//	// @property (nonatomic) CGFloat cornerRadius;
	//	[Export ("cornerRadius")]
	//	nfloat CornerRadius { get; set; }

	//	// @property (nonatomic) BOOL maskTopCorners;
	//	[Export ("maskTopCorners")]
	//	bool MaskTopCorners { get; set; }

	//	// @property (nonatomic) BOOL maskBottomCorners;
	//	[Export ("maskBottomCorners")]
	//	bool MaskBottomCorners { get; set; }

	//	// -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
	//	[Export ("initWithFrame:")]
	//	[DesignatedInitializer]
	//	IntPtr Constructor (CGRect frame);

	//	// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)coder __attribute__((objc_designated_initializer));
	//	[Export ("initWithCoder:")]
	//	[DesignatedInitializer]
	//	IntPtr Constructor (NSCoder coder);
	//}

	// @interface Nami_Swift_2004 (SKProduct)
	[Category]
	[BaseType (typeof(SKProduct))]
	interface SKProduct_Nami_Swift_2004
	{
		// -(NSDictionary<NSString *,id> * _Nonnull)namiInfoDict __attribute__((warn_unused_result("")));
		[Export("namiInfoDict")]
		NSDictionary<NSString, NSObject> NamiInfoDict();

		// -(NSDictionary<NSString *,id> * _Nonnull)namiInfoDictWithPurchaseSource:(enum NamiPurchaseSource)purchaseSource __attribute__((warn_unused_result("")));
		//[Export ("namiInfoDictWithPurchaseSource:")]
		//NSDictionary<NSString, NSObject> NamiInfoDictWithPurchaseSource (NamiPurchaseSource purchaseSource);
	}

	// @interface Nami_Swift_2012 (SKProduct)
	[Category]
	[BaseType (typeof(SKProduct))]
	interface SKProduct_Nami_Swift_2012
	{
		// @property (nonatomic, strong, class) NSNumberFormatter * _Nonnull priceFormatter;
		[Static]
		[Export ("priceFormatter", ArgumentSemantic.Strong)]
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
