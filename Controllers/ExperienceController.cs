using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyVidly.Data.IServices;
using MyVidly.Models;
using MyVidly.ViewModel;
using System.Threading.Tasks;

namespace MyVidly.Controllers
{
    public class ExperienceController : Controller
    {
        private readonly IExperienceServices _experience;
        private readonly IMapper _mapper;

        public ExperienceController(IExperienceServices experience, IMapper mapper)
        {
            _experience = experience;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            if (id == 0)
                return NotFound();
            var data = await _experience.GetById(id);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ListOfExperiencesViewModel experienceViews)
        {
            if (!ModelState.IsValid)
            {
                return View(experienceViews);
            }
            else
            {
                await _experience.EditByDetails(experienceViews);
                TempData["Success"] = "Details updated Successfully";
            }

            return RedirectToAction("Dashboard", "Admin");
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(ListOfExperiencesViewModel experiencesViews)
        {
            if (ModelState.IsValid)
            {
                await _experience.Create(experiencesViews);
                TempData["Success"] = "An experience created!";

            }
            return RedirectToAction("Dashboard", "Admin");
        }

        public async Task<IActionResult> Delete(Experience experience)
        {
            if (ModelState.IsValid)
            {
                await _experience.RemoveData(experience);
                TempData["Success"] = "You removed this item successfully";
            }
            return RedirectToAction("Dashboard", "Admin");
        }
        public async Task<IActionResult> Index()
        {
            var result = await _experience.AllList();
            if (result != null)
            {
                return View(result);
            }
            return View();
        }
    }
}
