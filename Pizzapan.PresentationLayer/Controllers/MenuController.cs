﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizzapan.DataAccessLayer.Concrete;
using PizzaPan.BusinessLayer.Abstract;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzapan.PresentationLayer.Controllers
{
    public class MenuController : Controller
    {
        private readonly IProductService _productService;
        private readonly Context _context;

        public MenuController(IProductService productService, Context context)
        {
            _productService = productService;
            _context = context;
        }
        public  IActionResult Index()
        {
            var values = _context.Categories.Include(x => x.Products).ToList();
            
            return View(values);
        }
    }
}
