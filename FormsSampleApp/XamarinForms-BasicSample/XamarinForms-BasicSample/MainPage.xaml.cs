using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinForms_BasicSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void OnAboutButtonClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new AboutView());
        }

        void OnSubscribeButtonClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new SubscribeView());
        }
    }
}
