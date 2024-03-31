using System;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace Masters_Summer_Project_CsharpPart2_Quiz;

class Program : MauiApplication
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

	static void Main(string[] args)
	{
		var app = new Program();
		app.Run(args);
	}
}
