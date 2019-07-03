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

namespace ClinicaVeterinaria.Controllers
{
    public class MedicamentosController : Controller
    {   
        private readonly CaixaService  _caixaService;
        private readonly MedicamentoService _medicamentoService;
        private readonly ListAnimalService _listAnimalService;
        private readonly ListProprietarioService _listProprietarioService;
        public Caixa caixa = new Caixa();

        public MedicamentosController(MedicamentoService medicamentoService, ListAnimalService listAnimalService, ListProprietarioService listProprietarioService, CaixaService caixaService)
        {
            _medicamentoService = medicamentoService;
            _listAnimalService = listAnimalService;
            _listProprietarioService = listProprietarioService;
            _caixaService = caixaService;

        }


        public async Task<IActionResult> Index()
        {

            var list = await _medicamentoService.FindAllAsync();
            return View(list);
        }

        public IActionResult Create()
        {
            
            var proprietarios = _listProprietarioService.FindAll();
            var animals = _listAnimalService.FindAll();
            var viewModel = new MedicamentoFormViewModel {Animals = animals,  Proprietarios = proprietarios };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Medicamento medicamento)
        {
            caixa = new Caixa(medicamento.Valor, "Medicamento", medicamento.Id, medicamento.AnimalId, medicamento.ProprietarioId, "Entrada");
            if (!ModelState.IsValid)
            {
                return View(medicamento);
            }
            _medicamentoService.Insert(medicamento);
            InsertCaixa();
            return RedirectToAction(nameof(Index));
        }

        public void InsertCaixa()
        {
            List<Animal> listaDeAnimal = _listAnimalService.FindAll();
            List<Proprietario> listaProprietarios = _listProprietarioService.FindAll();

            for (int i = 0; i < listaDeAnimal.Count; i++)
            {
                if (listaDeAnimal[i].Id == caixa.AnimalId)
                {
                    caixa.Descricao = "Medicamento para animal " + listaDeAnimal[i].NomeAnimal + " ";
                }
            }

            for (int i = 0; i < listaProprietarios.Count; i++)
            {
                if (listaProprietarios[i].Id == caixa.ProprietarioId)
                {
                    caixa.Descricao = caixa.Descricao + " comprado pelo proprietário  " + listaProprietarios[i].NomeProprietario;
                }
            }

            _caixaService.Insert(caixa);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id Not Found" });
            }

            var obj = _medicamentoService.FindById(id.Value);
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
            _medicamentoService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id Not Provided" });
            }

            var obj = _medicamentoService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id Not Found" });
            }

            return View(obj);
        }


        public IActionResult Edit()
        {
            return View();
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(int id, Medicamento medicamento)
        {
            if (id != medicamento.Id)
            {
                return BadRequest();
            }
            await _medicamentoService.UpdateAsync(medicamento);
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
    
