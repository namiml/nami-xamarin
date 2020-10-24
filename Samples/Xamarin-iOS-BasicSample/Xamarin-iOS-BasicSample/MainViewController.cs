using System;
using CoreGraphics;
using UIKit;
using Binding;

namespace Xamarin_iOS_BasicSample
{
    public partial class MainViewController : UIViewController
    {
        public MainViewController() : base("MainViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            BuildUI();
        }

        private void BuildUI() {

            var titleView = new UIImageView(UIImage.FromBundle("nami_logo_white"))
            {
                BackgroundColor = new UIColor(red: 0.25f, green: 0.43f, blue: 0.49f, alpha: 1.00f),
                ContentMode = UIViewContentMode.ScaleAspectFit,
            };

            base.NavigationItem.TitleView = titleView;

            nfloat h = 31.0f;
            nfloat w = View.Bounds.Width;

            var aboutButton = UIButton.FromType(UIButtonType.RoundedRect);
            aboutButton.Frame = new CGRect(10, 50, w - 20, 44);
            aboutButton.SetTitle("About", UIControlState.Normal);
            aboutButton.BackgroundColor = UIColor.White;
            aboutButton.Layer.CornerRadius = 5f;
            aboutButton.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;

            var subscribeButton = UIButton.FromType(UIButtonType.RoundedRect);
            subscribeButton.Frame = new CGRect(10, 700, w - 20, 44);
            subscribeButton.SetTitle("Subscribe", UIControlState.Normal);
            subscribeButton.BackgroundColor = UIColor.White;
            subscribeButton.Layer.CornerRadius = 5f;
            subscribeButton.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;

            subscribeButton.TouchDown += OnSubscribeClicked;
            aboutButton.TouchDown += OnAboutClicked;

            
            var scroll = new UIScrollView(new CGRect(0, 0, View.Frame.Width, View.Frame.Height));
            scroll.AutoresizingMask = UIViewAutoresizing.All;

            scroll.AddSubview(new UILabel(new CGRect(0, 0, View.Frame.Width, 50))
            {
                Text = "BasicLinked",
                Font = UIFont.BoldSystemFontOfSize(36),
                TextAlignment = UITextAlignment.Center,
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth
            });

            scroll.AddSubview(aboutButton);

            scroll.AddSubview(new UILabel(new CGRect(10, 120, View.Frame.Width, 50))
            {
                Text = "Introduction",
                Font = UIFont.BoldSystemFontOfSize(24),
                TextAlignment = UITextAlignment.Left,
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth
            });

            scroll.AddSubview(new UILabel(new CGRect(10, 50, View.Frame.Width, 150))
            {
                Text = "This application demonstrates common calls used in a Nami enabled application.",
                Font = UIFont.SystemFontOfSize(18),
                TextAlignment = UITextAlignment.Left,
                AutoresizingMask = UIViewAutoresizing.All,
                LineBreakMode = UILineBreakMode.WordWrap,
                Lines = 0
            });

            scroll.AddSubview(new UILabel(new CGRect(10, 250, View.Frame.Width, 50))
            {
                Text = "Instructions",
                Font = UIFont.BoldSystemFontOfSize(24),
                TextAlignment = UITextAlignment.Left,
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth
            });

            scroll.AddSubview(new UILabel(new CGRect(10, 150, View.Frame.Width, 150))
            {
                Text = "If you suspend and resume this app three times in the simulator, an example paywall will be raised - or you can use the Subscribe button below to raise the same paywall.",
                Font = UIFont.SystemFontOfSize(18),
                TextAlignment = UITextAlignment.Left,
                AutoresizingMask = UIViewAutoresizing.All,
                LineBreakMode = UILineBreakMode.WordWrap,
                Lines = 0
            });

            scroll.AddSubview(new UILabel(new CGRect(10, 400, View.Frame.Width, 50))
            {
                Text = "Important Info",
                Font = UIFont.BoldSystemFontOfSize(24),
                TextAlignment = UITextAlignment.Left,
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth
            });

            scroll.AddSubview(new UILabel(new CGRect(10, 270, View.Frame.Width, 150))
            {
                Text = "Any Purchase will be remembered while the application is Active, Suspended, Resume, but cleared when the Application is launched.  \nExamine the application source code for more details on calls used to respond and monitor purchases.",
                Font = UIFont.SystemFontOfSize(18),
                TextAlignment = UITextAlignment.Left,
                AutoresizingMask = UIViewAutoresizing.All,
                LineBreakMode = UILineBreakMode.WordWrap,
                Lines = 0
            });

            scroll.AddSubview(new UILabel(new CGRect(10, 600, View.Frame.Width, 50))
            {
                Text = "Subscription is: Inactive",
                Font = UIFont.BoldSystemFontOfSize(24),
                TextAlignment = UITextAlignment.Left,
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth
            });

            scroll.AddSubview(subscribeButton);
            
            this.View.AddSubview(scroll);
            
        }

        private void OnSubscribeClicked(object sender, EventArgs e)
        {
            if (NamiPaywallManager_Nami_Swift_1660.CanRaisePaywall)
            {
                NamiPaywallManager_Nami_Swift_1660.RaisePaywallFromVC(new NamiPaywallManager(),this);
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

