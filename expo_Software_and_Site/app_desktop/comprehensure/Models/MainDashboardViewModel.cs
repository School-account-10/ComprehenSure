
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using comprehensure.DASHBOARD;
using System.Reflection;
using System.Threading.Tasks;

namespace comprehensure.DataBaseControl.Models
{
    public partial class MainDashboardViewModel : ObservableObject
    {
        [ObservableProperty]
        private int _score;


        [ObservableProperty]
        private double _strokeOffset = 100;


        [ObservableProperty]
        private int _moduleFinished;

        
        private readonly int _moduleCount = 8;
        private readonly int score_count_max = 80;

        [ObservableProperty]
        private string _displayPercentage = "0%";

        public MainDashboardViewModel()
        {
            _ = CalculateProgress();

        }


        public int valuecheck()
        {
            if (ModuleFinished < 0)
            {
                ModuleFinished = 0;
            }else if (ModuleFinished > _moduleCount)
            {
                ModuleFinished = 8;
            }

            return ModuleFinished;
        }


        [RelayCommand]
        private void AddValue()
        {
            
            _ = CalculateProgress();
            ModuleFinished++;
        }

        [RelayCommand]
        private void SubtractValue()
        {

            _ = CalculateProgress();
            ModuleFinished--;
        }


        public async Task CalculateProgress()
        {

           _ = valuecheck();
            float resultModule = ((float)ModuleFinished / _moduleCount) * 100;
            StrokeOffset = - ModuleFinished * 5.5;
            DisplayPercentage = $"{resultModule}%";
        }
    }
}