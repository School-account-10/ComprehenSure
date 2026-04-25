using comprehensure.DASHBOARD;
using comprehensure.DASHBOARD.MiniGames;
using comprehensure.DASHBOARD.StoryPage;

namespace comprehensure
{
    public partial class AppShell : Shell
    {
        private async void OnLogOutClicked(object sender, EventArgs e)
        {
            // Close the flyout first
            Shell.Current.FlyoutIsPresented = false;

            // Show custom popup and wait for result
            bool confirm = await ShowLogoutPopup();
            if (!confirm) return;

            await Shell.Current.GoToAsync("MainPage");
        }

        private Task<bool> ShowLogoutPopup()
        {
            var tcs = new TaskCompletionSource<bool>();

            // ── Dimmed overlay ──────────────────────────────────────────
            var overlay = new Grid
            {
                BackgroundColor = Color.FromArgb("#80000000"),
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill
            };

            // ── Top gradient accent band ────────────────────────────────
            var gradientBand = new Border
            {
                HeightRequest = 6,
                Stroke = Colors.Transparent,
                StrokeThickness = 0,
                Background = new LinearGradientBrush(
                    new GradientStopCollection
                    {
                        new GradientStop(Color.FromArgb("#0F2D4A"), 0f),
                        new GradientStop(Color.FromArgb("#2E6BA8"), 1f)
                    },
                    new Point(0, 0),
                    new Point(1, 0)),
                StrokeShape = new Microsoft.Maui.Controls.Shapes.RoundRectangle
                {
                    CornerRadius = new CornerRadius(36, 36, 0, 0)
                }
            };


            // ── Title ───────────────────────────────────────────────────
            var titleLabel = new Label
            {
                Text = "Log Out?",
                FontSize = 22,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.FromArgb("#0F2D4A"),
                HorizontalOptions = LayoutOptions.Center
            };

            // ── Body message ────────────────────────────────────────────
            var bodyLabel = new Label
            {
                Text = "Are you sure you want to log out of your account?",
                FontSize = 14,
                TextColor = Color.FromArgb("#6B8CAE"),
                HorizontalTextAlignment = TextAlignment.Center,
                LineHeight = 1.6,
                LineBreakMode = LineBreakMode.WordWrap
            };

            // ── Divider ─────────────────────────────────────────────────
            var divider = new BoxView
            {
                HeightRequest = 1,
                BackgroundColor = Color.FromArgb("#EBF4FF"),
                Margin = new Thickness(0, 4)
            };

            // ── "Yes, log out" button ───────────────────────────────────
            var yesButton = new Button
            {
                Text = "Yes, log out",
                BackgroundColor = Colors.Transparent,
                TextColor = Colors.White,
                BorderWidth = 0,
                FontAttributes = FontAttributes.Bold,
                FontSize = 14,
                HeightRequest = 52
            };

            var yesBorder = new Border
            {
                BackgroundColor = Color.FromArgb("#0F2D4A"),
                Stroke = Colors.Transparent,
                StrokeThickness = 0,
                StrokeShape = new Microsoft.Maui.Controls.Shapes.RoundRectangle
                {
                    CornerRadius = new CornerRadius(26)
                },
                Shadow = new Shadow
                {
                    Brush = new SolidColorBrush(Color.FromArgb("#0F2D4A")),
                    Offset = new Point(0, 6),
                    Radius = 16,
                    Opacity = 0.22f
                },
                Content = yesButton
            };

            // ── "Cancel" button ─────────────────────────────────────────
            var cancelButton = new Button
            {
                Text = "Cancel",
                BackgroundColor = Colors.Transparent,
                TextColor = Color.FromArgb("#0F2D4A"),
                BorderWidth = 0,
                FontAttributes = FontAttributes.Bold,
                FontSize = 14,
                HeightRequest = 52
            };

            var cancelBorder = new Border
            {
                BackgroundColor = Colors.Transparent,
                Stroke = Color.FromArgb("#CBDCEB"),
                StrokeThickness = 1.5,
                StrokeShape = new Microsoft.Maui.Controls.Shapes.RoundRectangle
                {
                    CornerRadius = new CornerRadius(26)
                },
                Content = cancelButton
            };

            // ── Button stack ────────────────────────────────────────────
            var buttonStack = new VerticalStackLayout
            {
                Spacing = 12,
                Children = { yesBorder, cancelBorder }
            };

            // ── Inner content ────────────────────────────────────────────
            var innerContent = new VerticalStackLayout
            {
                Spacing = 20,
                Padding = new Thickness(36, 28, 36, 32),
                Children = { titleLabel, bodyLabel, divider, buttonStack }
            };

            // ── Full card stack (band + content) ────────────────────────
            var cardStack = new VerticalStackLayout
            {
                Spacing = 0,
                Children = { gradientBand, innerContent }
            };

            // ── Popup card ───────────────────────────────────────────────
            var card = new Border
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 400,
                BackgroundColor = Colors.White,
                Stroke = Color.FromArgb("#CBDCEB"),
                StrokeThickness = 1,
                StrokeShape = new Microsoft.Maui.Controls.Shapes.RoundRectangle
                {
                    CornerRadius = new CornerRadius(36)
                },
                Shadow = new Shadow
                {
                    Brush = new SolidColorBrush(Color.FromArgb("#0F2D4A")),
                    Offset = new Point(0, 16),
                    Radius = 48,
                    Opacity = 0.18f
                },
                Content = cardStack
            };

            overlay.Children.Add(card);

            // ── Get the currently visible ContentPage from Shell ────────
            ContentPage? currentPage = null;

            var navStack = Shell.Current?.Navigation?.NavigationStack;
            if (navStack != null)
            {
                for (int i = navStack.Count - 1; i >= 0; i--)
                {
                    if (navStack[i] is ContentPage cp) { currentPage = cp; break; }
                }
            }

            // Fallback: check the current item's content page
            if (currentPage == null)
            {
                var shellContent = Shell.Current?.CurrentItem?.CurrentItem?.CurrentItem;
                if (shellContent?.Content is ContentPage scp)
                    currentPage = scp;
            }

            if (currentPage == null) { tcs.SetResult(false); return tcs.Task; }

            // ── Inject overlay into the page's root Grid ────────────────
            Grid rootGrid;
            if (currentPage.Content is Grid existingGrid)
            {
                rootGrid = existingGrid;
            }
            else
            {
                rootGrid = new Grid();
                if (currentPage.Content != null)
                    rootGrid.Children.Add(currentPage.Content);
                currentPage.Content = rootGrid;
            }

            rootGrid.Children.Add(overlay);

            // ── Cleanup helper ───────────────────────────────────────────
            void Cleanup() => rootGrid.Children.Remove(overlay);

            yesButton.Clicked += (s, args) => { Cleanup(); tcs.SetResult(true); };
            cancelButton.Clicked += (s, args) => { Cleanup(); tcs.SetResult(false); };

            return tcs.Task;
        }

        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(SignUpPage), typeof(SignUpPage));
            Routing.RegisterRoute(nameof(MainDashboard), typeof(MainDashboard));
            Routing.RegisterRoute(nameof(ModulesDashboard), typeof(ModulesDashboard));
            Routing.RegisterRoute(nameof(StoryPage1), typeof(StoryPage1));
            Routing.RegisterRoute(nameof(StoryPage2), typeof(StoryPage2));
            Routing.RegisterRoute(nameof(StoryPage3), typeof(StoryPage3));
            Routing.RegisterRoute(nameof(StoryPage4), typeof(StoryPage4));
            Routing.RegisterRoute(nameof(StoryPage5), typeof(StoryPage5));
            Routing.RegisterRoute(nameof(StoryPage6), typeof(StoryPage6));
            Routing.RegisterRoute(nameof(StoryPage7), typeof(StoryPage7));
            Routing.RegisterRoute(nameof(StoryPage8), typeof(StoryPage8));
            Routing.RegisterRoute("SynonymGamePage", typeof(SynonymHuntPage));
            Routing.RegisterRoute("OneThemeGamePage", typeof(OneThemePage));

            // ── ADDED: Register QuizPage routes 1-8 ─────────────────────
            Routing.RegisterRoute(nameof(QuizPage1), typeof(QuizPage1)); // ADDED
            Routing.RegisterRoute(nameof(QuizPage2), typeof(QuizPage2)); // ADDED
            Routing.RegisterRoute(nameof(QuizPage3), typeof(QuizPage3)); // ADDED
            Routing.RegisterRoute(nameof(QuizPage4), typeof(QuizPage4)); // ADDED
            Routing.RegisterRoute(nameof(QuizPage5), typeof(QuizPage5)); // ADDED
            Routing.RegisterRoute(nameof(QuizPage6), typeof(QuizPage6)); // ADDED
            Routing.RegisterRoute(nameof(QuizPage7), typeof(QuizPage7)); // ADDED
            Routing.RegisterRoute(nameof(QuizPage8), typeof(QuizPage8)); // ADDED
        }
    }
}
