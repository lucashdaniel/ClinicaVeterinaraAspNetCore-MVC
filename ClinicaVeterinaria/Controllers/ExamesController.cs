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
    public class ExamesController : Controller
    {
        private readonly ExameService _exameService;
        private readonly ListAnimalService _listAnimalService;
        private readonly ListProprietarioService _listProprietarioService;
        private readonly ListEspecieService _listEspecieService;
        private readonly CaixaService _caixaService;
        public Caixa caixa = new Caixa();

        public ExamesController(ExameService exameService,
            ListAnimalService listAnimalService,
            ListProprietarioService listProprietarioService,
            ListEspecieService listEspecieService,
            CaixaService caixaService)
        {
            _exameService = exameService;
            _listAnimalService = listAnimalService;
            _listProprietarioService = listProprietarioService;
            _listEspecieService = listEspecieService;
            _caixaService = caixaService;

        }


        public async Task<IActionResult> Index()
        {

            var list = await _exameService.FindAllAsync();
            return View(list);
        }

        public IActionResult Create()
        {
            var especies = _listEspecieService.FindAll();
            var proprietarios = _listProprietarioService.FindAll();
            var animals = _listAnimalService.FindAll();
            var viewModel = new ExameFormViewModel { Animals = animals, Especies = especies, Proprietarios = proprietarios };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Exame exame)
        {
            caixa = new Caixa(exame.ValorExame, "Exame", exame.Id, exame.AnimalId, exame.ProprietarioId, "Entrada");
            if (!ModelState.IsValid)
            {
                return View(exame);
            }
            _exameService.Insert(exame);
            if (exame.Realizado)
            {
                InsertCaixa();
            }
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
                    caixa.Descricao = "Exame do animal " + listaDeAnimal[i].NomeAnimal + " ";
                }
            }

            for (int i = 0; i < listaProprietarios.Count; i++)
            {
                if (listaProprietarios[i].Id == caixa.ProprietarioId)
                {
                    caixa.Descricao = caixa.Descricao + " realizada pelo proprietário  " + listaProprietarios[i].NomeProprietario;
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

            var obj = _exameService.FindById(id.Value);
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
            _exameService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id Not Provided" });
            }

            var obj = _exameService.FindById(id.Value);
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
        public IActionResult Edit(int id, Exame exame)
        {
            if (id != exame.Id)
            {
                return BadRequest();
            }
            _exameService.Update(exame);
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