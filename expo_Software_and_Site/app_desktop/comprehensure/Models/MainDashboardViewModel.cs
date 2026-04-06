
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
    
    
    public partial class MainDashboardViewModel : ObservableObject
    {
      

        private readonly string projectId = "comprehensuredb";
        private string BaseUrl => $"https://firestore.googleapis.com/v1/projects/{projectId}/databases/(default)/documents";
        private readonly HttpClient client = new HttpClient();

        [ObservableProperty]
        private string _UsernameEdit;


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
        public async Task OnAppearing()
        {
            
            await changedisplayname();
        }

        private async Task<string> GetUsername()
        {
            // Retrieve the UID from storage
            string myUid = Preferences.Default.Get("SavedUserUid", "");

            if (string.IsNullOrEmpty(myUid))
            {
                return "Not Logged In";
            }

            
            string url = $"{BaseUrl}/userdata/{myUid}";

            try
            {
                var response = await client.GetAsync(url);
                if (!response.IsSuccessStatusCode) return null;

                var json = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(json);

               
                return doc.RootElement
                    .GetProperty("fields")
                    .GetProperty("Username")
                    .GetProperty("stringValue")
                    .GetString();
            }
            catch (Exception ex)
            {
                return "Error loading profile";
            }
        }


        public async Task changedisplayname()
        {
            
            string fetchedName = await GetUsername();

            
            if (!string.IsNullOrEmpty(fetchedName))
            {
                
                UsernameEdit = fetchedName;

                
                await Shell.Current.DisplayAlert("Success", $"Welcome back, {fetchedName}!", "OK");
            }
            else
            {
               
                UsernameEdit = "User not found";
                await Shell.Current.DisplayAlert("Error", "Could not find user data.", "OK");
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