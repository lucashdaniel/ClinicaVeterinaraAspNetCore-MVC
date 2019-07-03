using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ClinicaVeterinaria.Models;
using ClinicaVeterinaria.Models.ViewModels;
using ClinicaVeterinaria.Services;
using ClinicaVeterinaria.Services.List;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClinicaVeterinaria.Controllers
{
    public class CaixasController : Controller
    {
        private readonly CaixaService _caixaService;
        private readonly ListConsultaService _listConsultaService;
        private readonly ListExameService _listExameService;
        private readonly ListAnimalService _listAnimalService;
        private readonly ListProprietarioService _listProprietarioService;
        public List<Animal> listaDeAnimais;
        public List<Consulta> listaDeConsultas;

        public CaixasController(CaixaService caixaService, ListConsultaService listConsultaService, ListExameService listExameService, ListAnimalService listAnimalService, ListProprietarioService listProprietarioService)
        {
            _caixaService = caixaService;
            _listConsultaService = listConsultaService;
            _listExameService = listExameService;
            _listAnimalService = listAnimalService;
            _listProprietarioService = listProprietarioService;

        }


        public async Task<IActionResult> Index()
        {
            var list = await _caixaService.FindAllAsync();
            return View(list);
        }


        public IActionResult CreateSaida()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateSaida(Caixa caixa)
        {
            caixa.Tipo = "Saida";
            caixa.Valor = caixa.Valor * -1;
            caixa.ProprietarioId = 1;
            if (!ModelState.IsValid)
            {
                return View(caixa);
            }

            _caixaService.Insert(caixa);
            return RedirectToAction(nameof(Index));
        }



        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id Not Found" });
            }

            var obj = _caixaService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id Not Found" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _caixaService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id Not Provided" });
            }

            var obj = _caixaService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id Not Found" });
            }

            return View(obj);
        }

        public double Somador()
        {
            return 0;  
        }


        public IActionResult Edit()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(int id, Caixa caixa)
        {
            if (id != caixa.Id)
            {
                return BadRequest();
            }
            await _caixaService.UpdateAsync(caixa);
            return RedirectToAction(nameof(Index));
        }






        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);


        }


    }
}
    
