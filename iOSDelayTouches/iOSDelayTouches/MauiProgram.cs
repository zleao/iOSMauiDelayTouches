namespace iOSDelayTouches;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
            .ConfigureMauiHandlers((handlers) =>
            {
#if IOS
                handlers.AddHandler(typeof(TableView), typeof(Platforms.iOS.Renderers.MyTableViewRenderer));
#elif MACCATALYST
                handlers.AddHandler(typeof(TableView), typeof(Platforms.MacCatalyst.Renderers.MyTableViewRenderer));
#endif
            });

        builder.Services.AddSingleton<ScrollViewlPage>();

		builder.Services.AddSingleton<TableViewPage>();

		return builder.Build();
	}
}
