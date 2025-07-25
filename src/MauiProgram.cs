﻿using Microsoft.Extensions.Logging;

namespace RemoveMauiNavBarTitle;

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
			.ConfigureMauiHandlers(handlers =>
			{
#if ANDROID
				handlers.AddHandler(typeof(Shell), typeof(Platforms.Android.Renderers.AndroidShellRenderer));
#endif

#if IOS
				handlers.AddHandler(typeof(Shell), typeof(Platforms.iOS.Renderers.iOSShellRenderer));
#endif
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
