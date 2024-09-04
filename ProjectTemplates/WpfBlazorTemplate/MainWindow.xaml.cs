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
				new KeyValuePair<string, string>("", "普通/home"),

				// 二级导航
				new KeyValuePair<string, string>("普通", "普通/home"),
				new KeyValuePair<string, string>("普通", "普通/page1"),
				new KeyValuePair<string, string>("维护", "维护/log"),
			};
		});

		services.AddScoped<Redirector>();
	}
}
