using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using Microsoft.Maui.Controls;

namespace comprehensure.DataBaseControl.Models
{
    public partial class ModulesDashboardViewModel : ObservableObject
    {
        [RelayCommand]
        public async Task startmodule1()
        {
            await Shell.Current.GoToAsync("///StoryPage1");
        }

        [RelayCommand]
        public async Task startmodule2()
        {
            await Shell.Current.GoToAsync("///StoryPage2");
        }

        [RelayCommand]
        public async Task startmodule3()
        {
            await Shell.Current.GoToAsync("///StoryPage3");
        }

        [RelayCommand]
        public async Task startmodule4()
        {
            await Shell.Current.GoToAsync("///StoryPage4");
        }

        [RelayCommand]
        public async Task startmodule5()
        {
            await Shell.Current.GoToAsync("///StoryPage5");
        }

        [RelayCommand]
        public async Task startmodule6()
        {
            await Shell.Current.GoToAsync("///StoryPage6");
        }

        [RelayCommand]
        public async Task startmodule7()
        {
            await Shell.Current.GoToAsync("///StoryPage7");
        }

        [RelayCommand]
        public async Task startmodule8()
        {
            await Shell.Current.GoToAsync("///StoryPage8");
        }

        

    }
}
