using System;
using Firebase.Auth;
using Xamarin.Forms;

namespace LiveSaves.Views
{
    public partial class RegistrationPage : ContentPage
    {
        string WebAPIKey = "AIzaSyB0ZLUCEGmH5WRdwPr38QflIT4l8c6721c";
        public RegistrationPage()
        {
            InitializeComponent();
            
        }

        static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

  

     

        async void Register_Clicked(object sender, System.EventArgs e)
        {
            
            
            if (Pass.Text != null)
            {
                var lowerPass = Pass.Text.ToLower();
                var upperPass = Pass.Text.ToUpper();

                {
                    if (Pass.Text != Pass2.Text)
                    {
                        BadPass.IsVisible = false;
                        
                        NoEmail.IsVisible = false;
                        NoPass.IsVisible = false;
                        NoPass2.IsVisible = false;
                        DisplayAlert("Error!", "Your Passwords Do Not Match!!", "Try Again!");
                        Pass.Text = null;
                        Pass2.Text = null;
                    }
                    else if (Pass.Text == null || Pass2.Text == null || Email.Text == null)
                    {
                        BadPass.IsVisible = false;
                        
                        NoEmail.IsVisible = false;
                        NoPass.IsVisible = false;
                        NoPass2.IsVisible = false;
                        DisplayAlert("Error!", "Please Input All Fields!", "Try Again!");
                        
                    }
                    else if (Email.Text == Pass.Text)
                    {
                        BadPass.IsVisible = false;
                        
                        NoEmail.IsVisible = false;
                        NoPass.IsVisible = false;
                        NoPass2.IsVisible = false;
                        DisplayAlert("Error!", "UserName and Password cannot be identical!", "Try Again!");
                        
                        Pass.Text = null;
                        Pass2.Text = null;
                    }

                    else if (IsValidEmail(Email.Text) == false)
                    {
                        BadPass.IsVisible = false;
                       
                        NoEmail.IsVisible = false;
                        NoPass.IsVisible = false;
                        NoPass2.IsVisible = false;
                        DisplayAlert("Error!", "Please Input Valid Email!", "Try Again!");
                        NoEmail.IsVisible = true;
                        Email.Text = null;
                    }


                    else if (lowerPass == Pass.Text || upperPass == Pass.Text)
                    {
                        BadPass.IsVisible = false;
                        
                        NoEmail.IsVisible = false;
                        NoPass.IsVisible = false;
                        NoPass2.IsVisible = false;
                        DisplayAlert("Error!", "Make sure your password contains both Upper and Lowercase Letters!", "Try Again!");
                        BadPass.IsVisible = true;
                        Pass.Text = null;
                        Pass2.Text = null;
                    }
                    else if (Pass.Text.Length <= 7)
                    {
                        BadPass.IsVisible = false;
                        
                        NoEmail.IsVisible = false;
                        NoPass.IsVisible = false;
                        NoPass2.IsVisible = false;
                        DisplayAlert("Error!", "Make sure your password is at least 8 characters!", "Try Again!");
                        BadPass.IsVisible = true;
                        Pass.Text = null;
                        Pass2.Text = null;
                    }
              
                    else
                    {
                        DisplayAlert("Success", "User Successfully Registered", "ok");
                        var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIKey));
                        try
                        { 
                        var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(Email.Text, Pass.Text);
                        string gettoken = auth.FirebaseToken;
                       }
                        catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("oh", "no", "no");
            }
           
                        



                        App.Current.MainPage = new NavigationPage(new LoginPage());
                    };
                }


            }
            else
            {
                DisplayAlert("Error!", "Please Input All Fields!", "Try Again!");
            }
        }

        private void insertorupdate()
        {
            throw new NotImplementedException();
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}