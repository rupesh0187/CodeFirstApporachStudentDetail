using Microsoft.AspNetCore.Mvc;
using StudentDetail.Models;
using StudentDetail.Models.Context;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace StudentDetail.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentDBContext studentDB;

        

        public HomeController(StudentDBContext studentDB) 
        {
            this.studentDB = studentDB;
        }
       
        public async Task<IActionResult> Index()
        {
            return studentDB.Students != null ?
                View(await studentDB.Students.ToListAsync()) :
                Problem("Entity set 'StudentDBContext.Students' is null.");
        }
        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Create(Student std)
        {
            if (ModelState.IsValid)
            {
                studentDB.Students?.Add(std);
                studentDB.SaveChanges();
                TempData["insert_success"] = "Inserted..";
                return RedirectToAction("Index", "Home");
            }
            return View(std);

        }
        public IActionResult Details(int? id)
        {
            if (id == null || studentDB.Students == null)
            {
                return NotFound();
            }
            var stdData = studentDB.Students.FirstOrDefault(s => s.Id == id);
            if (stdData == null)
            {
                return NotFound();
            }
            return View(stdData);

        }

        public IActionResult Edit(int? id)
        {
            if (id == null || studentDB.Students == null)
            {
                return NotFound();
            }
            var stdData = studentDB.Students.Find(id);
            if (stdData == null)
            {
                return NotFound();
            }
            return View(stdData);

        }
        [HttpPost]
        public IActionResult Edit(int? id, Student std)
        {
            if (id != std.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                studentDB.Update(std);
                studentDB.SaveChanges();
                TempData["update_success"] = "Updated..";
                return RedirectToAction("Index", "Home");
            }
            return View(std);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || studentDB.Students == null)
            {
                return NotFound();
            }

            var stdData = studentDB.Students.FirstOrDefault(s => s.Id == id);
            if (stdData == null)
            {
                return NotFound();
            }
            return View(stdData);


        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfimed(int? id)
        {
            var stdData = studentDB.Students?.Find(id);
            if (stdData != null)
            {
                studentDB.Students?.Remove(stdData);
            }
            studentDB.SaveChanges();
            TempData["delete_success"] = "Deleted..";
            return RedirectToAction("Index", "Home");

        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}