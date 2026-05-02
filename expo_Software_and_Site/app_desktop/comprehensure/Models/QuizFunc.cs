using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;

namespace comprehensure.Models
{
    public class QuizFunc
    {
        // ── Firestore REST config ─────────────────────────────────────────
        private const string ProjectId  = "comprehensuredb-f9f7c";
        private const string Collection = "StoryPage";
        private static string BaseUrl =>
            $"https://firestore.googleapis.com/v1/projects/{ProjectId}/databases/(default)/documents";

        private static readonly HttpClient _client = new HttpClient();

        // storypageprogN  — written when the reader reaches the last story page (80%)
        private static readonly Dictionary<int, string> ProgressFields = new()
        {
            { 1, "storypageprog1" }, { 2, "storypageprog2" }, { 3, "storypageprog3" },
            { 4, "storypageprog4" }, { 5, "storypageprog5" }, { 6, "storypageprog6" },
            { 7, "storypageprog7" }, { 8, "storypageprog8" },
        };

        // calculatedprogN — written when the quiz finishes: storyProgress(80) + quizScore*2
        private static readonly Dictionary<int, string> CalculatedProgFields = new()
        {
            { 1, "calculatedprog1" }, { 2, "calculatedprog2" }, { 3, "calculatedprog3" },
            { 4, "calculatedprog4" }, { 5, "calculatedprog5" }, { 6, "calculatedprog6" },
            { 7, "calculatedprog7" }, { 8, "calculatedprog8" },
        };

        // ── Called when reader reaches the last story page ─────────────────
        /// <summary>Saves storypageprogN = 80 and UID to Firestore.</summary>
        public static async Task SaveProgressAsync(int storyNumber, int progress)
        {
            if (!ProgressFields.TryGetValue(storyNumber, out string fieldName)) return;

            string uid = Preferences.Default.Get("SavedUserUid", "");
            if (string.IsNullOrWhiteSpace(uid)) return;

            string url = $"{BaseUrl}/{Collection}/{uid}" +
                         $"?updateMask.fieldPaths={fieldName}" +
                         $"&updateMask.fieldPaths=UID";

            var data = new
            {
                fields = new Dictionary<string, object>
                {
                    { fieldName, new { integerValue = progress.ToString() } },
                    { "UID",     new { stringValue  = uid } }
                }
            };

            await PatchAsync(url, data, $"SaveProgressAsync story {storyNumber}");
        }

        // ── Called when the quiz finishes ──────────────────────────────────
        /// <summary>
        /// Saves calculatedprogN = storyProgress + (quizScore * 2) to Firestore.
        /// storyProgress is always 80 when reached from a completed story.
        /// </summary>
        public static async Task SaveQuizProgressAsync(int storyNumber, int quizScore, int storyProgress = 80)
        {
            if (!CalculatedProgFields.TryGetValue(storyNumber, out string fieldName)) return;

            string uid = Preferences.Default.Get("SavedUserUid", "");
            if (string.IsNullOrWhiteSpace(uid)) return;

            int calculatedProg = storyProgress + (quizScore * 2);

            string url = $"{BaseUrl}/{Collection}/{uid}" +
                         $"?updateMask.fieldPaths={fieldName}" +
                         $"&updateMask.fieldPaths=UID";

            var data = new
            {
                fields = new Dictionary<string, object>
                {
                    { fieldName, new { integerValue = calculatedProg.ToString() } },
                    { "UID",     new { stringValue  = uid } }
                }
            };

            await PatchAsync(url, data, $"SaveQuizProgressAsync story {storyNumber} calc={calculatedProg}");
        }

        // ── Shared PATCH helper ────────────────────────────────────────────
        private static async Task PatchAsync(string url, object data, string tag)
        {
            try
            {
                var options = new JsonSerializerOptions { PropertyNamingPolicy = null };
                var json    = JsonSerializer.Serialize(data, options);

                var response = await _client.PatchAsync(
                    url,
                    new StringContent(json, Encoding.UTF8, "application/json")
                );

                if (!response.IsSuccessStatusCode)
                {
                    string error = await response.Content.ReadAsStringAsync();
                    System.Diagnostics.Debug.WriteLine($"[QuizFunc:{tag}] Failed: {error}");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"[QuizFunc:{tag}] OK");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[QuizFunc:{tag}] Exception: {ex.Message}");
            }
        }
    }
}
