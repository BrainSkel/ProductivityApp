using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using ProductivityApp.Data;
using SQLite;

namespace ProductivityApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();

        builder.Services.AddSingleton<ChartDatabase>();
        builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("MotivaSansBold.woff.ttf", "MotivaSansBold");
				fonts.AddFont("MotivaSansRegular.woff.ttf", "MotivaSansRegular");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
