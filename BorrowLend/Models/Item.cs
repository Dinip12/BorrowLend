using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BorrowLend.Models
{
    [Table("BorrowLend")]
    public class Item
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string ItemName { get; set; }

        [Required]
        public string Borrower { get; set; }

        [Required]
        public string Lender { get; set; }
        

    }
}
