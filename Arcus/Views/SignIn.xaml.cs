using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcus.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Arcus.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignIn : ContentPage
    {
        string WebAPIkey = FirebaseHandler.WebAPIkey;
        //public string WebAPIkey = "AIzaSyCe_kz7sjSGLlX0vsu9o-Z9hxiSX0LRy-c";
        public SignIn()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Shell.SetTabBarIsVisible(this, false);
            Shell.SetNavBarIsVisible(this, false);
        }

        async void Register_Click(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new AboutPage());
            await Navigation.PopAsync();
        }

        async void signupbutton_clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(UserNewEmail.Text, UserNewPassword.Text);
                string gettoken = auth.FirebaseToken;
                await App.Current.MainPage.DisplayAlert("Alert","Successfully register", "OK");
                await Navigation.PushAsync(new LogIn());
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            }
        }
    }
}