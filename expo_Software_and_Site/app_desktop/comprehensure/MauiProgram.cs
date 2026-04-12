using CommunityToolkit.Maui;
using comprehensure.DASHBOARD;
using comprehensure.DASHBOARD.StoryPage;
using comprehensure.DataBaseControl.Models;
using comprehensure.Models;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
// code to android emu is 1111

namespace comprehensure
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder.Configuration.AddUserSecrets<App>();
            builder.Configuration.AddJsonFile("Resources/Raw/Firebase_api/API_KEY/secrets.json", optional: true);
            var apiKey = builder.Configuration["FirebaseApiKey"];

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .UseMauiCommunityToolkit();
#if DEBUG
            builder.Logging.AddDebug();
#endif
            if (DeviceInfo.Current.Platform == DevicePlatform.Android)
            {
                builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig() { ApiKey = "USEBUILTIN", AuthDomain = "comprehensuredb.web.app", Providers = new FirebaseAuthProvider[] { new EmailProvider() }, }) { });
            }
            else
            {
                builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig() { ApiKey = apiKey, AuthDomain = "comprehensuredb.web.app", Providers = new FirebaseAuthProvider[] { new EmailProvider() }, }) { });
            }
            // sorry sir in a cybersecurity standpoint this is bad asf 


            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<SignUpViewModel>();
            builder.Services.AddTransient<MainDashboardViewModel>();
            builder.Services.AddTransient<UsernameReqViewModel>();
            builder.Services.AddTransient<ProfileDashboard>();
            builder.Services.AddTransient<ProfileDashboardViewModel>();
            builder.Services.AddTransient<UsernameReq>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<SignUpPage>();
            builder.Services.AddTransient<MainDashboard>();
            builder.Services.AddTransient<MainPageViewModel>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<ModulesDashboardViewModel>();
            builder.Services.AddTransient<ModulesDashboard>();

            builder.Services.AddTransient<StoryPage1>();
            builder.Services.AddTransient<StoryPage2>();
            builder.Services.AddTransient<StoryPage3>();
            builder.Services.AddTransient<StoryPage4>();
            builder.Services.AddTransient<StoryPage5>();
            builder.Services.AddTransient<StoryPage6>();
            builder.Services.AddTransient<StoryPage7>();
            builder.Services.AddTransient<StoryPage8>();

            
            builder.Services.AddTransient<StoryPage1ViewModel>();
            builder.Services.AddTransient<StoryPage2ViewModel>();
            builder.Services.AddTransient<StoryPage3ViewModel>();
            builder.Services.AddTransient<StoryPage4ViewModel>();
            builder.Services.AddTransient<StoryPage5ViewModel>();
            builder.Services.AddTransient<StoryPage6ViewModel>();
            builder.Services.AddTransient<StoryPage7ViewModel>();
            builder.Services.AddTransient<StoryPage8ViewModel>();

            return builder.Build();
        }
    }
}
