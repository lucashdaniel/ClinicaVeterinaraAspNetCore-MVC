using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicaVeterinaria.Models;
using ClinicaVeterinaria.Services;
using Microsoft.AspNetCore.Mvc;
using ClinicaVeterinaria.Services.Exception;
using ClinicaVeterinaria.Models.ViewModels;
using ClinicaVeterinaria.Services.List;
using System.Diagnostics;

namespace ClinicaVeterinaria.Controllers
{


    public class AnimalsController : Controller
    {
        private readonly AnimalService _animalService;
        private readonly ListProprietarioService _listProprietarioService;
        private readonly ListEspecieService _listEspecieService;

        public AnimalsController(AnimalService animalService, ListProprietarioService listProprietarioService, ListEspecieService listEspecieService)
        {
            _animalService = animalService;
            _listProprietarioService = listProprietarioService;
            _listEspecieService = listEspecieService;
        }

        
        public async Task<IActionResult> Index( string busca)
        {
            
            var list = await _animalService.Pesquisa(busca);
            return View(list);
            
           
        }

        [HttpPost]
        public async Task<IActionResult> Pesquisa(string busca)
        {
            var list = await _animalService.Pesquisa(busca);

            return View(list);
        }

       

      
        public IActionResult Create()
        {
            
            var especies = _listEspecieService.FindAll();
            var proprietarios = _listProprietarioService.FindAll();
            var viewModel = new AnimalFormViewModel { Proprietarios = proprietarios, Especies = especies };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Animal animal)
        {
            if (!ModelState.IsValid)
            {
                return View(animal);
            }
            await _animalService.InsertAsync(animal);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return View();
            }

            var obj = await _animalService.FindByIdAsync(id.Value);
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
            await _animalService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return View();
            }

            var obj = await _animalService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return View();
            }

            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var obj = await _animalService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            List<Especie> especies = _listEspecieService.FindAll();
            List<Proprietario> proprietarios = _listProprietarioService.FindAll();
            AnimalFormViewModel viewModel = new AnimalFormViewModel { Animal = obj, Proprietarios = proprietarios, Especies = especies };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(int id, Animal animal)
        {
            if(id != animal.Id)
            {
                return BadRequest();
            }
            try
            {
                await _animalService.UpdateAsync(animal);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }
        }
    }
}
   
