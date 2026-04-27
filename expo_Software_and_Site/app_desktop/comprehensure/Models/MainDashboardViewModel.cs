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
        private readonly string projectId = "comprehensuredb-f9f7c";
        private string BaseUrl =>
            $"https://firestore.googleapis.com/v1/projects/{projectId}/databases/(default)/documents";
        private readonly HttpClient client = new HttpClient();

        [ObservableProperty]
        private string firstPlayerName = "—";
        [ObservableProperty]
        private string firstPlayerScore = "0 pts";
        [ObservableProperty]
        private string secondPlayerName = "—";
        [ObservableProperty]
        private string secondPlayerScore = "0 pts";
        [ObservableProperty]
        private string thirdPlayerName = "—";
        [ObservableProperty]
        private string thirdPlayerScore = "0 pts";

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

        // ─────────────────────────────────────────────────────────────────────
        // SCOREBOARD  –  fetch every userdata doc, sort by ScoreOfTotal desc,
        //                then write the top-3 into the bound properties.
        // ─────────────────────────────────────────────────────────────────────

        /// <summary>
        /// Firestore REST API returns integers as { "integerValue": "7" } (string)
        /// but may also return them as a JSON number depending on the SDK version.
        /// This helper handles both safely.
        /// </summary>
        private static int ReadFirestoreInt(JsonElement integerValueElement)
        {
            // String form: "integerValue": "7"
            if (integerValueElement.ValueKind == JsonValueKind.String)
            {
                int.TryParse(integerValueElement.GetString(), out int parsed);
                return parsed;
            }
            // Number form: "integerValue": 7
            if (integerValueElement.ValueKind == JsonValueKind.Number)
                return integerValueElement.GetInt32();

            return 0;
        }

        public async Task scoreboard()
        {
            string url = $"{BaseUrl}/userdata";

            try
            {
                var response = await client.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                {
                    System.Diagnostics.Debug.WriteLine($"[scoreboard] HTTP {(int)response.StatusCode}");
                    return;
                }

                var json = await response.Content.ReadAsStringAsync();
                System.Diagnostics.Debug.WriteLine($"[scoreboard] Raw JSON: {json[..Math.Min(300, json.Length)]}");

                using var doc = JsonDocument.Parse(json);

                // Firestore list response: { "documents": [ { "fields": { … } } ] }
                if (!doc.RootElement.TryGetProperty("documents", out var documents))
                {
                    System.Diagnostics.Debug.WriteLine("[scoreboard] No 'documents' key found — collection may be empty.");
                    return;
                }

                // Build a list of (username, score) pairs
                var entries = new List<(string Name, int Score)>();

                foreach (var document in documents.EnumerateArray())
                {
                    if (!document.TryGetProperty("fields", out var fields))
                        continue;

                    // Username — must exist and not be blank
                    if (!fields.TryGetProperty("Username", out var usernameProp) ||
                        !usernameProp.TryGetProperty("stringValue", out var nameVal))
                        continue;

                    string name = nameVal.GetString() ?? "";
                    if (string.IsNullOrWhiteSpace(name)) continue;

                    // Primary score: ScoreOfTotal (game/quiz score shown in your DB)
                    // Fallback:      ModuleFinished (module progress count)
                    int score = 0;

                    if (fields.TryGetProperty("ScoreOfTotal", out var sotProp) &&
                        sotProp.TryGetProperty("integerValue", out var sotVal))
                    {
                        score = ReadFirestoreInt(sotVal);
                    }
                    else if (fields.TryGetProperty("ModuleFinished", out var mfProp) &&
                             mfProp.TryGetProperty("integerValue", out var mfVal))
                    {
                        score = ReadFirestoreInt(mfVal);
                    }

                    entries.Add((name, score));
                    System.Diagnostics.Debug.WriteLine($"[scoreboard] Loaded: {name} → {score}");
                }

                // Sort descending and take top 3
                var top3 = entries
                    .OrderByDescending(e => e.Score)
                    .Take(3)
                    .ToList();

                // 1st place
                if (top3.Count >= 1)
                {
                    FirstPlayerName  = top3[0].Name;
                    FirstPlayerScore = $"{top3[0].Score} pts";
                }
                else
                {
                    FirstPlayerName  = "—";
                    FirstPlayerScore = "0 pts";
                }

                // 2nd place
                if (top3.Count >= 2)
                {
                    SecondPlayerName  = top3[1].Name;
                    SecondPlayerScore = $"{top3[1].Score} pts";
                }
                else
                {
                    SecondPlayerName  = "—";
                    SecondPlayerScore = "0 pts";
                }

                // 3rd place
                if (top3.Count >= 3)
                {
                    ThirdPlayerName  = top3[2].Name;
                    ThirdPlayerScore = $"{top3[2].Score} pts";
                }
                else
                {
                    ThirdPlayerName  = "—";
                    ThirdPlayerScore = "0 pts";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[scoreboard] Exception: {ex.Message}");
            }
        }

        public async Task OnAppearing()
        {
            
            await Task.Delay(650);

            bool redirected = await RedirectIfNoUsername();
            if (redirected) return;
            await Task.Delay(950);
            await changedisplayname();
            await showloginwelcome();
            await Task.Delay(1050);
            // Load the leaderboard on first display
            await scoreboard();
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
            {
                UsernameEdit = fetchedName;
            }
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

                    // Refresh the leaderboard immediately after a score change
                    await scoreboard();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[modulescoredb] Exception: {ex.Message}");
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
                {
                    await LoadModuleFinishedFromDb();
                    await scoreboard();         // keep leaderboard live
                }
            }
        }
    }
}
