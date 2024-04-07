using Masters_Summer_Project_CsharpPart2_Quiz.Repositories;
using Masters_Summer_Project_CsharpPart2_Quiz.ViewModels;
using Masters_Summer_Project_CsharpPart2_Quiz.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Masters_Summer_Project_CsharpPart2_Quiz.Services;
using Masters_Summer_Project_CsharpPart2_Quiz.Views;

namespace Masters_Summer_Project_CsharpPart2_Quiz;

public static class MauiProgram
{
	public static Exception StartupException = null;
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

		try
		{
			var assembly = Assembly.GetExecutingAssembly();
			using var stream = assembly.GetManifestResourceStream("Masters_Summer_Project_CsharpPart2_Quiz.Properties.appsettings.json");
			if (stream == null)
			{
				throw new InvalidOperationException("Could not find embedded resource 'appsettings.json'. Ensure it's set as an Embedded Resource.");
			}
			var configuration = new ConfigurationBuilder()
				.AddJsonStream(stream)
				.Build();
			builder.Configuration.AddConfiguration(configuration);

			builder.Services.AddDbContext<QuizDBContext>((serviceProvider, optionsBuilder) =>
			{
				var config = serviceProvider.GetRequiredService<IConfiguration>();
				var connectionString = $"Host={config["POSTGRE_HOST"]};Username={config["POSTGRE_USERNAME"]};Password={config["POSTGRE_PASSWORD"]};Database=quiz";
				optionsBuilder.UseNpgsql(connectionString)
				.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
			});
		}
		catch (Exception e)
		{
			StartupException = e;
		}

		// For dependency injection
		builder.Services.AddScoped<UserRepository>();


		builder.Services.AddSingleton<INavigationService, NavigationService>();

		// View model dependency injection
		builder.Services.AddTransient<RegisterViewModel>();
		builder.Services.AddTransient<LoginViewModel>();
		builder.Services.AddTransient<HomeViewModel>();

		builder.Services.AddTransient<HomePage>();
		builder.Services.AddTransient<LoginPage>();
		builder.Services.AddTransient<RegisterPage>();

		return builder.Build();
	}
}
