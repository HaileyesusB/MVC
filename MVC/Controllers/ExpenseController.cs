using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Data;
using MVC.Models;
using MVC.Models.ViewModels;

namespace MVC.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExpenseController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Expense> objList = _context.Expense;
            foreach (var obj in objList) 
            {
              obj.ExpenseType = _context.ExpenseType.FirstOrDefault(u => u.Id == obj.TypeId);
            }
            return View(objList);
           // return View();
        }
          
        // GET-Create
        [HttpGet]
        public IActionResult Create()
        {
            //IEnumerable<SelectListItem> TypeDropDown = _context.ExpenseType.Select(i =>
            //new SelectListItem
            //{
            //    Text = i.Name,
            //    Value = i.Id.ToString()
            //});
            //ViewBag.TypeDropDown = TypeDropDown;

            ExpenseVM expenseVM = new ExpenseVM()
            {
              Expense = new Expense(),
              TypeDropDown = _context.ExpenseType.Select(i => new SelectListItem
              {
                  Text = i.Name,
                  Value= i.Id.ToString(),   
              })
            }; 
            
            return View(expenseVM);
        }

        // Post-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExpenseVM obj)
        {
            //
            if (ModelState.IsValid)
            {
               // obj.TypeId = 1;
                _context.Expense.Add(obj.Expense);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj) ;
        }

        // GET Delete
        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _context.Expense.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _context.Expense.Find(id);
            if (obj == null) 
            {
                return NotFound();
            }

            _context.Expense.Remove(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET Update
        public IActionResult Update(int? id)
        {
            ExpenseVM expenseVM = new ExpenseVM()
            {
                Expense = new Expense(),
                TypeDropDown = _context.ExpenseType.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString(),
                })
            };


            if (id == null || id == 0)
            {
                return NotFound();
            }
            expenseVM.Expense = _context.Expense.Find(id);

            if (expenseVM.Expense == null)
            {
                return NotFound();
            }
            return View(expenseVM);
        }

        // POST Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ExpenseVM obj)
        {
            if (ModelState.IsValid)
            {
                _context.Expense.Update(obj.Expense);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }



    }
}

