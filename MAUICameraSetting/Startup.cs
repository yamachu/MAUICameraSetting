﻿using Microsoft.AspNetCore.Components.WebView.Maui;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Hosting;
using MAUICameraSetting.Data;
using MAUICameraSetting.Shared.Services;

namespace MAUICameraSetting
{
	public class Startup : IStartup
	{
		public void Configure(IAppHostBuilder appBuilder)
		{
			appBuilder
				.RegisterBlazorMauiWebView(typeof(Startup).Assembly)
				.UseMicrosoftExtensionsServiceProviderFactory()
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				})
				.ConfigureServices(services =>
				{
					services.AddBlazorWebView();
					services.AddSingleton<WeatherForecastService>();
					#if __MACCATALYST__
					services.AddSingleton<ICameraSettingService, MacCatalyst.Services.CameraSettingService>();
					#endif
				});
		}
	}
}
