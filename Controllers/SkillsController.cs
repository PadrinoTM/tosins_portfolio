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
    public class SkillsController : Controller
    {
        private readonly ISkillServices _skills;



        public SkillsController(ISkillServices skill)
        {
            _skills = skill;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _skills.AllList();
            if (result != null)
            {
                return View(result);
            }
            return View();
        }

        public IActionResult Create() => View();
        // GET: Skills/Create




        // POST: Skills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ListOfSkillsViewModel skill)
        {

            if (ModelState.IsValid)
            {
                await _skills.Create(skill);
                TempData["Success"] = "You successfully added a skill to the dashboard ";
            }
            return RedirectToAction("Dashboard", "Admin");
        }

        // GET: Skills/Edit/5
        public async Task<IActionResult> Update(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var Findskill = await _skills.GetById(id);
            if (Findskill == null)
            {
                return NotFound();
            }
            return View(Findskill);
        }

        // POST: Skills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ListOfSkillsViewModel skill)
        {
            if (!ModelState.IsValid)
            {
                return View(skill);
            }

            else
            {
                await _skills.EditByDetails(skill);
                TempData["Success"] = "You updated an item successfully";

            }
            return RedirectToAction("Dashboard", "Admin");

        }


        
     
      [HttpPost]
        public async Task<IActionResult> Delete(Skills skill)
        {
            if (ModelState.IsValid)
            {
              
                await _skills.RemovedData(skill);
                TempData["Success"] = "You deleted this record successfully";
            }

            return RedirectToAction("Dashboard", "Admin");
        }

    }
}
    



/*private bool SkillsExists(int id)
{
    return _context.Skills.Any(e => e.Id == id);
}*/