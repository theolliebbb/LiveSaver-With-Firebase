using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Firebase.Auth;
using LiveSaves.Models;
using SQLite;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PancakeView;

namespace LiveSaves.Views
{
    public partial class Forgot : ContentPage
    {
        
        RegUser userDetails;
        /*UserRepository _userRepository = new UserRepository();*/
        string WebAPIKey = "AIzaSyB0ZLUCEGmH5WRdwPr38QflIT4l8c6721c";
        public Forgot()
        {
            InitializeComponent();
            
        }
        public async Task<bool>ResetPassword(string email)
        {
            email = InputUser.Text;
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIKey));

            await authProvider.SendPasswordResetEmailAsync(email);
            return true;
        }
        async void ForgotButton_Clicked(System.Object sender, System.EventArgs e)
        {
            
        }

        private async void ButtonSendLink_Clicked(object sender, EventArgs e)
        {
            string email = InputUser.Text;
            
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIKey));
            try
            {
                await authProvider.SendPasswordResetEmailAsync(email);
                await App.Current.MainPage.DisplayAlert("Success!", "Password Reset Link has been sent!", "OK");
                App.Current.MainPage = new NavigationPage(new LoginPage());
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error!", "Invalid E-Mail", "OK");
            }
            
        }


        void ConfirmButton_Clicked(System.Object sender, System.EventArgs e)
        {
            if (Pass.Text != null)
            {
                var lowerPass = Pass.Text.ToLower();
                var upperPass = Pass.Text.ToUpper();

                {
                    if (Pass.Text != Pass2.Text)
                    {

                        DisplayAlert("Error!", "Your Passwords Do Not Match!!", "Try Again!");
                        Pass.Text = null;
                        Pass2.Text = null;
                    }
                    else if (Pass.Text == null || Pass2.Text == null)
                    {

                        DisplayAlert("Error!", "Please Input All Fields!", "Try Again!");
                        Pass.Text = null;
                        Pass2.Text = null;
                    }
                    else if (InputUser.Text == Pass.Text)
                    {

                        DisplayAlert("Error!", "UserName and Password cannot be identical!", "Try Again!");

                        Pass.Text = null;
                        Pass2.Text = null;
                    }


                    else if (lowerPass == Pass.Text || upperPass == Pass.Text)
                    {

                        DisplayAlert("Error!", "Make sure your password contains both Upper and Lowercase Letters!", "Try Again!");

                        Pass.Text = null;
                        Pass2.Text = null;
                    }
                    else if (Pass.Text.Length <= 7)
                    {

                        DisplayAlert("Error!", "Make sure your password is at least 8 characters!", "Try Again!");

                        Pass.Text = null;
                        Pass2.Text = null;
                    }


                    else
                    {

                       

                        DisplayAlert("Success", "Password Successfully Changed!", "ok");



                        App.Current.MainPage = new NavigationPage(new LoginPage());

                    }
                }
            }
        }

        void BackButton_Clicked(System.Object sender, System.EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}
