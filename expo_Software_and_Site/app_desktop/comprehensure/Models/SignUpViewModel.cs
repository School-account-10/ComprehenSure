using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Firebase.Auth;
using Microsoft.Maui.Controls;

namespace comprehensure.DataBaseControl.Models
{
    public partial class SignUpViewModel : ObservableObject
    {
        private readonly FirebaseAuthClient _authClient;

        public SignUpViewModel(FirebaseAuthClient authClient)
        {
            _authClient = authClient;
        }

        [ObservableProperty]
        private string _Password;

        [ObservableProperty]
        private string _Email;


        public async Task UserName_requiremen()
        {

        }


        [RelayCommand]
        private async Task SignUp()
        {
            
            string emailcl = _Email?.Trim();
           
            string passwordcl = _Password?.Trim();

            if (string.IsNullOrEmpty(emailcl))
            {
                await Shell.Current.DisplayAlert("Error", "Please enter an email", "OK");
                return;
            }

            if (!emailcl.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase))
            {
                await Shell.Current.DisplayAlert(
                    "Invalid Email",
                    "Only Gmail accounts are allowed.",
                    "OK"
                );
                return;
            }

            try
            {
                var result = await _authClient.CreateUserWithEmailAndPasswordAsync(emailcl, passwordcl);

                await Shell.Current.DisplayAlert("Sign Up", "Account Registered " + emailcl, "OK");

                await Shell.Current.GoToAsync($"///UsernameReq?email={emailcl}&uid={result.User.Uid}");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Login Failed", ex.Message, "OK");
            }


        }
    }
}
