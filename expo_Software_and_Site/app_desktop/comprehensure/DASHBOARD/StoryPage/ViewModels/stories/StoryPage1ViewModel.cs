using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace comprehensure.DASHBOARD.StoryPage;

/// <summary>
/// ViewModel for StoryPage1 - The Forgotten Library
/// </summary>
public class StoryPage1ViewModel : INotifyPropertyChanged
{
    private int _currentPosition;
    private int _totalSlides;

    public StoryPage1ViewModel()
    {
        // Initialize story content
        StoryContent = new ObservableCollection<string>
        {
            "In a quiet town surrounded by green hills, there stood an old library that most people had forgotten...",
            "Inside, tall shelves were filled with dusty books. Some looked so old that their pages had turned yellow...",
            "People in town often said that the library held forgotten knowledge, stories and letters...",
            "One afternoon, a curious student named Leo decided to visit. Leo loved history...",
            "While exploring the back corner of the library, Leo noticed something unusual. One bookshelf looked slightly out of place...",
            "Leo carefully opened one journal. The writing inside was strange. It was written in shorthand...",
            "For days after school, Leo returned to the library. He sat at the small desk and worked patiently...",
            "One journal described an expedition where a group of travelers had disappeared...",
            "History was not only about big events. It was about small details. It was about writing things down carefully...",
            "After a month of hard work, Leo had translated several journals. He organized the information into clear notes...",
            "The club decided to preserve the writings. Leo realized the most valuable knowledge is not always the most popular..."
        };

        TotalSlides = StoryContent.Count;
        CurrentPosition = 0;

        // Initialize commands
        GoToQuizCommand = new Command(async () => await OnGoToQuiz());
        GoBackCommand = new Command(async () => await OnGoBack());
    }

    #region Properties

    /// <summary>
    /// Collection of story text segments for the carousel
    /// </summary>
    public ObservableCollection<string> StoryContent { get; set; }

    /// <summary>
    /// Title of the story module
    /// </summary>
    public string StoryTitle => "The Forgotten Library";

    /// <summary>
    /// Subtitle text
    /// </summary>
    public string StorySubtitle => "Swipe to read the story";

    /// <summary>
    /// Current carousel position
    /// </summary>
    public int CurrentPosition
    {
        get => _currentPosition;
        set
        {
            if (_currentPosition != value)
            {
                _currentPosition = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CurrentSlideDisplay));
            }
        }
    }

    /// <summary>
    /// Total number of slides
    /// </summary>
    public int TotalSlides
    {
        get => _totalSlides;
        set
        {
            if (_totalSlides != value)
            {
                _totalSlides = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CurrentSlideDisplay));
            }
        }
    }

    /// <summary>
    /// Display text for current slide position (e.g., "Slide 1 of 11")
    /// </summary>
    public string CurrentSlideDisplay => $"Slide {CurrentPosition + 1} of {TotalSlides}";

    #endregion

    #region Commands

    /// <summary>
    /// Command to navigate to quiz page
    /// </summary>
    public ICommand GoToQuizCommand { get; }

    /// <summary>
    /// Command to navigate back to previous page
    /// </summary>
    public ICommand GoBackCommand { get; }

    #endregion

    #region Methods

    /// <summary>
    /// Navigate to QuizPage1
    /// </summary>
    private async Task OnGoToQuiz()
    {
        // Navigation logic will be handled in code-behind or through navigation service
        // This can be customized based on your navigation pattern
        await Task.CompletedTask;
    }

    /// <summary>
    /// Navigate back to previous page
    /// </summary>
    private async Task OnGoBack()
    {
        // Navigation logic will be handled in code-behind or through navigation service
        await Task.CompletedTask;
    }

    #endregion

    #region INotifyPropertyChanged

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion
}
