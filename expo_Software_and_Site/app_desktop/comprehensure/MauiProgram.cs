using comprehensure.DataBaseControl.Models;
using comprehensure.DASHBOARD;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;

namespace comprehensure
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>().ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            }).UseMauiCommunityToolkit();
#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig() { ApiKey = "", AuthDomain = "comprehensuredb.web.app", Providers = new FirebaseAuthProvider[] { new EmailProvider() }, }) { });
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<SignUpViewModel>();
            builder.Services.AddTransient<MainDashboardViewModel>();
            builder.Services.AddTransient<UsernameReqViewModel>();
            builder.Services.AddTransient<UsernameReq>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<SignUpPage>();
            builder.Services.AddTransient<MainDashboard>();
            
            return builder.Build();
        }
    }
}