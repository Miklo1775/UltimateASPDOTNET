using Microsoft.AspNetCore.Mvc;

namespace ViewComponentDemo.ViewComponents;

// [ViewComponent]
public class GridViewComponent : ViewComponent
{
	Task<IViewComponentResult> InvokeAsync()
	{
		return View(); //INVOKES A PARTIAL VIEW FROM Views/Shared/Components/Grid/Default.cshtml
	}
}