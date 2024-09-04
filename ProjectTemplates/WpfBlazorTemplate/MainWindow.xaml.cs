using JCNET;
using Microsoft.Extensions.DependencyInjection;
using RazorUI.导航;
using System.Collections.Generic;
using System.Windows;

namespace $safeprojectname$;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();
		ServiceCollection serviceCollection = new();
		serviceCollection.InjectStringBuilderLogWriter();
		serviceCollection.InjectRedirector();
		serviceCollection.AddWpfBlazorWebView();
		Resources.Add("services", serviceCollection.BuildServiceProvider());
	}
}

internal static class Injector
{
	public static void InjectRedirector(this IServiceCollection services)
	{
		services.AddSingleton<IRedirectUriProvider>((p) =>
		{
			return new DictionaryRedirectUriProvider()
			{
				// 根路径
				new KeyValuePair<string, string>("", "commom/home"),

				// 二级导航
				new KeyValuePair<string, string>("commom", "commom/home"),
				new KeyValuePair<string, string>("commom", "commom/page1"),
				new KeyValuePair<string, string>("maintain", "maintain/log"),
			};
		});

		services.AddScoped<Redirector>();
	}
}
