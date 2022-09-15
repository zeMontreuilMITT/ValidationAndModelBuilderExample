using Microsoft.AspNetCore.Mvc;
using ValidationAndModelBuilder.Data;
using ValidationAndModelBuilder.Models;

namespace ValidationAndModelBuilder.Controllers
{
    public class StaffController : Controller
    {
        private ValidationAndModelBuilderContext _context { get; set; }
        public StaffController(ValidationAndModelBuilderContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("FirstName, LastName, Salary, JobTitle")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                _context.Staff.Add(staff);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
