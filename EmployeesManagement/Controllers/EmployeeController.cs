using EmployeesManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EmployeesManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext _context;
        public EmployeeController(EmployeeDbContext context)
        {
            _context = context;
        }
        // GET: EmployeeController
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employees.ToListAsync());
        }

        // GET: EmployeeController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeController/AddOrEdit
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new EmployeeModel());
            }
            else
                return View(_context.Employees.Find(id));
        }

        // POST: EmployeeController/AddOrEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id,FirstName,LastName,PersonalNumber,Email,Password,Gender,DOB,Position,Status,FiredDate,Phone")]EmployeeModel model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    if(model.Id == 0)
                    {
                        _context.Add(model);
                    }

                    else
                    {
                        _context.Employees.Update(model);
                    }
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(model);
            }
            catch
            {
                return View();
            }
        }
        // POST: EmployeeController/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var record = await _context.Employees.FindAsync(id);
                _context.Employees.Remove(record);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
