using BorrowLend.Data;
using BorrowLend.Models;
using Microsoft.AspNetCore.Mvc;

namespace BorrowLend.Controllers
{
    public class ItemController : Controller
    {
        public IActionResult Index()
        {
            ApplicationDbContext applicationDbContext = new ApplicationDbContext();
            return View(applicationDbContext.Items);
        }

    }
}
