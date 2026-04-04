using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;



namespace comprehensure.DataBaseControl.Models

{
    public partial class UsernameReqViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _username;


        [RelayCommand]
        public async Task UsernameCheck()
        {
            await Shell.Current.DisplayAlert("Sign Up", "Account Registered " + Username, "OK");
        }

    }
}