using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ClinicaVeterinaria.Services;
using ClinicaVeterinaria.Models;
using ClinicaVeterinaria.Models.ViewModels;
using ClinicaVeterinaria.Services.Exception;
using System.Diagnostics;
using ClinicaVeterinaria.Services.List;

namespace ClinicaVeterinaria.Controllers
{
    public class VeterinariosController : Controller
    {   
        
        private readonly VeterinarioService _veterinarioService;
        private readonly ListVeterinarioService _ListVeterinarioService;
        
        public VeterinariosController(VeterinarioService veterinarioService, ListConsultaService listConsultaService, ListVeterinarioService listVeterinarioService)
        {
            _veterinarioService = veterinarioService;
            _ListVeterinarioService = listVeterinarioService;
            
        }

        public IActionResult Index()
        {
            var list = _veterinarioService.FindAll();
            
            return View(list);
        }
        public IActionResult Create()
        {

        
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Veterinario veterinario)
        {
            if (!ModelState.IsValid)
            {
                return View(veterinario);
            }
            _veterinarioService.Insert(veterinario);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return View();
            }

            var obj = _veterinarioService.FindById(id.Value);
            if (obj == null)
            {
                return View();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _veterinarioService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return View();
            }

            var obj = _veterinarioService.FindById(id.Value);
            if (obj == null)
            {
                return View();
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj =  _veterinarioService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            List<Veterinario> veterinarios = _ListVeterinarioService.FindAll();
            VeterinarioFormViewModel viewModel = new VeterinarioFormViewModel { Veterinario = obj };
            return View(viewModel);



        }
    }
}

