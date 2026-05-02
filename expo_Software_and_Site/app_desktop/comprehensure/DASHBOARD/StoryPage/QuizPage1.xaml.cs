namespace comprehensure.DASHBOARD.StoryPage;

public partial class QuizPage1 : ContentPage
{
    private readonly QuizPage1ViewModel _viewModel;
    private string _selectedAnswer = "";

    // Tracks the fill width for the progress bar
    private double _trackWidth = 0;

    public QuizPage1(QuizPage1ViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = viewModel;

        // Set nav bar here — before the page ever appears
        Shell.SetFlyoutBehavior(this, FlyoutBehavior.Disabled);
        Shell.SetNavBarIsVisible(this, false);
        Shell.SetNavBarHasShadow(this, false);
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior

        {
            IsVisible = false,
            IsEnabled = false
        });
    }
   
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.LoadQuestions();
        UpdateProgress();

    }


    //  Called once the track Border has been measured 
    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);

        // Content padding is 40+40=80; MaxWidth=720 — derive usable track width
        double contentWidth = Math.Min(width, 720) - 80;
        if (contentWidth > 0 && Math.Abs(contentWidth - _trackWidth) > 1)
        {
            _trackWidth = contentWidth;
            UpdateProgress();
        }
    }

    //  Option tapped 
    private void OnOptionClicked(object sender, TappedEventArgs e)
    {
        _selectedAnswer = e.Parameter?.ToString().ToUpper() ?? "";
        ResetOptionStyles();

        // Highlight the selected option row and its circle
        switch (_selectedAnswer)
        {
            case "A":
                ApplySelectedStyle(BorderA, CircleA);
                break;
            case "B":
                ApplySelectedStyle(BorderB, CircleB);
                break;
            case "C":
                ApplySelectedStyle(BorderC, CircleC);
                break;
            case "D":
                ApplySelectedStyle(BorderD, CircleD);
                break;
        }

        NextButton.IsEnabled = true;
    }

    private void ApplySelectedStyle(Border row, Border circle)
    {
        row.BackgroundColor = Color.FromArgb("#EBF4FF");
        row.Stroke = Color.FromArgb("#2E6BA8");
        circle.BackgroundColor = Color.FromArgb("#2E6BA8");
        circle.Stroke = Color.FromArgb("#2E6BA8");

        // Turn the letter label white for contrast
        if (circle.Content is Label lbl)
            lbl.TextColor = Colors.White;
    }

    private void ResetOptionStyles()
    {
        foreach (var (row, circle) in new[]
        {
            (BorderA, CircleA),
            (BorderB, CircleB),
            (BorderC, CircleC),
            (BorderD, CircleD)
        })
        {
            row.BackgroundColor = Colors.White;
            row.Stroke = Color.FromArgb("#CBDCEB");
            circle.BackgroundColor = Colors.Transparent;
            circle.Stroke = Color.FromArgb("#CBDCEB");

            if (circle.Content is Label lbl)
                lbl.TextColor = Color.FromArgb("#2E6BA8");
        }
    }

    //  Next clicked 
    private async void OnNextClicked(object sender, EventArgs e)
    {
        _viewModel.CheckAnswer(_selectedAnswer);

        _selectedAnswer = "";
        NextButton.IsEnabled = false;
        ResetOptionStyles();

        bool hasNext = _viewModel.NextQuestion();

        if (!hasNext)
        {
            await _viewModel.SaveQuizResults();
            ShowCompleteBanner();
        }
        else
        {
            UpdateProgress();
        }
    }

    //  Finish button on the complete banner 
    private async void OnFinishClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    //  Back button 
    private void OnBackClicked(object sender, EventArgs e)
    {
        PopupOverlay.IsVisible = true;
    }

    private async void OnPopupConfirm(object sender, EventArgs e)
    {
        PopupOverlay.IsVisible = false;
        await Navigation.PopAsync();
    }

    private void OnPopupCancel(object sender, EventArgs e)
    {
        PopupOverlay.IsVisible = false;
    }

    //  Helpers 
    private void UpdateProgress()
    {
        if (_viewModel == null || _viewModel.TotalQuestions == 0) return;

        // QuestionNumber is 1-based (e.g. "Question 1 of 5")
        int current = _viewModel.CurrentQuestionIndex + 1; // expose this in VM, see note below
        int total = _viewModel.TotalQuestions;

        double ratio = Math.Clamp((double)current / total, 0, 1);
        int percent = (int)Math.Round(ratio * 100);

        ProgressPercent.Text = $"{percent}%";
        ProgressFill.WidthRequest = _trackWidth > 0 ? _trackWidth * ratio : 0;
    }

    private void ShowCompleteBanner()
    {
        FinalScoreLabel.Text = $"You scored {_viewModel.Score} out of {_viewModel.TotalQuestions}";

        // Hide the options and next button area, show the banner
        OptionsContainer.IsVisible = false;
        CompleteBanner.IsVisible = true;
        NextButton.IsEnabled = false;

        // Fill progress to 100%
        ProgressPercent.Text = "100%";
        ProgressFill.WidthRequest = _trackWidth;
    }


}
