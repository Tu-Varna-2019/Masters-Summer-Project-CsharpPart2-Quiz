using Masters_Summer_Project_CsharpPart2_Quiz.Repositories;
using Masters_Summer_Project_CsharpPart2_Quiz.ViewModels;
using Masters_Summer_Project_CsharpPart2_Quiz.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Masters_Summer_Project_CsharpPart2_Quiz.Services;
using Masters_Summer_Project_CsharpPart2_Quiz.Views;
using Masters_Summer_Project_CsharpPart2_Quiz.Models;
using CommunityToolkit.Maui;

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
		builder.Services.AddTransient<UserRepository>();
		builder.Services.AddTransient<INavigationService, NavigationService>();
		builder.Services.AddSingleton<User>();

		// View model dependency injection
		builder.Services.AddSingleton<RegisterViewModel>();
		builder.Services.AddSingleton<LoginViewModel>();
		builder.Services.AddSingleton<HomeViewModel>();
		builder.Services.AddSingleton<ProfileViewModel>();
		builder.Services.AddSingleton<CreateQuizViewModel>();

		// Pages
		builder.Services.AddSingleton<HomePage>();
		builder.Services.AddSingleton<LoginPage>();
		builder.Services.AddSingleton<RegisterPage>();
		builder.Services.AddSingleton<ProfilePage>();
		builder.Services.AddSingleton<CreateQuizPage>();

		return builder.Build();
	}
}
