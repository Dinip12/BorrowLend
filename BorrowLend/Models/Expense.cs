using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BorrowLend.Models
{
    [Table("Expanses")]
    public class Expense
    {
        [Key]        
        public int Id { get; set; }
        [Required]
        public string ExpenseName { get; set; }
        [Required]
        public int Amount { get; set; }
        public int ExpenseTypeId { get; set; }
        [ForeignKey("ExpenseTypeId")]
        public virtual ExpenseType ExpenseType { get; set; }
    }
}
