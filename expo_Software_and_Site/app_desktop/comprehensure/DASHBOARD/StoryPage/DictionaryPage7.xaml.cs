namespace comprehensure.DASHBOARD.StoryPage;

public partial class DictionaryPage7 : ContentPage
{
    private Button? _activeButton;
    private CancellationTokenSource? _cts;

    public DictionaryPage7()
    {
        Shell.SetFlyoutBehavior(this, FlyoutBehavior.Disabled);
        Shell.SetNavBarIsVisible(this, false);
        Shell.SetNavBarHasShadow(this, false);
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior
        {
            IsVisible = false,
            IsEnabled = false
        });
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void OnSpeakClicked(object sender, EventArgs e)
    {
        if (sender is not Button btn) return;

        var word = btn.CommandParameter?.ToString();
        if (string.IsNullOrEmpty(word)) return;

        // If the same button is tapped while speaking, cancel
        if (_activeButton == btn)
        {
            _cts?.Cancel();
            btn.Text = "🔊";
            _activeButton = null;
            return;
        }

        // Cancel any currently playing word
        _cts?.Cancel();
        if (_activeButton is not null)
            _activeButton.Text = "🔊";

        // Set up new cancellation token and active button
        _cts = new CancellationTokenSource();
        _activeButton = btn;
        btn.Text = "🔉";

        try
        {
            var settings = new SpeechOptions
            {
                Pitch  = 1.0f,
                Volume = 1.0f,
            };

            await TextToSpeech.Default.SpeakAsync(word, settings, _cts.Token);
        }
        catch (OperationCanceledException)
        {
            // User cancelled — no action needed
        }
        catch (Exception ex)
        {
            await DisplayAlert("Audio Error", $"Could not play audio: {ex.Message}", "OK");
        }
        finally
        {
            if (_activeButton == btn)
            {
                btn.Text = "🔊";
                _activeButton = null;
            }
        }
    }
}
