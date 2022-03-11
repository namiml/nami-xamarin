using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using NamiML;
using XamarinForms_BasicSample;
using XamarinForms_BasicSample.iOS;
using CoreGraphics;

[assembly: ExportRenderer(typeof(SubscribeView), typeof(PaywallRender))]

namespace XamarinForms_BasicSample.iOS
{
    /// <summary>
    /// this is a custom render page for the NamiML paywall. It overrides the Xamarin Form's project Paywall Content page to 
    /// allow for the iOS custom implementation of the paywall 
    /// </summary>
    class PaywallRender : PageRenderer
    {

        UIScrollView scrollView;
        UILabel subscriptionStatusLabel;

        //provide the external identifier for your customer
        private static String EXTERNAL_IDENTIFIER = "9a9999a9-99aa-99a9-aa99-999a999999a9";

        //provide the app platform ID from your Nami account
        private static String NAMI_APP_PLATFORM_ID = "3d062066-9d3c-430e-935d-855e2c56dd8e";

        /// <summary>
        /// This method is overriden to provide our own setup for when the page is rendered. This method is called when the page or control is created.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            try
            {
                //call the method to setup the user interface and create the controls needed
                SetupUserInterface();

                //run the Nami setup 
                NamiSetup();

                //call to provide the customer identifier
                Nami.SetExternalIdentifier(EXTERNAL_IDENTIFIER, NamiExternalIdentifierType.Uuid);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(@"            ERROR: ", ex.Message);
            }
        }


        /// <summary>
        /// This method sets up the user interface and creates the controls that should be rendered on the page
        /// </summary>
        public void SetupUserInterface()
        {
            var titleView = new UIImageView(UIImage.FromBundle("nami_logo_white"))
            {
                BackgroundColor = new UIColor(red: 0.25f, green: 0.43f, blue: 0.49f, alpha: 1.00f),
                ContentMode = UIViewContentMode.ScaleAspectFit,
            };

            base.NavigationItem.TitleView = titleView;

            nfloat h = 31.0f;
            nfloat w = View.Bounds.Width;

            View.BackgroundColor = UIColor.White;

            var subscribeButton = UIButton.FromType(UIButtonType.RoundedRect);
            subscribeButton.Frame = new CGRect(10, 600, w - 20, 44);
            subscribeButton.SetTitle("Subscribe", UIControlState.Normal);
            subscribeButton.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;

            subscribeButton.TouchDown += OnSubscribeClicked;

            scrollView = new UIScrollView(new CGRect(0, 0, View.Frame.Width, View.Frame.Height));
            scrollView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
            scrollView.ContentSize = new CGSize(View.Frame.Width, 760);

            subscriptionStatusLabel = new UILabel(new CGRect(10, 550, View.Frame.Width - 20, 50))
            {
                Text = "Subscription is: Inactive",
                Font = UIFont.BoldSystemFontOfSize(24),
                TextAlignment = UITextAlignment.Left,
                TextColor = UIColor.Black,
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth
            };
            scrollView.AddSubview(subscriptionStatusLabel);

            scrollView.AddSubview(subscribeButton);

            this.View.AddSubview(scrollView);


            //Register a callback to react to a change in the state of entitlements for the user.
            //this fires after the RegisterPurchasesChangedHandler
            NamiEntitlementManager.RegisterEntitlementsChangedHandler((entitlements) =>
            {
                Console.WriteLine("Entitlements Change Listener triggered");

                var ent = new List<NamiEntitlement>();

                foreach (var n in entitlements)
                {
                    ent.Add(n);
                }

                LogActiveEntitlements(ent);

                HandleActiveEntitlements(ent);
            });

            //register a handler to listen for changes 
            //it is important to check the state of the purchase as there are multiple states that can result in this event getting triggered.
            NamiPurchaseManager.RegisterPurchasesChangedHandler((purchases, state, error) => {

                var pur = new List<NamiPurchase>();

                foreach (var n in purchases)
                {
                    pur.Add(n);
                }

                EvaluateLastPurchaseEvent(pur, state, error?.ToString());
            });

            HandleActiveEntitlements(NamiEntitlementManager.ActiveEntitlements().ToList());
        }

        public void NamiSetup()
        {
            // This is the appID for a Nami test application with already configured products and paywalls, contact Nami to obtain an Application ID for your own application.
            var namiConfig = NamiConfiguration.ConfigurationForAppPlatformID(NAMI_APP_PLATFORM_ID);

            // Makes sure when the app is re-run that any stored bypass purchases are cleared out so we can retry purchases
            // Note this cannot clear out StoreKit sandbox or regular purchases, which Apple controls.
            // This only clears out purchases made when bypassStoreKit is enabled.
            NamiPurchaseManager.ClearBypassStorePurchases();

            // For testing we'll bypass StoreKit, so you don't have to run the app on a device to test purchases.
            // You may want to include some ability to toggle this on for testers of your application.
            namiConfig.BypassStore = true;

            //Nami recommends setting the log level to Warn for apps on the store. Info may be helpful during development to better understand what is going on. Debug level has a lot of information and is likely only helpful to the Nami support team.
            namiConfig.LogLevel = NamiLogLevel.Info;
            Nami.ConfigureWithNamiConfig(namiConfig);

            //sign in handler not currently being used but could be needed in the future
            NamiPaywallManager.RegisterSignInHandler((viewController, message, paywall) => {
                var okAlertController = UIAlertController.Create("Sign In", message, UIAlertControllerStyle.Alert);

                //Add Action
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

                // Present Alert    
                UIApplication.SharedApplication.KeyWindow.RootViewController.PresentedViewController.PresentViewController(okAlertController, true, null);


            });


            //Nami triggers a callback any time there is a change to the state of an entitlement.
            //In the callback the full list of currently active entitlements is provided.
            //You can use this to store the state of whether a user has access to premium features locally in your app.
            NamiPurchaseManager.RegisterPurchasesChangedHandler(changeHandler: (purchases, purchaseState, error) => {
                foreach (NamiPurchase purchase in purchases)
                {
                    var expires = purchase.Expires;
                }


            });

            NamiPaywallManager.RegisterAllowAutoRaisePaywallHandler(() => { return true; });

        }

        #region NamiML Events

        //These are events set up to listen to or respond to various Nami events

        /// <summary>
        /// Evaluates current purchases and iterates through a list of active purchases for the customer
        /// </summary>
        /// <param name="activePurchases"></param>
        /// <param name="namiPurchaseState"></param>
        /// <param name="errorMsg"></param>
        private void EvaluateLastPurchaseEvent(List<NamiPurchase> activePurchases, NamiPurchaseState namiPurchaseState, string errorMsg)
        {

            Console.WriteLine($"Purchase State {namiPurchaseState}");

            if (namiPurchaseState == NamiPurchaseState.Purchased)
            {
                Console.WriteLine("Active Purchases: ");
                foreach (var pur in activePurchases)
                {
                    Console.WriteLine($"SkuId: {pur.SkuID()}");
                }
            }
            else
            {
                Console.WriteLine($"Reason : {errorMsg}");
            }
        }

        /// <summary>
        /// Checks for active entitlements 
        /// </summary>
        /// <param name="activeEntitlements"></param>
        private void HandleActiveEntitlements(List<NamiEntitlement> activeEntitlements)
        {
            if (activeEntitlements?.Count > 0)
            {
                subscriptionStatusLabel.Text = "Subscription is: Active";
            }
        }

        /// <summary>
        /// Logs the customer journey through various subscription states in order to test and troubleshoot subscription processes
        /// </summary>
        private void LogCustomerJourneyState()
        {
            var state = NamiCustomerManager.CurrentCustomerJourneyState;

            Console.WriteLine("currentCustomerJourneyState");

            Console.WriteLine($"    formerSubscriber ==> ${state?.FormerSubscriber()}");
            Console.WriteLine($"    inGracePeriod ==> ${state?.InGracePeriod()}");
            Console.WriteLine($"    inIntroOfferPeriod ==> ${state?.InIntroOfferPeriod()}");
            Console.WriteLine($"    inTrialPeriod ==> ${state?.InTrialPeriod()}");

        }

        /// <summary>
        /// Logs all active entitlements 
        /// </summary>
        /// <param name="activeEntitlements"></param>
        private void LogActiveEntitlements(List<NamiEntitlement> activeEntitlements)
        {
            Console.WriteLine("Active entitlements");

            foreach (var ent in activeEntitlements)
            {
                Console.WriteLine($"\tName: {ent.Name}\tReferenceId: {ent.ReferenceID}");
            }
        }

        /// <summary>
        /// Click event for the subscribe button.  Pops the paywall. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSubscribeClicked(object sender, EventArgs e)
        {
            NamiPaywallManager.PreparePaywallForDisplay(true, 10.0, (success, error) =>
            {
                if (success)
                {
                    NamiPaywallManager.RaisePaywall(this);
                }
                else
                {
                    Console.WriteLine($"Error preparing paywall for display: {error.LocalizedDescription}");
                }
            });

        }


        #endregion

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);



        }

    }
}