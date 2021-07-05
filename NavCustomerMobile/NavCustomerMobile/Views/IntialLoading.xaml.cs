using NavCustomerMobileModel;
using NavCustomerMobileModel.AccessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NavCustomerMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IntialLoading : ContentPage
    {
        private ApiToken apiToken;
        private GetClientDetailsForMobileResponse getClientDetailsForMobile;
        string _token;
        bool IsUpdatesAvailable;
        string currentVersion;

        public IntialLoading()
        {
            InitializeComponent();

            if (!App.Current.Properties.ContainsKey("CustomerId"))
            {
                App.Current.Properties.Add("CustomerId", 0);
            }

            //if (!App.Current.Properties.ContainsKey("InquiryID"))
            //{
            //    App.Current.Properties.Add("InquiryID", 0);
            //}
            currentVersion = VersionTracking.CurrentVersion;
           
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var list = new List<SlidePageItems>
            {
               new SlidePageItems(){ id=0,label= "Welcome to our app. ",imageMobile="welcomeSlide.jpg",imageTap="NavCustomerMobile.Assets.EzLogo.png",Skiplabel="Skip"},
                 new SlidePageItems(){ id=1,label="We are providing luxury rental services. ",imageMobile="carSlide.jpg",imageTap="NavCustomerMobile.Assets.EzLogo.png", Skiplabel="Skip"},
                   new SlidePageItems(){ id=2,label= "Beautiful yacht and exotic cars are here for your enjoyment. ",imageMobile="yachtSlide.jpg",imageTap="NavCustomerMobile.Assets.EzLogo.png", Skiplabel="Next"}
            };
            TheCarousel.ItemsSource = list;

        }

        private void skipLabelTap_Tapped(object sender, EventArgs e)
        {
            var obj = (Label)sender;
            SlidePageItems tappedPage = obj.BindingContext as SlidePageItems;
            if (tappedPage.id == 2)
            {
                Navigation.PushAsync(new LoginPage());
            }
            else
            {
                TheCarousel.ScrollTo(2);
            }
        }
    }

    public class SlidePageItems
    {
        public int id { get; set; }
        public string label { get; set; }
        public string Skiplabel { get; set; }
        public string imageMobile { get; set; }
        public string imageTap { get; set; }
    }
}