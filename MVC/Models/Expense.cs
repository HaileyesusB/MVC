using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        [DisplayName ("Expense Name")]
        [Required]
        public string ExpenseName { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Ammount must be greater than 0!")]
        public string Ammount { get; set; }

        [DisplayName("Expense Type")]
        public int?  TypeId { get; set; }
        [ForeignKey("TypeId")]
        public virtual ExpenseType? ExpenseType { get; set; }
    }
}
