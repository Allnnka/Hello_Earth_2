using Microsoft.AspNetCore.Components.WebView.Maui;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Hosting;
using Hello_Earth_2.Data;
using Google.Apis.Auth.OAuth2;
using System.IO;
using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace Hello_Earth_2
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			Device.BeginInvokeOnMainThread(async () => { await InitAsync(); });
			
			var builder = MauiApp.CreateBuilder();
			builder
				.RegisterBlazorMauiWebView()
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				});

			builder.Services.AddBlazorWebView();
			builder.Services.AddSingleton<WeatherForecastService>();

			return builder.Build();
		}
		private static async Task InitAsync()
		{
			var stream = await Microsoft.Maui.Essentials.FileSystem.OpenAppPackageFileAsync("Assets/google-services.json");
			FirebaseAdmin.FirebaseApp.Create(
				new FirebaseAdmin.AppOptions()
				{
					Credential = GoogleCredential.FromStream(stream),
				}
			);

		}
	}
}