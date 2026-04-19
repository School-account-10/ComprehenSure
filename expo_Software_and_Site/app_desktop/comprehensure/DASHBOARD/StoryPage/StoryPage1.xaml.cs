using System;
using Microsoft.Maui.Controls;

namespace comprehensure.DASHBOARD.StoryPage
{
    public partial class StoryPage1 : ContentPage
    {
        private int _currentPage = 0;
        private readonly string[] _storyPages = new string[]
        {
            "In a quiet town surrounded by green hills, there stood an old library that most people had forgotten. It was built many years ago, long before modern buildings and computers became common. The paint on its walls was fading, and the wooden doors made a soft creaking sound when opened.",
            "Few visitors entered anymore. Most people preferred new bookstores or searched for information online. Because of this, the library felt lonely. Inside, tall shelves were filled with dusty books. Some books looked so old that their pages had turned yellow. The smell of old paper and wood filled the air.",
            "Sunlight entered through narrow windows, lighting up floating dust in the room. It felt like stepping into the past. People in town often said that the library held forgotten knowledge, stories and letters that no one had read for years.",
            "One afternoon, a curious student named Leo decided to visit. Leo loved history. While other students saw history as boring lists of dates, he saw it as stories of real people who made brave choices. As he stepped inside, the wooden floor creaked.",
            "While exploring the back corner of the library, Leo noticed something unusual. One bookshelf looked slightly out of place. Curious, he gently pushed it. To his surprise, it moved just enough to reveal a narrow passage behind it. His heart beat faster.",
            "The hidden space was small and dim, with a single desk and several old journals stacked on top. Leo carefully opened one journal. The writing inside was strange, written in shorthand—a quick writing style used long ago to save time and space.",
            "For days after school, Leo returned to the library. He sat at the small desk and worked patiently. He compared letters, searched for patterns, and slowly decoded the words. It was not easy, but little by little, the stories began to make sense.",
            "The journals described long journeys across unknown lands. There were detailed drawings of rivers, mountains, and paths that were not on modern maps. Some pages told of dangerous storms and difficult choices. Others spoke about teamwork and courage.",
            "One journal described an expedition where a group of travelers had disappeared. Leo realized that these were not just adventure stories. They were real accounts of human decisions. History was about the small details and choices that change everything.",
            "After a month of hard work, Leo translated several journals and shared his findings with the local history club. Everyone became interested. The club decided to preserve the writings and inform the town. Soon, more people began visiting the library again.",
            "Standing inside the old library, Leo realized something meaningful. The most valuable knowledge is not always the most popular. Sometimes, important truths are hidden in quiet places, waiting for someone curious enough to search for them."
        };

        public StoryPage1(DASHBOARD.StoryPage.StoryPage1ViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
            UpdateUI();
        }
       

        private void UpdateUI()
        {
            // Set Text
            StoryLabel.Text = _storyPages[_currentPage];

            // Set Indicator
            PageIndicator.Text = $"Page {_currentPage + 1} of {_storyPages.Length}";

            // Scroll to top
            StoryScroll.ScrollToAsync(0, 0, false);
        }

        private void OnPrevClicked(object sender, EventArgs e)
        {
            if (_currentPage > 0)
            {
                _currentPage--;
                UpdateUI();
            }
        }

        private void OnNextClicked(object sender, EventArgs e)
        {
            if (_currentPage < _storyPages.Length - 1)
            {
                _currentPage++;
                UpdateUI();
            }
        }

        private async void OnGoToQuizClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new QuizPage1(new QuizPage1ViewModel()));
        }
    }
}