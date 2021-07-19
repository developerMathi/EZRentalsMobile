using NavCustomerMobile.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Push;
using NavCustomerMobileModel.AccessModels;
using NavCustomerMobileController;
using Rg.Plugins.Popup.Services;
using NavCustomerMobileModel;
using NavCustomerMobile.Popups;
using Xamarin.Essentials;

namespace NavCustomerMobile
{
    public partial class App : Xamarin.Forms.Application
    {
        private ApiToken apiToken;
        private GetClientDetailsForMobileResponse getClientDetailsForMobile;

        public App(string pagename, string data)
        {
            Xamarin.Forms.Application.Current.On<Xamarin.Forms.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);

            InitializeComponent();

            var currentVersion = VersionTracking.CurrentVersion;

            if (!App.Current.Properties.ContainsKey("IsOnborded"))
            {
                App.Current.Properties.Add("IsOnborded", false);
            }


            MainPage = new NavigationPage(new Productor());










        }

        protected override void OnStart()
        {
            // Handle when your app starts
            AppCenter.Start("6c941890-4bb2-4f03-8adb-36ba3eb26b5d", typeof(Push));

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
