using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MVC.Models
{
    public class ExpenseType
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Expense Catagory")]
        [Required]
        public string Name { get; set; }
    }
}
