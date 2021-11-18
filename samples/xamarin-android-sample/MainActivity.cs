using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Snackbar;
using Com.Namiml.Paywall;
using NamiML;
using Android.Content;
using System.Collections.Generic;
using System.Diagnostics;
using Com.Namiml;

namespace xamarin_android_sample
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        public const bool AllowAutoRaisingPaywall = true;
        public const string TestExternalIdentifier = "9a9999a9-99aa-99a9-aa99-999a999999a9";
        public const string NamiAppPlatformId = "3d062066-9d3c-430e-935d-855e2c56dd8e";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            NamiConfiguration.Builder builder = new NamiConfiguration.
                Builder(this, NamiAppPlatformId);
            builder.InvokeBypassStore(true);
            builder.InvokeDevelopmentMode(true);

#if DEBUG
            builder.InvokeLogLevel(NamiLogLevel.Debug);
#endif
            Nami.Configure(builder.Build());

            NamiPaywallManager.RegisterPaywallRaiseListener(
                new KtFunc4<Context, NamiPaywall, IJavaObject, Java.Lang.String>(
                    (context, paywall, skus, text) => Debugger.Break()));

            NamiPaywallManager.RegisterApplicationAutoRaisePaywallBlocker(
                new KtFunc0<Java.Lang.Boolean>(() => Java.Lang.Boolean.ValueOf(AllowAutoRaisingPaywall)));
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View)sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (View.IOnClickListener)null).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
