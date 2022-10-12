using Microsoft.AspNetCore.Mvc.Rendering;

namespace BorrowLend.Models
{
    public class ExpenseVM
    {
        public Expense Expense { get; set; }
        public IEnumerable<SelectListItem> typeDropDown { get; set; }
    }

}
