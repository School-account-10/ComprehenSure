using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;


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
                var result = await _authClient.SignInWithEmailAndPasswordAsync(emailcl, passwordcl);

                Preferences.Default.Set("SavedUserUid", result.User.Uid);
                Preferences.Default.Set("SavedUserEmail", emailcl);
                Preferences.Default.Set("IsFirstLogin", true);

                await Shell.Current.GoToAsync("MainDashboard");
                await Shell.Current.DisplayAlert("Login Complete", "Welcome, " + emailcl, "OK");
            }

            catch (System.Exception ex)
            {
                string raw = ex.Message;
                string readable = raw.Contains(":") ? raw.Split(':').Last().Trim() : raw;
                await Shell.Current.DisplayAlert("Login Failed", readable, "OK");
            }
        }

    }
}