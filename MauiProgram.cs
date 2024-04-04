using Masters_Summer_Project_CsharpPart2_Quiz.Repositories;
using Masters_Summer_Project_CsharpPart2_Quiz.ViewModels;
using Masters_Summer_Project_CsharpPart2_Quiz.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Masters_Summer_Project_CsharpPart2_Quiz;

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

		// For dependency injection
		builder.Services.AddScoped<UserRepository>();

		// View model dependency injection
		builder.Services.AddTransient<RegisterViewModel>();

		// DBContext dependency injection
		builder.Services.AddScoped<QuizDBContext>(provider =>
{
	var optionsBuilder = new DbContextOptionsBuilder<QuizDBContext>();
	// No specific configuration here; it's done in OnConfiguring of the DbContext
	return new QuizDBContext(optionsBuilder.Options);
});

		// #if DEBUG
		// 		builder.Logging.AddDebug();
		// #endif

#if ERROR
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
