using Dziekanowka.Mechanizm;
using Microsoft.Extensions.Logging;
using Plugin.Maui.Audio;
namespace Dziekanowka
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
                });
            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddScoped<LadowanieGracza>();
            builder.Services.AddSingleton(AudioManager.Current);
            builder.Services.AddSingleton<Dzwieki>();
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}