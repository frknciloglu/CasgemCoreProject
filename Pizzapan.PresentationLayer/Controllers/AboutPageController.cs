using Microsoft.AspNetCore.Mvc;
using PizzaPan.BusinessLayer.Abstract;

namespace Pizzapan.PresentationLayer.Controllers
{
    public class AboutPageController : Controller
    {
        private readonly IOurTeamService _ourTeamService;

        public AboutPageController(IOurTeamService ourTeamService)
        {
            _ourTeamService = ourTeamService;
        }

        public IActionResult Index()
        {
            var values=_ourTeamService.TGetList();
            return View(values);
        }
    }
}
