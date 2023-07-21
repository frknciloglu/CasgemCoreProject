using Microsoft.AspNetCore.Mvc;

namespace Pizzapan.PresentationLayer.ViewComponents.Default
{
    public class _AboutOurTeamPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
