using Microsoft.AspNetCore.Components;
using RazorUI.导航;
using System.Threading.Tasks;

namespace $safeprojectname$.Pages.维护;

public partial class LogPage
{
	protected override async Task OnParametersSetAsync()
	{
		await base.OnParametersSetAsync();
		Redirector.UpdateRedirectUri();
	}

	[Inject]
	private Redirector Redirector { get; set; } = default!;
}
