using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace comprehensure.DASHBOARD.StoryPage;

/// <summary>
/// ViewModel for StoryPage6
/// </summary>
public class StoryPage6ViewModel : INotifyPropertyChanged
{
    private string _storyText;

    public StoryPage6ViewModel()
    {
        // Initialize story content
        StoryText = "Insert your story text for Module 6 here. This area is scrollable to accommodate longer narratives.";
        ModuleTitle = "Module 06";

        // Initialize commands
        GoToQuizCommand = new Command(async () => await OnGoToQuiz());
        GoBackCommand = new Command(async () => await OnGoBack());
    }

    #region Properties

    /// <summary>
    /// Title of the module
    /// </summary>
    public string ModuleTitle { get; set; }

    /// <summary>
    /// Main story text content
    /// </summary>
    public string StoryText
    {
        get => _storyText;
        set
        {
            if (_storyText != value)
            {
                _storyText = value;
                OnPropertyChanged();
            }
        }
    }

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
    /// Navigate to QuizPage6
    /// </summary>
    private async Task OnGoToQuiz()
    {
        // Navigation logic will be handled in code-behind or through navigation service
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
