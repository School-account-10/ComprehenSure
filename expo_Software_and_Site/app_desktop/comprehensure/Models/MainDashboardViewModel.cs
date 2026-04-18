using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Text.Json;

namespace comprehensure.DataBaseControl.Models
{
    [QueryProperty(nameof(firstlogin), "firstwelcome")]
    public partial class MainDashboardViewModel : ObservableObject
    {
        private readonly string projectId = "comprehensuredb";
        private string BaseUrl =>
            $"https://firestore.googleapis.com/v1/projects/{projectId}/databases/(default)/documents";
        private readonly HttpClient client = new HttpClient();

        [ObservableProperty]
        private string _UsernameEdit;

        [ObservableProperty]
        private int _score;

        [ObservableProperty]
        public Boolean firstlogin = false;

        [ObservableProperty]
        private double _strokeOffset = 100;

        [ObservableProperty]
        private int _moduleFinished;

        private readonly int _moduleCount = 8;
        private readonly int score_count_max = 80;

        [ObservableProperty]
        private string _displayPercentage = "0%";

        [RelayCommand]
        public async Task modules()
        {
            await Shell.Current.GoToAsync("///ModuleDashboard");
        }

        public async Task Toastshow(string showtext)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            ToastDuration duration = ToastDuration.Long;
            double fontSize = 14;
            var toast = Toast.Make(showtext, duration, fontSize);
            await toast.Show(cancellationTokenSource.Token);
        }

        public MainDashboardViewModel()
        {
            _ = CalculateProgress();
        }

        public async Task OnAppearing()
        {
            await Task.Delay(350);

            bool redirected = await RedirectIfNoUsername();
            if (redirected) return;

            await changedisplayname();
            await showloginwelcome();
        }


        private async Task<bool> RedirectIfNoUsername()
        {
            string uid = Preferences.Default.Get("SavedUserUid", "");
            string email = Preferences.Default.Get("SavedUserEmail", "");

            if (string.IsNullOrEmpty(uid))
            {
                await Shell.Current.GoToAsync("///MainPage");
                return true;
            }

            string url = $"{BaseUrl}/userdata/{uid}";
            try
            {
                var response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    await Shell.Current.GoToAsync($"///UsernameReq?email={email}&uid={uid}");
                    return true;
                }

                var json = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(json);
                var fields = doc.RootElement.GetProperty("fields");

                if (fields.TryGetProperty("UserHasUserName", out var hasUserNameProp))
                    if (hasUserNameProp.TryGetProperty("booleanValue", out var boolVal) && !boolVal.GetBoolean())
                    {
                        await Shell.Current.GoToAsync($"///UsernameReq?email={email}&uid={uid}");
                        return true;
                    }

                if (fields.TryGetProperty("Username", out var usernameProp))
                {
                    string username = usernameProp.GetProperty("stringValue").GetString();
                    if (string.IsNullOrWhiteSpace(username))
                    {
                        await Shell.Current.GoToAsync($"///UsernameReq?email={email}&uid={uid}");
                        return true;
                    }
                }
                else
                {
                    await Shell.Current.GoToAsync($"///UsernameReq?email={email}&uid={uid}");
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        private async Task<string> GetUsername()
        {
            string myUid = Preferences.Default.Get("SavedUserUid", "");
            if (string.IsNullOrEmpty(myUid))
                return "Not Logged In";

            string url = $"{BaseUrl}/userdata/{myUid}";
            try
            {
                var response = await client.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                    return null;

                var json = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(json);

                return doc
                    .RootElement.GetProperty("fields")
                    .GetProperty("Username")
                    .GetProperty("stringValue")
                    .GetString();
            }
            catch
            {
                return null;
            }
        }

        public async Task changedisplayname()
        {
            string fetchedName = await GetUsername();
            _ = getms();

            if (!string.IsNullOrEmpty(fetchedName))
                UsernameEdit = fetchedName;
            else
            {
                UsernameEdit = "User not found";
                await Shell.Current.DisplayAlert("Error", "Could not find user data.", "OK");
            }
        }

        public int valuecheck()
        {
            if (ModuleFinished < 0) ModuleFinished = 0;
            else if (ModuleFinished > _moduleCount) ModuleFinished = 8;
            return ModuleFinished;
        }

        public async Task getms()
        {
            string dateString = DateTime.Now.ToString("M/d/yyyy h:mm:ss.fff tt");
            DateTime dateValue = DateTime.Parse(dateString);
            string timems = dateValue.ToString("fff");

            if (DeviceInfo.Current.Platform == DevicePlatform.Android)
                _ = Toastshow($"Ms Checker Get UserName now completed in: {timems} MS");
            else
                await Shell.Current.DisplayAlert("Ms Checker", $"Get UserName now completed in: {timems} MS", "OK");
        }

        [RelayCommand]
        public async Task ProfileDashboard()
        {
            await Shell.Current.GoToAsync("///ProfileDashboard");
        }

        [RelayCommand]
        private async Task AddValue()
        {
            ModuleFinished++;
           
            await modulescoredb();
        }

        [RelayCommand]
        private async Task SubtractValue()
        {
            ModuleFinished--;

            
            await modulescoredb();
        }

        public async Task CalculateProgress()
        {
            _ = valuecheck();
            float resultModule = ((float)ModuleFinished / _moduleCount) * 100;
            StrokeOffset = -ModuleFinished * 4.9;
            DisplayPercentage = $"{resultModule}%";
        }

        public async Task showloginwelcome()
        {
            string fetchedName = await GetUsername();
            bool isFirst = Preferences.Default.Get("IsFirstLogin", false);
            if (isFirst)
            {
                await Shell.Current.DisplayAlert("Success", $"Welcome back, {fetchedName}", "OK");
                Preferences.Default.Set("IsFirstLogin", false);
            }
        }

        public async Task modulescoredb()
        {
            {
                string uid = Preferences.Default.Get("SavedUserUid", "");

                if (string.IsNullOrEmpty(uid)) return;

                valuecheck();

                string url = $"{BaseUrl}/userdata/{uid}?updateMask.fieldPaths=ModuleFinished";

                var data = new
                {
                    fields = new
                    {
                        ModuleFinished = new { integerValue = ModuleFinished.ToString() }
                    }
                };

                var options = new System.Text.Json.JsonSerializerOptions { PropertyNamingPolicy = null };
                var json = System.Text.Json.JsonSerializer.Serialize(data, options);

                // error catcher
                try
                {
                    var response = await client.PatchAsync(
                        url,
                        new System.Net.Http.StringContent(json, System.Text.Encoding.UTF8, "application/json")
                    );

                    if (!response.IsSuccessStatusCode)
                    {
                        string error = await response.Content.ReadAsStringAsync();
                        System.Diagnostics.Debug.WriteLine($"[modulescoredb] Save failed: {error}");
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine($"[modulescoredb] Saved ModuleFinished = {ModuleFinished}");
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"[modulescoredb] Exception: {ex.Message}");
                }
            }
        }

        public async Task LoadModuleFinishedFromDb()
        {
            string uid = Preferences.Default.Get("SavedUserUid", "");
            if (string.IsNullOrEmpty(uid)) return;

            string url = $"{BaseUrl}/userdata/{uid}";
            try
            {
                var response = await client.GetAsync(url);
                if (!response.IsSuccessStatusCode) return;

                var json = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(json);
                var fields = doc.RootElement.GetProperty("fields");

                if (fields.TryGetProperty("ModuleFinished", out var moduleProp))
                {
                    string raw = moduleProp.GetProperty("integerValue").GetString();
                    if (int.TryParse(raw, out int value))
                    {
                        ModuleFinished = value;
                        await CalculateProgress();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[LoadModuleFinished] {ex.Message}");
            }
        }

        private CancellationTokenSource _refreshCts;

        public void StartAutoRefresh()
        {
            _refreshCts = new CancellationTokenSource();
            _ = AutoRefreshLoop(_refreshCts.Token);
        }

        public void StopAutoRefresh()
        {
            _refreshCts?.Cancel();
        }

        private async Task AutoRefreshLoop(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                
                await Task.Delay(1000, token).ContinueWith(_ => { });
                if (!token.IsCancellationRequested)
                    await LoadModuleFinishedFromDb();
            }
        }
    }

}
