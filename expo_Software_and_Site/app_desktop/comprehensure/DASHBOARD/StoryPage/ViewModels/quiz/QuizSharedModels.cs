using System.Text.Json.Serialization;

namespace comprehensure.DASHBOARD.StoryPage
{
    public class QuizItem
    {
        [JsonPropertyName("question")]
        public string Question { get; set; }

        [JsonPropertyName("choices")]
        public QuizChoices Choices { get; set; }

        [JsonPropertyName("answer")]
        public string Answer { get; set; }
    }

    public class QuizChoices
    {
        [JsonPropertyName("A")]
        public string A { get; set; }

        [JsonPropertyName("B")]
        public string B { get; set; }

        [JsonPropertyName("C")]
        public string C { get; set; }

        [JsonPropertyName("D")]
        public string D { get; set; }

        public string GetByKey(string key) => key switch
        {
            "A" => A,
            "B" => B,
            "C" => C,
            "D" => D,
            _ => ""
        };
    }
}
