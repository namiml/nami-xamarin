using System;
using CoreGraphics;
using UIKit;
using Binding;

namespace Xamarin_iOS_BasicSample
{
    public class AboutViewController : UIViewController
    {
        NamiMLManager nami;

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            NamiMLManager_Nami_Swift_1607.EnterCoreContentWithLabel(nami, "About");
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //  nami = new NamiMLManager();
            
            this.Title = "About";
            this.View.BackgroundColor = UIColor.White;

            this.View.AddSubview(new UILabel(new CGRect(10, 100, View.Frame.Width, 50))
            {
                Text = "Introduction",
                Font = UIFont.BoldSystemFontOfSize(24),
                TextAlignment = UITextAlignment.Left,
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth
            });

            this.View.AddSubview(new UILabel(new CGRect(10, 100, View.Frame.Width, 150))
            {
                Text = "This application demonstrates common calls used in a Nami enabled application.",
                Font = UIFont.SystemFontOfSize(18),
                TextAlignment = UITextAlignment.Left,
                AutoresizingMask = UIViewAutoresizing.All,
                LineBreakMode = UILineBreakMode.WordWrap,
                Lines = 0
            });
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            NamiMLManager_Nami_Swift_1607.ExitCoreContentWithLabel(nami, "About");
        }
    }
}
