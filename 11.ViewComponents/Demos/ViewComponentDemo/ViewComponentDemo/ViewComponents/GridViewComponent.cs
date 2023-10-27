using Microsoft.AspNetCore.Mvc;

namespace ViewComponentDemo.ViewComponents;

// [ViewComponent]
public class GridViewComponent : ViewComponent
{
	public async Task<IViewComponentResult> InvokeAsync()
	{
		return View("Sample"); //INVOKES A PARTIAL VIEW FROM Views/Shared/Components/Grid/Default.cshtml
	}
}