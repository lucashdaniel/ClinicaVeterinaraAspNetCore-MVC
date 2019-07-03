using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicaVeterinaria.Models;
using ClinicaVeterinaria.Models.ViewModels;
using ClinicaVeterinaria.Services;
using ClinicaVeterinaria.Services.Exception;
using ClinicaVeterinaria.Services.List;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaVeterinaria.Controllers
{
    public class ProprietariosController : Controller
    {


        private readonly ProprietarioService _proprietarioService;
        private readonly ListProprietarioService _listProprietarioService;


        public ProprietariosController(ProprietarioService proprietarioService, ListProprietarioService listProprietarioService)
        {
            _proprietarioService = proprietarioService;
            _listProprietarioService = listProprietarioService;

        }

        public async Task<IActionResult> Index()
        {
            var list = await _proprietarioService.FindAllAsync();
            return View(list);
        }

        public IActionResult Create()
        {


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Proprietario proprietario)
        {
            if (!ModelState.IsValid)
            {
                return View(proprietario);
            }
            await _proprietarioService.InsertAsync(proprietario);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return View();
            }

            var obj = await _proprietarioService.FindByIdAsync(id.Value);
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
            await _proprietarioService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return View();
            }

            var obj = await _proprietarioService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return View();
            }

            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = await _proprietarioService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            List<Proprietario> proprietarios = _listProprietarioService.FindAll();
            ProprietarioFormViewModel viewModel = new ProprietarioFormViewModel { Proprietario = obj };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(int id, Proprietario proprietario)
        {
            if (id != proprietario.Id)
            {
                return BadRequest();
            }
            try
            {
                await _proprietarioService.UpdateAsync(proprietario);
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
    } }


    