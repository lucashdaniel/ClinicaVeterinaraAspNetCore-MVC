using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicaVeterinaria.Models;
using ClinicaVeterinaria.Services;
using Microsoft.AspNetCore.Mvc;
using ClinicaVeterinaria.Services.Exception;
using ClinicaVeterinaria.Models.ViewModels;
using System.Diagnostics;
using ClinicaVeterinaria.Services.List;

namespace ClinicaVeterinaria.Controllers
{
    public class ConsultasController : Controller
    {
        private readonly ConsultaService _consultaService;
        private readonly ListVeterinarioService _listVeterinarioService;
        private readonly ListAnimalService _listAnimalService;
        private readonly ListProprietarioService _listProprietarioService;
        private readonly ListEspecieService _listEspecieService;
        private readonly ListMedicamentoService _listMedicamentoService;
        private readonly CaixaService _caixaService;
        public Caixa caixa = new Caixa();

        public ConsultasController(ConsultaService consultaService,
            ListVeterinarioService listVeterinarioService,
            ListAnimalService listAnimalService,
            ListProprietarioService listProprietarioService,
            ListMedicamentoService listMedicamentoService,
            ListEspecieService listEspecieService,
            CaixaService caixaService)
        {
            _consultaService = consultaService;
            _listVeterinarioService = listVeterinarioService;
            _listAnimalService = listAnimalService;
            _listProprietarioService = listProprietarioService;
            _listEspecieService = listEspecieService;
            _listMedicamentoService = listMedicamentoService;
            _caixaService = caixaService;
        }



        public async Task<IActionResult> Index(string buscaconsulta)
        {
            var list = await _consultaService.PesquisaConsulta(buscaconsulta);
            return View(list);
        }

        [HttpPost]
        public async Task<IActionResult> PesquisaConsulta(string buscaconsulta)
        {
            var list = await _consultaService.PesquisaConsulta(buscaconsulta);
            return View(list);

        }


        public IActionResult Create()
        {
            var medicamentos = _listMedicamentoService.FindAll();
            var especies = _listEspecieService.FindAll();
            var proprietarios = _listProprietarioService.FindAll();
            var animals = _listAnimalService.FindAll();
            var veterinarios = _listVeterinarioService.FindAll();
            var viewModel = new ConsultaFormViewModel { Veterinarios = veterinarios, Animal = animals, Especies = especies, Proprietarios = proprietarios, Medicamentos = medicamentos };
            return View(viewModel);
        }







        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Consulta consulta)
        {
            caixa = new Caixa(consulta.ValorConsulta, "Consulta", consulta.Id,consulta.AnimalId, consulta.ProprietarioId, "Entrada");
            if (!ModelState.IsValid)
            {
                return View(consulta);
            }

            await _consultaService.InsertAsync(consulta);

            if(consulta.pago)
            {
                InsertCaixa();
            }
            return RedirectToAction(nameof(Index));
        }

        public void InsertCaixa()
        {
            List<Animal> listaDeAnimal = _listAnimalService.FindAll();
            List<Proprietario> listaProprietarios = _listProprietarioService.FindAll();

            
            for (int i =0; i < listaDeAnimal.Count; i++)
            {
                if(listaDeAnimal[i].Id == caixa.AnimalId)
                {
                    caixa.Descricao = "Consulta do animal " + listaDeAnimal[i].NomeAnimal + " ";
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

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return View();
            }

            var obj = await _consultaService.FindByIdAsync(id.Value);
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
            await _consultaService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return View();
            }

            var obj = await _consultaService.FindByIdAsync(id.Value);
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

            var obj = await _consultaService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            List<Medicamento> medicamentos = _listMedicamentoService.FindAll();
            List<Veterinario> veterinarios = _listVeterinarioService.FindAll();
            List<Animal> animals = _listAnimalService.FindAll();
            List<Especie> especies = _listEspecieService.FindAll();
            List<Proprietario> proprietarios = _listProprietarioService.FindAll();
            ConsultaFormViewModel viewModel = new ConsultaFormViewModel { Consulta = obj, Proprietarios = proprietarios, Especies = especies, Animal = animals, Medicamentos = medicamentos, Veterinarios = veterinarios };
            return View(viewModel);



        }
    }
}



 