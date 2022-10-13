using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC.Models.ViewModels
{
    public class ExpenseVM
    {
        public Expense? Expense { get; set; }

        public IEnumerable<SelectListItem>? TypeDropDown { get; set; }
    }
}
