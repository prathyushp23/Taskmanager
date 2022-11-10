using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class EmpTaskController : Controller
    {
        private readonly TMDBContext tMContext;

        public EmpTaskController(TMDBContext tMContext)
        {
            this.tMContext = tMContext;
        }

        // GET: EmpTaskController
        public ActionResult Index()

        {
            List<EmpTask> tasklist = tMContext.EmpTask.Include(e => e.Employee).ToList();
            return View(tasklist);
        }

        

        // GET: EmpTaskController/Create
        public ActionResult Create()
        {
            List<Employee> employees = tMContext.Employee.ToList();   
            ViewBag.EmployeesList = new SelectList(employees, "EmpId", "EmpName");
            return View();
        }

        // POST: EmpTaskController/Create
        [HttpPost]
        public async Task<ActionResult> Create(EmpTask emptsk)
        {
            try
            {
                
                EmpTask taskadd = new EmpTask();
               
                taskadd.TskName = emptsk.TskName;
                taskadd.EmpId = emptsk.EmpId;   
                await tMContext.EmpTask.AddAsync(taskadd);
                await tMContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: EmpTaskController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var tsk = await tMContext.EmpTask.FindAsync(id);
            if (tsk != null)
            {
                List<Employee> employees = tMContext.Employee.ToList();
                ViewBag.EmployeesList = new SelectList(employees, "EmpId", "EmpName");
                var task = new updateEmpTaskViewModel();
                task.TskId = tsk.TskId;
                task.TskName = tsk.TskName;
                task.EmpId = tsk.EmpId;
                return await Task.Run(() => View("Edit", task));
            }
            return RedirectToAction("Index");
        }

        // POST: EmpTaskController/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(updateEmpTaskViewModel model)
        {
            try
            {

                var edittask = await tMContext.EmpTask.FindAsync(model.TskId);
                if (edittask != null)
                {
                    edittask.TskName = model.TskName;
                    edittask.EmpId = model.EmpId;
                    await tMContext.SaveChangesAsync();
                    return RedirectToAction("index");
                }
                return RedirectToAction("index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpTaskController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmpTaskController/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(updateEmpTaskViewModel model)
        {
            var emptask = await tMContext.EmpTask.FindAsync(model.TskId);

            if (emptask != null)
            {
                tMContext.EmpTask.Remove(emptask);
                await tMContext.SaveChangesAsync();
                return RedirectToAction("index");
            }
            return RedirectToAction("index");
        }
    }
}
