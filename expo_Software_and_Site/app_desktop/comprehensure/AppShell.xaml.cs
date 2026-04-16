using comprehensure.DASHBOARD;
using comprehensure.DASHBOARD.MiniGames;
using comprehensure.DASHBOARD.StoryPage;

namespace comprehensure
{
    public partial class AppShell : Shell
    {
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

        }
    }
}
