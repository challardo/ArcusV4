using Arcus.Views;
using Firebase.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Arcus.Services
{
    public class FirebaseHandler
    {
        public static string WebAPIkey = "AIzaSyCe_kz7sjSGLlX0vsu9o-Z9hxiSX0LRy-c";

       public async void LOGIN(string Email, string Password)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(Email, Password);
                var content = await auth.GetFreshAuthAsync();
                var serializedContent = JsonConvert.SerializeObject(content);
                Preferences.Set("FirebaseRefreshToken", serializedContent);
                
                LogIn logIn = new LogIn();
                await logIn.Navigation.PushAsync(new Welcome());
                

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Invalid email or password", "OK");
                //reset password para implementar luego
                //var Resetpwd = await authProvider.ChangeUserPassword(idToken, password);
            }
        }

        async void SIGNUP(string Email, string Password)
        {
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(Email, Password);
                string gettoken = auth.FirebaseToken;
                await App.Current.MainPage.DisplayAlert("Alert", "Successfully register", "OK");

                SignIn signIn = new SignIn();
               // await Navigation.PushAsync(new LogIn());
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            }
        }

        async private void GetRefreshToken()
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
            try
            {
                var savedfirebaseauth = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>(Preferences.Get("MyFirebaserefreshToken", ""));

                var RefreshContent = await authProvider.RefreshAuthAsync(savedfirebaseauth);
                Preferences.Set("MyFirebaserefreshToken", JsonConvert.SerializeObject(RefreshContent));
            }
            catch (Exception ex)
            {

            }
        }

    }
}
