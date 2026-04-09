using CommunityToolkit.Maui;
using comprehensure.DASHBOARD;
using comprehensure.DataBaseControl.Models;
using comprehensure.Models;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

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

            builder.Services.AddSingleton(
                new FirebaseAuthClient(
                    new FirebaseAuthConfig()
                    {
                        ApiKey = apiKey,
                        AuthDomain = "comprehensuredb.web.app",
                        Providers = new FirebaseAuthProvider[] { new EmailProvider() },
                    }
                )
                { }
            );

            builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig() { ApiKey = "AIzaSyBZ5o4uLtYW2m6JxPFD35cbf9vPz5jsNVk\r\n   ", AuthDomain = "comprehensuredb.web.app", Providers = new FirebaseAuthProvider[] { new EmailProvider() }, }) { });

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

            return builder.Build();
        }
    }
}
