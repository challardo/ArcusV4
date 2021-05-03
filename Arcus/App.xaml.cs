using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Arcus.Services;
using Arcus.Views;

namespace Arcus
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            // DependencyService.Register<MockDataStore>();
            //MainPage = new NavigationPage(new LogIn());
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
