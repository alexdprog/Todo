using CommunityToolkit.Maui;

using TodoApp.DataAccess;
using TodoApp.ViewModels;
using TodoApp.Views;

namespace TodoApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder()
#if DEBUG
								.UseMauiCommunityToolkit()
#else
								.UseMauiCommunityToolkit(options =>
								{
									options.SetShouldSuppressExceptionsInConverters(false);
									options.SetShouldSuppressExceptionsInBehaviors(false);
									options.SetShouldSuppressExceptionsInAnimations(false);
								})
#endif
		
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<TodoAppBaseContext>();

        RegisterViewsAndViewModels(builder.Services);

		return builder.Build();
	}

	static void RegisterViewsAndViewModels(in IServiceCollection services)
	{
		services.AddSingleton<MainPageViewModel>();
		services.AddSingleton<MainPage>();
		services.AddSingleton<AboutPage>();
		services.AddSingleton<AboutViewModel>();
        services.AddSingleton<TodoViewModel>();
		services.AddSingleton<TodoPage>();
				services.AddSingleton<TodoArhiveViewModel>();
		services.AddSingleton<TodoArhivePage>();
		        services.AddSingleton<TodoAddViewModel>();
		services.AddSingleton<TodoAddPage>();
			}
}