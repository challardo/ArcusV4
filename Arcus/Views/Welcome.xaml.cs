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
    public partial class Welcome : ContentPage
    {
        string WebAPIkey = FirebaseHandler.WebAPIkey;
       // public string WebAPIkey = "AIzaSyCe_kz7sjSGLlX0vsu9o-Z9hxiSX0LRy-c";
        public Welcome()
        {
            InitializeComponent();
            
            GetProfileInformationandRefreshToken();
        }
        async private void GetProfileInformationandRefreshToken()
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
            try
            {
                var savedfirebaseauth = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>(Preferences.Get("MyFirebaserefreshToken",""));

                var RefreshContent = await authProvider.RefreshAuthAsync(savedfirebaseauth);
                Preferences.Set("MyFirebaserefreshToken", JsonConvert.SerializeObject(RefreshContent));
            }
            catch(Exception ex)
            {

            }
        }

        async private void BtnInsercion_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Productos());
        }
    }
}