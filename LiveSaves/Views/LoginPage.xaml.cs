using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using Xamarin.Forms.Xaml;
using LiveSaves.Views;
using System.IO;
using LiveSaves.Models;
using Xamarin.Essentials;
using Xamarin.Forms.PancakeView;
using Firebase.Auth;
using Newtonsoft.Json;

namespace LiveSaves.Views
{
    public class UserDisplayName
    {
        
        public static string displayName;

     
    }
    public partial class LoginPage : ContentPage
    {
        string WebAPIKey = "AIzaSyB0ZLUCEGmH5WRdwPr38QflIT4l8c6721c";
        public static string User;
        
        public LoginPage()
        {
            InitializeComponent();
            

        }

        async void ClearAll_Clicked(System.Object sender, System.EventArgs e)
        {

            UserDisplayName.displayName = "local";
            App.Current.MainPage = new NavigationPage(new Items());

        }
        async void Login_Clicked(System.Object sender, System.EventArgs e)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIKey));
            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(InputUser.Text, InputPass.Text);
                var content = await auth.GetFreshAuthAsync();
                var serializedcontent = JsonConvert.SerializeObject(content);
                Preferences.Set("MyFirebaseRefreshToken", serializedcontent);
                UserDisplayName.displayName = InputUser.Text;
                await Navigation.PushAsync(new Items());
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error!", "Invalid Email/Password Combination", "Ok");
            }
        }

        async void Register_Clicked(System.Object sender, System.EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new RegistrationPage());
        }
        async void Forgot_Clicked(System.Object sender, System.EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new Forgot());
        }
    }
}