using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicaVeterinaria.Models;
using ClinicaVeterinaria.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaVeterinaria.Controllers
{
    public class EspeciesController : Controller
    {
        private readonly EspecieService _especieService;

        public EspeciesController(EspecieService especieService)
        {
            _especieService = especieService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _especieService.FindAllAsync();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Especie especie)
        {
            if (!ModelState.IsValid)
            {
                return View(especie);
            }
            await _especieService.InsertAsync(especie);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return View();
            }

            var obj = await _especieService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return View();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _especieService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return View();
            }

            var obj = await _especieService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return View();
            }

            return View(obj);
        }


    }
}
   
    
