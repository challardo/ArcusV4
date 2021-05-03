using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Arcus.Views
{
    public partial class AboutPage : ContentPage
    {
        
        public AboutPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            //Shell.SetTabBarIsVisible(this, false);
           // Shell.SetNavBarIsVisible(this, false);
        }

        private void Button_Pressed(object sender, EventArgs e)
        {

        }
        async void Register_Pressed(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignIn());
        }
    }
}