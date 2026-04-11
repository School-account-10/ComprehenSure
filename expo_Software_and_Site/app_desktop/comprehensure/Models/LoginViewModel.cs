using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;


namespace comprehensure.DataBaseControl.Models
{

    public partial class LoginViewModel : ObservableObject
    {
        private readonly FirebaseAuthClient _authClient;



        public async Task Toastshow(string showtext) // this part does not work in windows 
        {

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();


            ToastDuration duration = ToastDuration.Long;
            double fontSize = 14;

            var toast = Toast.Make(showtext, duration, fontSize);

            await toast.Show(cancellationTokenSource.Token);

        }
        public async Task getms()
        {
            string dateString = DateTime.Now.ToString("M/d/yyyy h:mm:ss.fff tt");
            DateTime dateValue = DateTime.Parse(dateString);
            DateTimeOffset dateOffsetValue = DateTimeOffset.Parse(dateString);
            string timems = ($"{dateValue.ToString("fff")}");
            
            if (DeviceInfo.Current.Platform == DevicePlatform.Android)
            {
                _ = Toastshow($"Ms Checker Login UserName now completed in: {timems} MS ");
            }
            else
            {
                await Shell.Current.DisplayAlert("Ms Checker", $"Login completed in: {timems} MS", "OK");
            }
        }

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
                _ = getms();
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