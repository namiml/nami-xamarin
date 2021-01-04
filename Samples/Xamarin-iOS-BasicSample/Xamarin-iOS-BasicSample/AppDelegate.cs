using Foundation;
using UIKit;
using NamiML;

namespace Xamarin_iOS_BasicSample
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIResponder, IUIApplicationDelegate
    {
        Nami nami;
        const string TEST_EXTERNAL_IDENTIFIER = "9a9999a9-99aa-99a9-aa99-999a999999a9";

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
            // Makes sure when the app is re-run that any stored bypass purchases are cleared out so we can retry purchases
            // Note this cannot clear out StoreKit sandbox or regular purchases, which Apple controls.
            // This only clears out purchases made when bypassStoreKit is enabled.
            NamiPurchaseManager.ClearBypassStorePurchases();

            // This is the appID for a Nami test application with already configured products and paywalls, contact Nami to obtain an Application ID for your own application.
            var namiConfig = NamiConfiguration.ConfigurationForAppPlatformID("002e2c49-7f66-4d22-a05c-1dc9f2b7f2af");

            // For testing we'll bypass StoreKit, so you don't have to run the app on a device to test purchases.
            // You may want to include some ability to toggle this on for testers of your application.
            namiConfig.BypassStore = true;

            namiConfig.LogLevel = NamiLogLevel.Warn;
            Nami.ConfigureWithNamiConfig(namiConfig);

            NamiPaywallManager.RegisterWithApplicationSignInProvider(applicationSignInProvider: (viewController, message, paywall) => {
                var okAlertController = UIAlertController.Create("Sign In", message, UIAlertControllerStyle.Alert);

                //Add Action
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

                // Present Alert
                UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(okAlertController, true, null);

                Nami.SetExternalIdentifierWithExternalIdentifier(TEST_EXTERNAL_IDENTIFIER, NamiExternalIdentifierType.Uuid);
            });

            NamiPurchaseManager.RegisterWithPurchasesChangedHandler(changeHandler: (purchases, purchaseState, error) => {
                foreach (NamiPurchase purchase in purchases)
                {
                    var expires = purchase.Expires;
                }
        });

            NamiPurchaseManager.IsSKUIDPurchased("nami_monthly");

            NamiPaywallManager.RegisterApplicationAutoRaisePaywallBlocker(() => { return true; });
        }
    }
}

