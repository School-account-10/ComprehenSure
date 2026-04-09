using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

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
