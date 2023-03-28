using Microsoft.Extensions.Logging;
using ZXing.Net.Maui;
using Microsoft.Maui.Platform;
using Syncfusion.Maui.Core.Hosting;

namespace GeolocationTest;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureSyncfusionCore()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
			.UseMauiMaps()
			.UseBarcodeReader();
        builder.ConfigureMauiHandlers(handlers =>
		{
			handlers.AddHandler(typeof(ZXing.Net.Maui.Controls.CameraBarcodeReaderView), typeof(CameraBarcodeReaderViewHandler));
			handlers.AddHandler(typeof(ZXing.Net.Maui.Controls.CameraView), typeof(CameraViewHandler));
			handlers.AddHandler(typeof(ZXing.Net.Maui.Controls.BarcodeGeneratorView), typeof(BarcodeGeneratorViewHandler));
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
