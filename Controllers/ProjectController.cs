using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyVidly.Data.IServices;
using MyVidly.Models;
using MyVidly.Models.Context;
using MyVidly.ViewModel;

namespace MyVidly.Controllers
{
    public class ProjectController : Controller
    {
        private readonly MyVidlyDbContext _context;
        private readonly IProjectServices _project;


        public ProjectController(MyVidlyDbContext context, IProjectServices projects) 
        {
            _project = projects;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            var result = await _project.AllList();
            if (result != null)
            {
                return View(result);
            }
            return View();
        }

        // GET: Projects/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projectz
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

       
        // GET: Projects/Edit/5
        public async Task<IActionResult> Update(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var data = await _project.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ListOfProjectViewModel project)
        {
            if (!ModelState.IsValid)
            {
                return View(project);
            }

           /* if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction();
            }*/

            else
            {
                await _project.EditByDetails(project);
                TempData["Success"] = "The item was added successfuly";
            }
            return RedirectToAction("Dashboard", "Admin");
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ListOfProjectViewModel project)
        {
            if (ModelState.IsValid)
            {
                await _project.Create(project);
                TempData["Success"] = "Item successfully added!";
            }
            return RedirectToAction("Dashboard", "Admin");
        }


        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(Project project)
        {
            if (ModelState.IsValid)
            {
                await _project.RemoveData(project);
                TempData["Success"] = "The detail is deleted successfully";


            }
            return RedirectToAction("Dashboard", "Admin");

           
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Projectz.FindAsync(id);
            _context.Projectz.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
            return _context.Projectz.Any(e => e.Id == id);
        }
    }
}
