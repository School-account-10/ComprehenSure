using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace comprehensure.DataBaseControl.Models
{
    public partial class ProfileDashboardViewModel : ObservableObject
    {
        [RelayCommand]
        private async Task logout()
        {
            Preferences.Default.Clear();
            await Shell.Current.GoToAsync("///MainPage");
        }
    }


}
