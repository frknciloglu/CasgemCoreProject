using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Pizzapan.EntityLayer.Concrete;
using PizzaPan.BusinessLayer.Abstract;
using PizzaPan.BusinessLayer.ValidationRules.OurTeamValidator;

namespace Pizzapan.PresentationLayer.Controllers
{
    public class OurTeamController : Controller
    {
        private readonly IOurTeamService _ourTeamService;

        public OurTeamController(IOurTeamService ourTeamService)
        {
            _ourTeamService = ourTeamService;
        }

        public IActionResult Index()
        {
            var values=_ourTeamService.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddOurTeam()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddOurTeam(OurTeam ourTeam)
        {
            CreateOurTeamValidator createOurTeamValidator=new CreateOurTeamValidator();
            ValidationResult result=createOurTeamValidator.Validate(ourTeam);
            if (result.IsValid)
            {
                _ourTeamService.TInsert(ourTeam);
                return RedirectToAction("GetTeams");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult GetTeams()
        {
            var values = _ourTeamService.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult UpdateTeam(int id) {
            var values=_ourTeamService.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateTeam(OurTeam ourTeam)
        {
            _ourTeamService.TUpdate(ourTeam);
            return RedirectToAction("GetTeams");
        }
        public IActionResult DeleteTeam(int id)
        {
            var value = _ourTeamService.TGetByID(id);
            _ourTeamService.TDelete(value);
            return RedirectToAction("GetTeams");
        }
    }
}
