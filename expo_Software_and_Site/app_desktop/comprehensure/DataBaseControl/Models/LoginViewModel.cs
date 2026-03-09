using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;


namespace comprehensure.DataBaseControl.Models
{

    public partial class LoginViewModel : ObservableObject
    {
        private readonly FirebaseAuthClient _authClient;

        public LoginViewModel(FirebaseAuthClient authClient)
        {
            _authClient = authClient;
        }


        [ObservableProperty]
        private string _Password;

        [ObservableProperty]
        private string _Email;


        [RelayCommand]
        private async Task Login()
        {

            string emailcl = _Email?.Trim();
            string passwordcl = _Password?.Trim();

            try
            {
                await _authClient.SignInWithEmailAndPasswordAsync(emailcl, passwordcl);
                await Shell.Current.GoToAsync("MainDashboard");
                await Shell.Current.DisplayAlert("Login COMPLETE", "LOGIN COMPLETE: " + emailcl, "OK");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("SIGNUP FAIL", ex.Message, "OK");
            }

        }
    }
}


