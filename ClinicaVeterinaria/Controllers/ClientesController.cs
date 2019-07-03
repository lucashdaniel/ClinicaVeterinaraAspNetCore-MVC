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

namespace ClinicaVeterinaria.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ClienteService _clienteService;
        
        public ClientesController(ClienteService clienteService)
        {
            _clienteService = clienteService;
            
        }


        public async Task< IActionResult> Index(string busca)
        {

            var list = await _clienteService.PesquisaCliente(busca);
            return View(list);
        }

        [HttpPost]
        public async Task<IActionResult> PesquisaCliente(string busca)
        {
            var list = await _clienteService.PesquisaCliente(busca);

            return View(list);
        }


        public IActionResult Create()
        {
            
           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return View(cliente);
            }
            _clienteService.Insert(cliente);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error),new { message = "Id Not Found" });
            }

            var obj = _clienteService.FindById(id.Value);
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
            _clienteService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id Not Provided" });
            }

            var obj = _clienteService.FindById(id.Value);
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
        public async Task<IActionResult> EditAsync(int id, Cliente cliente)
        {
            if(id != cliente.Id)
            {
                return BadRequest();
            }
            await _clienteService.UpdateAsync(cliente);
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






       