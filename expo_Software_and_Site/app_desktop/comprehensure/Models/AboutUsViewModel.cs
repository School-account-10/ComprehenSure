using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace comprehensure.DataBaseControl.Models
{
    public partial class AboutUsViewModel : ObservableObject
    {
        [RelayCommand]
        public async Task Back()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}