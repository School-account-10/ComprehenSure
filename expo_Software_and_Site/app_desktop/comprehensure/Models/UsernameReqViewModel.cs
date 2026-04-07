using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Firebase.Auth;

namespace comprehensure.DataBaseControl.Models
{
    [QueryProperty(nameof(UserEmail), "email")]
    [QueryProperty(nameof(UserUid), "uid")]
    public partial class UsernameReqViewModel : ObservableObject
    {
        [ObservableProperty]
        private string[] _achievements; // get from quiz with limits, module finished.

        [ObservableProperty]
        private string _userEmail;

        [ObservableProperty]
        private string _userUid;

        [ObservableProperty]
        private string _username;

        [ObservableProperty]
        private string _usertime = DateTime.Now.ToString("yyyy-MM-dd hh:mm tt");
        private string BaseUrl =>
            $"https://firestore.googleapis.com/v1/projects/{projectId}/databases/(default)/documents";
        private readonly HttpClient client = new HttpClient();
        private readonly string projectId = "comprehensuredb";

        public UsernameReqViewModel() { }

        [RelayCommand]
        public async Task UsernameCheck()
        {
            _ = UsernameExists(_username);
        }

        private async Task<bool> UsernameExists(string username)
        {
            Username = Username.Trim().ToLower();

            string url = $"{BaseUrl}:runQuery";

            string json = JsonSerializer.Serialize(
                new
                {
                    structuredQuery = new
                    {
                        from = new[] { new { collectionId = "userdata" } },
                        where = new
                        {
                            fieldFilter = new
                            {
                                field = new { fieldPath = "username" },
                                op = "EQUAL",
                                value = new { stringValue = username },
                            },
                        },
                        limit = 1,
                    },
                }
            );

            HttpResponseMessage response = await client.PostAsync(
                url,
                new StringContent(json, Encoding.UTF8, "application/json")
            );

            string result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                await Shell.Current.DisplayAlert($"Error {(int)response.StatusCode}", result, "OK");
                await Shell.Current.DisplayAlert(
                    "Sign Up",
                    "username note taken Status:  " + "false",
                    "OK"
                );
               _ = UserCreation();
                return false;
            }

            if (string.IsNullOrEmpty(result))
            {
                await Shell.Current.DisplayAlert("text field empty", "Status:  " + "false", "OK");
                return false;
            }

            if (result.Contains("document"))
            {
                await Shell.Current.DisplayAlert("Sign Up", "Status:  " + "true", "OK");
                await Shell.Current.DisplayAlert("Sign Up", "Welcome back " + Username, "OK");
                await Shell.Current.GoToAsync($"MainDashboard?uid={UserUid}&baseUrl={BaseUrl}");
                return true;
            }
            else
            {
                _ = UserCreation();
                return true;
            }
        }

        public async Task UserCreation()
        {
           

            var data = new
            {
                fields = new
                {
                    Username = new { stringValue = Username },
                    Email = new { stringValue = UserEmail },
                    DeviceTimeOfReg = new { stringValue = Usertime },
                    Uid = new { stringValue = UserUid },
                    ServerTimeOfReg = new
                    {
                        stringValue = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"),
                    },
                    ModuleFinished = new { integerValue = "0" },
                    ScoreOfTotal = new { integerValue = "0" },
                    UserHasUserName = new { booleanValue = true },
                },
            };

            var options = new JsonSerializerOptions { PropertyNamingPolicy = null };
            var json = JsonSerializer.Serialize(data, options);

            var response = await client.PatchAsync(
                $"{BaseUrl}/userdata/{UserUid}",
                new StringContent(json, Encoding.UTF8, "application/json")
            );

            string result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                await Shell.Current.DisplayAlert($"Error {(int)response.StatusCode}", result, "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert(
                    "Success",
                    "Account Registered for " + Username,
                    "OK"
                );
                Preferences.Default.Set("SavedUserUid", UserUid);
                Preferences.Default.Set("SavedUserEmail", UserEmail);
                await Shell.Current.GoToAsync($"MainDashboard?uid={UserUid}&baseUrl={BaseUrl}");
            }
        }
    }
}
