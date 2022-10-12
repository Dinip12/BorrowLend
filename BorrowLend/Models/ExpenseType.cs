using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BorrowLend.Models
{
    [Table("ExpenseType")]
    public class ExpenseType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ExpenseTypeName { get; set; }
    }
}
