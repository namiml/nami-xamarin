using System;
using CoreGraphics;
using UIKit;
using NamiML;
using System.Collections.Generic;
using System.Linq;

namespace Xamarin_iOS_BasicSample
{
    public partial class MainViewController : UIViewController
    {
        UILabel subscriptionStatusLabel;
        UIScrollView scrollView;

        public MainViewController() 
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            BuildUI();
        }

        public override void ViewWillAppear(bool animated)
        {
            LogCustomerJourneyState();
        }

        private void BuildUI()
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

            var aboutButton = UIButton.FromType(UIButtonType.RoundedRect);
            aboutButton.Frame = new CGRect(10, 50, w - 20, 44);
            aboutButton.SetTitle("About", UIControlState.Normal);
            aboutButton.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;

            var subscribeButton = UIButton.FromType(UIButtonType.RoundedRect);
            subscribeButton.Frame = new CGRect(10, 700, w - 20, 44);
            subscribeButton.SetTitle("Subscribe", UIControlState.Normal);
            subscribeButton.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;

            subscribeButton.TouchDown += OnSubscribeClicked;
            aboutButton.TouchDown += OnAboutClicked;

            
            scrollView = new UIScrollView(new CGRect(0, 0, View.Frame.Width, View.Frame.Height));
            scrollView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
            scrollView.ContentSize = new CGSize(View.Frame.Width, 760);

            scrollView.AddSubview(new UILabel(new CGRect(0, 0, View.Frame.Width, 50))
            {
                Text = "BasicLinked",
                Font = UIFont.BoldSystemFontOfSize(36),
                TextAlignment = UITextAlignment.Center,
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth
            });

            scrollView.AddSubview(aboutButton);

            scrollView.AddSubview(new UILabel(new CGRect(10, 120, View.Frame.Width, 50))
            {
                Text = "Introduction",
                Font = UIFont.BoldSystemFontOfSize(24),
                TextAlignment = UITextAlignment.Left,
                TextColor = UIColor.Black,
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth
            });

            scrollView.AddSubview(new UILabel(new CGRect(10, 120, View.Frame.Width - 20, 150))
            {
                Text = "This application demonstrates common calls used in a Nami enabled application.",
                Font = UIFont.SystemFontOfSize(18),
                TextAlignment = UITextAlignment.Left,
                TextColor = UIColor.Black,
                AutoresizingMask = UIViewAutoresizing.All,
                LineBreakMode = UILineBreakMode.WordWrap,
                Lines = 0
            });

            
            scrollView.AddSubview(new UILabel(new CGRect(10, 250, View.Frame.Width - 20, 50))
            {
                Text = "Instructions",
                Font = UIFont.BoldSystemFontOfSize(24),
                TextAlignment = UITextAlignment.Left,
                TextColor = UIColor.Black,
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth
            });
            
            scrollView.AddSubview(new UILabel(new CGRect(10, 260, View.Frame.Width - 20, 150))
            {
                Text = "If you suspend and resume this app three times in the simulator, an example paywall will be raised - or you can use the Subscribe button below to raise the same paywall.",
                Font = UIFont.SystemFontOfSize(18),
                TextAlignment = UITextAlignment.Left,
                TextColor = UIColor.Black,
                AutoresizingMask = UIViewAutoresizing.All,
                LineBreakMode = UILineBreakMode.WordWrap,
                Lines = 0
            });
            
            scrollView.AddSubview(new UILabel(new CGRect(10, 400, View.Frame.Width - 20, 50))
            {
                Text = "Important Info",
                Font = UIFont.BoldSystemFontOfSize(24),
                TextAlignment = UITextAlignment.Left,
                TextColor = UIColor.Black,
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth
            });
            
            scrollView.AddSubview(new UILabel(new CGRect(10, 450, View.Frame.Width - 20, 150))
            {
                Text = "Any Purchase will be remembered while the application is Active, Suspended, Resume, but cleared when the Application is launched.  \nExamine the application source code for more details on calls used to respond and monitor purchases.",
                Font = UIFont.SystemFontOfSize(18),
                TextAlignment = UITextAlignment.Left,
                TextColor = UIColor.Black,
                AutoresizingMask = UIViewAutoresizing.All,
                LineBreakMode = UILineBreakMode.WordWrap,
                Lines = 0
            });

            subscriptionStatusLabel = new UILabel(new CGRect(10, 600, View.Frame.Width - 20, 50))
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

            NamiEntitlementManager.RegisterChangeHandlerWithEntitlementsChangedHandler((entitlements) =>
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

            NamiPurchaseManager.RegisterWithPurchasesChangedHandler((purchases, state, error) => {

                var pur = new List<NamiPurchase>();

                foreach (var n in purchases)
                {
                    pur.Add(n);
                }

                EvaluateLastPurchaseEvent(pur, state, error?.ToString());
            });

            HandleActiveEntitlements(NamiEntitlementManager.ActiveEntitlements().ToList());
        }

        private void EvaluateLastPurchaseEvent(List<NamiPurchase> activePurchases, NamiPurchaseState namiPurchaseState,string errorMsg)
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

        private void HandleActiveEntitlements(List<NamiEntitlement> activeEntitlements)
        {
            if (activeEntitlements?.Count > 0)
            {
                subscriptionStatusLabel.Text = "Subscription is: Active";
            }
        }

        private void LogCustomerJourneyState()
        {
            var state = NamiCustomerManager.CurrentCustomerJourneyState;

            Console.WriteLine("currentCustomerJourneyState");

            Console.WriteLine($"    formerSubscriber ==> ${state?.FormerSubscriber()}");
            Console.WriteLine($"    inGracePeriod ==> ${state?.InGracePeriod()}");
            Console.WriteLine($"    inIntroOfferPeriod ==> ${state?.InIntroOfferPeriod()}");
            Console.WriteLine($"    inTrialPeriod ==> ${state?.InTrialPeriod()}");            
        }

        private void LogActiveEntitlements(List<NamiEntitlement> activeEntitlements)
        {
            Console.WriteLine("Active entitlements");

            foreach (var ent in activeEntitlements)
            {
                Console.WriteLine($"\tName: {ent.Name}\tReferenceId: {ent.ReferenceID}");
            }
        }

        private void OnSubscribeClicked(object sender, EventArgs e)
        {
            if (NamiPaywallManager.CanRaisePaywall)
            {
                NamiPaywallManager.RaisePaywallFromVC(this);
            }
        }

        private void OnAboutClicked(object sender, EventArgs e)
        {
            this.NavigationController.PushViewController(new AboutViewController(), true);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

