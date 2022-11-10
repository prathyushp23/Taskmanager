using TaskManager.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.EntityFrameworkCore;

namespace TaskManager.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly TMDBContext tMContext;

        public EmployeeController(TMDBContext tMContext)
        {
            this.tMContext = tMContext;
        }

        [HttpGet]
        public  IActionResult Index()
        {
            List<Employee> employees = tMContext.Employee.ToList();
            return View(employees);
        }
        [HttpGet]
        public IActionResult Add()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Employee employeeadd)
        {
            Employee employee = new Employee();
            employee.EmpName = employeeadd.EmpName;
            await tMContext.Employee.AddAsync(employee);
            await tMContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var emp = await tMContext.Employee.FindAsync(id);
            if (emp != null)
            {
                var employee = new updateEmplyeeViewModel();
                employee.EmpId = emp.EmpId;
                employee.EmpName = emp.EmpName;
                return await Task.Run(()=>View("view", employee));
            }
            return RedirectToAction("Index");
            
        }

        [HttpPost]
        public async Task<IActionResult> View(updateEmplyeeViewModel model)
        {
            var editemployee = await tMContext.Employee.FindAsync(model.EmpId);
            if (editemployee != null)
            {
                editemployee.EmpName = model.EmpName;
                await tMContext.SaveChangesAsync();
                return RedirectToAction("index");
            }
            return RedirectToAction("index");
        }
        
        [HttpPost]
        public async Task<IActionResult> Delete(updateEmplyeeViewModel model)
        {
            var employee = await tMContext.Employee.FindAsync(model.EmpId);
            
            if(employee != null)
            {
                tMContext.Employee.Remove(employee);
                await tMContext.SaveChangesAsync();
                return RedirectToAction("index");
            }
            return RedirectToAction("index");
        }

    }
}
