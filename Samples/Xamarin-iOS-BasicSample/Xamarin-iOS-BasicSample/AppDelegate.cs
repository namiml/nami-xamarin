using Foundation;
using UIKit;
using Binding;

namespace Xamarin_iOS_BasicSample
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIResponder, IUIApplicationDelegate
    {

        [Export("window")]
        public UIWindow Window { get; set; }

        [Export("application:didFinishLaunchingWithOptions:")]
        public bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            NamiSetup();

            Window = new UIWindow(UIScreen.MainScreen.Bounds);

            var controller = new MainViewController();
            
            Window.RootViewController = new UINavigationController(controller);

            // make the window visible
            Window.MakeKeyAndVisible();
            return true;
        }

        private void NamiSetup()
        {
            // For testing we'll bypass StoreKit, so you don't have to run the app on a device to test purchases.
            // You may want to include some ability to toggle this on for testers of your application.
            //NamiPurchaseManager.bypassStore(bypass: true);
            
            // Makes sure when the app is re-run that any stored bypass purchases are cleared out so we can retry purchases
            // Note this cannot clear out StoreKit sandbox or regular purchaes, which Apple controls.
            // This only clears out purchases made when bypassStoreKit is enabled.
            NamiPurchaseManager.ClearBypassStorePurchases();

            // This is the appID for a Nami test application with already configured products and paywalls, contact Nami to obtain an Application ID for your own application.
            var namiConfig = NamiConfiguration.ConfigurationForAppPlatformID("002e2c49-7f66-4d22-a05c-1dc9f2b7f2af");
            namiConfig.LogLevel = NamiLogLevel.Warn;
            var nami = Nami.Shared;
            Nami_Nami_Swift_1345.ConfigureWithNamiConfig(nami, namiConfig);



            NamiPaywallManager_Nami_Swift_1660.RegisterWithApplicationSignInProvider(new NamiPaywallManager(),applicationSignInProvider: (viewController,message,paywall) => { });
            NamiPaywallManager_Nami_Swift_1660.RegisterApplicationAutoRaisePaywallBlocker(null, () => { return true; });
            
            //NamiPaywallManager.register {
            //            (fromVC, developerPaywallID, paywallMetadata) in
            // Present any sign in UI from here to validate the user has an account already in your system.
        }

}
}

