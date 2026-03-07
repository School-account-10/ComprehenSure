using Firebase.Auth;
using Firebase.Auth.Providers;
using Microsoft.Extensions.Logging;


namespace comprehensure
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig()
            {
                ApiKey = "AIzaSyBZ5o4uLtYW2m6JxPFD35cbf9vPz5jsNVk",
                AuthDomain = "comprehensuredb.web.app",
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }


            })
            {

            });



            return builder.Build();
        }
    }
}
