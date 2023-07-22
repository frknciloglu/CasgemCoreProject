using Microsoft.AspNetCore.Mvc;
using Pizzapan.EntityLayer.Concrete;
using PizzaPan.BusinessLayer.Abstract;
using System;

namespace Pizzapan.PresentationLayer.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public IActionResult CreateCode()
        {
            string[] symbols = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L" };
            int c1, c2, c3, c4;
            Random rnd = new Random();
            c1= rnd.Next(0,symbols.Length);
            c2= rnd.Next(0,symbols.Length);
            c3= rnd.Next(0,symbols.Length);
            c4= rnd.Next(0,symbols.Length);
            int c5 = rnd.Next(10, 100);
            ViewBag.v = symbols[c1] + symbols[c2] + symbols[c3] + symbols[c4] + c5;
            return View();
        }
        [HttpPost]
        public IActionResult CreateCode(Discount discount)
        {
            discount.CreatedDate=Convert.ToDateTime(DateTime.Now.ToShortDateString());
            discount.EndingDate = Convert.ToDateTime(DateTime.Now.AddDays(3));
            _discountService.TInsert(discount);
            return RedirectToAction("DiscountCodelist");
        }
        public IActionResult DiscountCodelist()
        {
            var values = _discountService.TGetList();
            return View(values);
        }
    }
}
