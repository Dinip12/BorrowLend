using BorrowLend.Data;
using BorrowLend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.Entity.Migrations;


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
            
           
                db.Expenses.Add(expenseVM.Expense);
                db.SaveChanges();
                return RedirectToAction("Index");
            
           
        }
        public IActionResult Update(int? id)
        {
            var obj = db.Expenses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            ExpenseVM item = new ExpenseVM();
            item.Expense = obj;
            item.typeDropDown = db.ExpensesType.Select(i => new SelectListItem
            {
                Text = i.ExpenseTypeName,
                Value = i.Id.ToString()
            });
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Expense expense)
        {
            if (expense == null)
            {
                return NotFound();
            }
           
            db.Expenses.AddOrUpdate(expense);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            var obj = db.Expenses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            ExpenseVM item = new ExpenseVM();
            item.Expense = obj;
            item.typeDropDown = db.ExpensesType.Select(i => new SelectListItem
            {
                Text = i.ExpenseTypeName,
                Value = i.Id.ToString()
            });
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(ExpenseVM obj)
        {
            if (obj == null)
            {
                return NotFound();
            }
            db.Expenses.Remove(db.Expenses.Find(obj.Expense.Id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
