using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Com.Namiml;
using Com.Namiml.Paywall;

namespace NamiML_Sample.Droid
{
    [Activity(Label = "NamiML_Sample", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        public const bool AllowAutoRaisingPaywall = true;

        //provide the unique identifier for your customer
        public const string TestExternalIdentifier = "9a9999a9-99aa-99a9-aa99-999a999999a9";

        //provide your Nami app platform ID from your dashboard
        public const string NamiAppPlatformId = "3d062066-9d3c-430e-935d-855e2c56dd8e";


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            NamiConfiguration.Builder builder = new NamiConfiguration.Builder(this, NamiAppPlatformId);
            builder.InvokeBypassStore(true);
            builder.InvokeDevelopmentMode(true);

#if DEBUG
            builder.InvokeLogLevel(NamiLogLevel.Debug);
#endif
            Nami.Configure(builder.Build());

            //NamiPaywallManager.RegisterPaywallRaiseListener(new KtFunc4<Context, NamiPaywall, IJavaObject, Java.Lang.String>((context, paywall, skus, text) => Debugger.Break()));
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}