using Firebase.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Arcus.Services;

namespace Arcus.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogIn : ContentPage
    {
        string WebAPIkey = FirebaseHandler.WebAPIkey;
        //public string WebAPIkey = "AIzaSyCe_kz7sjSGLlX0vsu9o-Z9hxiSX0LRy-c";

        public LogIn()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Shell.SetTabBarIsVisible(this, false);
            Shell.SetNavBarIsVisible(this, false);
            
        }
        async void Register_Pressed(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignIn());
        }

        
        async void loginbutton_clicked(System.Object sender, System.EventArgs e)
        {
            //FirebaseHandler FH = new FirebaseHandler();
            //    FH.LOGIN(UserEmail.Text, UserPassword.Text);


            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(UserEmail.Text, UserPassword.Text);
                var content = await auth.GetFreshAuthAsync();
                var serializedContent = JsonConvert.SerializeObject(content);
                Preferences.Set("FirebaseRefreshToken", serializedContent);
                await Navigation.PushAsync(new Welcome());

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Invalid email or password", "OK");
                //reset password para implementar luego
                //var Resetpwd = await authProvider.ChangeUserPassword(idToken, password);
            }
        }
    }
}