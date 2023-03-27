using Microsoft.Extensions.Logging;
using Microsoft.Maui.Platform;

namespace GeolocationTest;

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
			})
            .UseMauiMaps();
		builder.ConfigureMauiHandlers(handlers =>
		{
#if ANDROID || IOS || MACCATALYST
			handlers.AddHandler<Microsoft.Maui.Controls.Maps.Map, CustomMapHandler>();
#endif
		});

#if DEBUG
            builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
