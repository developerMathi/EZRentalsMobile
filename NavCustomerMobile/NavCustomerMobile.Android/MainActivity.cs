﻿
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using ContextMenu.Droid;
using DLToolkit.Forms.Controls;
using PanCardView.Droid;
using Plugin.CurrentActivity;
using Plugin.FacebookClient;
using Plugin.Permissions;
using Xamarin.Forms;

namespace NavCustomerMobile.Droid
{
    [Activity(Label = "NavCustomerMobile", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = NavCustomerMobile.Droid.Resource.Layout.Tabbar;
            ToolbarResource = NavCustomerMobile.Droid.Resource.Layout.Toolbar;
            CrossCurrentActivity.Current.Init(this, savedInstanceState);

            global::Xamarin.Auth.Presenters.XamarinAndroid.AuthenticationConfiguration.Init(this, savedInstanceState);

            FlowListView.Init();
            base.OnCreate(savedInstanceState);
            Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            CrossCurrentActivity.Current.Init(this, savedInstanceState);
            ContextMenuViewRenderer.Preserve();
            Plugin.InputKit.Platforms.Droid.Config.Init(this, savedInstanceState);
            FacebookClientManager.Initialize(this);
            string pagename = null;
            string data = null;
            if (Intent.Extras != null)
            {
                pagename = Intent.GetStringExtra("PageName") ?? string.Empty;
                data = Intent.GetStringExtra("Data") ?? string.Empty;
            }
            CardsViewRenderer.Preserve();

            Window window = ((MainActivity)Forms.Context).Window;
            window.AddFlags(WindowManagerFlags.KeepScreenOn);
            //if (Intent.Extras != null)
            //{
            //    if (!App.Current.Properties.ContainsKey("NotificationPage"))
            //    {
            //        pagename = null;
            //    }
            //    else
            //    {
            //        pagename= App.Current.Properties["NotificationPage"].ToString();
            //    }

            //    if (!App.Current.Properties.ContainsKey("notificationData"))
            //    {
            //        data = null;
            //    }
            //    else
            //    {
            //        data = App.Current.Properties["notificationData"].ToString();
            //    }
            //}
            LoadApplication(new App(pagename, data));
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent intent)
        {
            base.OnActivityResult(requestCode, resultCode, intent);
            FacebookClientManager.OnActivityResult(requestCode, resultCode, intent);
        }
    }
}