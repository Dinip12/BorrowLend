using BorrowLend.Data;
using BorrowLend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity.Migrations;


namespace BorrowLend.Controllers
{
    public class ExpenseTypeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public IActionResult Index()
        {

            return View(db.ExpensesType);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExpenseType expenseType)
        {
            if (ModelState.IsValid)
            {
                db.ExpensesType.Add(expenseType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expenseType);
        }
        public IActionResult Update(int? id)
        {
            var obj = db.ExpensesType.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ExpenseType obj)
        {
            if (obj == null)
            {
                return NotFound();
            }
            db.ExpensesType.AddOrUpdate();
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            var obj = db.ExpensesType.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(ExpenseType obj)
        {
            if (obj == null)
            {
                return NotFound();
            }
            db.ExpensesType.Remove(db.ExpensesType.Find(obj.Id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
