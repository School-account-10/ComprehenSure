using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace comprehensure.DataBaseControl.Models
{
    public partial class UsernameReqViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _username;
        private string BaseUrl =>
            $"https://firestore.googleapis.com/v1/projects/{projectId}/databases/(default)/documents";
        private readonly HttpClient client = new HttpClient();
        private readonly string projectId = "comprehensuredb";

        [RelayCommand]
        public async Task UsernameCheck()
        {
            await Shell.Current.DisplayAlert("Sign Up", "Account Registered " + Username, "OK");

            var data = new { fields = new { username = new { stringValue = Username } } };

            var json = JsonSerializer.Serialize(data);

            var response = await client.PostAsync($"{BaseUrl}/users", new StringContent(json, Encoding.UTF8, "application/json"));

            string result = await response.Content.ReadAsStringAsync();

            Console.WriteLine(result);
        }

        private async Task<bool> UsernameExists(string username)
        {
            username = username.Trim().ToLower();

            var response = await client.GetAsync(
                $"{BaseUrl}/Users/{username}" 
            );

            return response.IsSuccessStatusCode;
        }
    }
}
