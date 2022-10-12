using BorrowLend.Data;
using BorrowLend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BorrowLend.Controllers
{
    public class ExpenseController:Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public IActionResult Index()
        {
            IEnumerable<Expense> obj = db.Expenses;    
            return View(obj);
        }
        public IActionResult Create()
        {
            ExpenseVM expenseVM = new ExpenseVM
            {
                Expense = new Expense(),
                typeDropDown = db.ExpensesType.Select(i => new SelectListItem
                {
                    Text = i.ExpenseTypeName,
                    Value = i.Id.ToString()
                })
            };
            return View(expenseVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExpenseVM expenseVM)
        {
            if (ModelState.IsValid)
            {
                db.Expenses.Add(expenseVM.Expense);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expenseVM);
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
            db.Items.Update(obj);
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
            db.Items.Remove(db.Items.Find(obj.Id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
