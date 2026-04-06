
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using comprehensure.DASHBOARD;
using Firebase.Auth;
using System.Buffers.Text;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;


namespace comprehensure.DataBaseControl.Models
{
    [QueryProperty(nameof(UserUid), "useruid")]
    [QueryProperty(nameof(Baseurl), "baseUrl")]
    public partial class MainDashboardViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _userUid;
        [ObservableProperty]
        private string _UsernameEdit;

       [ObservableProperty]
        private string _baseurl;

        [ObservableProperty]
        private int _score;


         
        private readonly HttpClient client = new HttpClient();
        private readonly string projectId = "comprehensuredb";

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
        public async Task OnAppearing()
        {
            await changedisplayname(); 
        }



        private async Task<string> GetUsername()
        {
            string url = $"{Baseurl}/users/{UserUid}";
            HttpResponseMessage response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            else
            {
                _ =changedisplayname();
            }

            string json = await response.Content.ReadAsStringAsync();


            string dbUser = null;

            using (JsonDocument doc = JsonDocument.Parse(json))
            {

                dbUser = doc.RootElement
                    .GetProperty("fields")
                    .GetProperty("username")
                    .GetProperty("stringValue")
                    .GetString();
            }

            await Shell.Current.DisplayAlert("Login fetched prosees", "username" + dbUser, "OK");
            return dbUser;
        }
        public async Task changedisplayname()
        {
           
            string fetchedName = await GetUsername();

            if (fetchedName != null)
            {

                UsernameEdit = fetchedName;
                await Shell.Current.DisplayAlert("Login fetched prosees", "username" + fetchedName, "OK");
            }
            else
            {
               
                UsernameEdit = "USER NOT FOUND(meaning user somehow signed in without acc)";
            }
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
        public async Task ProfileDashboard()
        {
            await Shell.Current.GoToAsync("///ProfileDashboard");
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
            StrokeOffset = -ModuleFinished * 5.5;
            DisplayPercentage = $"{resultModule}%";
        }

    }
}