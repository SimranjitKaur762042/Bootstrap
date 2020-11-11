using Microsoft.AspNetCore.Mvc;
using PriceQuotation.Models;

namespace PriceQuotation.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Discount = 0;
            ViewBag.Total = 0;
            ViewBag.DiscountPercent = 0;
            ViewBag.Sale = 0;
            return View();
        }

        [HttpPost]
        public IActionResult Index(Quotation quote)
        {
            if (ModelState.IsValid)
            {
                ViewBag.DiscountPercent = quote.CalcDiscountPercent();
                ViewBag.Discount = quote.CalculateDiscount();
                ViewBag.Total = quote.CalculateTotal();
                ViewBag.Sale = quote.CalcSale();
            } 
            else
            {
                ViewBag.Discount = 0;
                ViewBag.Total = 0;
                ViewBag.DiscountPercent = 0;
                ViewBag.Sale = 0;
            }
            return View(quote);
        }
    }
}
