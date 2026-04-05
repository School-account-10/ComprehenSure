/*using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace comprehensure.DataBaseControl.Services
{
 public class FirestoreService
 {
     private readonly HttpClient client = new HttpClient();
     private readonly string projectId = "comprehensuredb";

     private string BaseUrl =>
         $"https://firestore.googleapis.com/v1/projects/{projectId}/databases/(default)/documents";


     public async Task SaveUsername(string userId, string username)
     {
         username = username.Trim().ToLower();


         var userData = new
         {
             fields = new
             {
                 username = new { stringValue = username }
             }
         };

         var userContent = new StringContent(
             JsonSerializer.Serialize(userData),
             Encoding.UTF8,
             "application/json"
         );

         await client.PatchAsync(
             $"{BaseUrl}/users/{userId}?updateMask.fieldPaths=username",
             userContent
         );


         var usernameData = new
         {
             fields = new
             {
                 uid = new { stringValue = userId }
             }
         };

         var usernameContent = new StringContent(
             JsonSerializer.Serialize(usernameData),
             Encoding.UTF8,
             "application/json"
         );

         await client.PostAsync(
             $"{BaseUrl}/usernames?documentId={username}",
             usernameContent
         );
     }


     public async Task<bool> UsernameExists(string username)
     {
         username = username.Trim().ToLower();

         var response = await client.GetAsync(
             $"{BaseUrl}/usernames/{username}"
         );

         return response.IsSuccessStatusCode;
     }


     public async Task<string?> GetUsername(string userId)
     {
         var response = await client.GetAsync(
             $"{BaseUrl}/users/{userId}"
         );

         if (!response.IsSuccessStatusCode)
             return null;

         var json = await response.Content.ReadAsStringAsync();

         using var doc = JsonDocument.Parse(json);

         if (doc.RootElement.TryGetProperty("fields", out var fields) &&
             fields.TryGetProperty("username", out var username))
         {
             return username.GetProperty("stringValue").GetString();
         }

         return null;
     }
 }
}
*/