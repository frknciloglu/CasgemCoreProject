using Microsoft.AspNetCore.Mvc;

namespace Pizzapan.PresentationLayer.ViewComponents.Default
{
    public class _FeaturePartial:ViewComponent

    {
        public IViewComponentResult Invoke()
        {
            ViewBag.title1 = "Her gün pizza yiyin";
            ViewBag.title2 = "SEvdiğiniz pizzaları paylaşın";
            return View();

        }
    }
}
