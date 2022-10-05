using BorrowLend.Data;
using BorrowLend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity.Migrations;

namespace BorrowLend.Controllers
{
    public class ItemController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public IActionResult Index()
        {
            
            return View(db.Items);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item item)
        {
            db.Items.Add(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Update(int? id)
        {
            var obj = db.Items.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Item obj)
        {           
            if (obj == null)
            {
                return NotFound();
            }
            db.Items.AddOrUpdate(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            var obj = db.Items.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Item obj)
        {
            if (obj == null)
            {
                return NotFound();
            }
            db.Items.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
