using ClinicaVeterinaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClinicaVeterinaria.Services.Exception;

namespace ClinicaVeterinaria.Services
{
    public class ClienteService
    {
        private readonly ClinicaVeterinariaContext _context; 

        public ClienteService(ClinicaVeterinariaContext context)
        {
            _context = context;
        }


        public async Task<List<Cliente>> FindAllAsync()
        {
            return await _context.Cliente.ToListAsync();

        }

        public async Task<List<Cliente>> PesquisaCliente(string searchString)
        {
            var lucas = from m in _context.Cliente
                        select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                lucas = lucas.Where(s => s.Nome.Contains(searchString));
                   
            }

            return await lucas.ToListAsync();
        }



        public void Insert(Cliente obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Cliente FindById(int id)
        {
            return _context.Cliente.FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Cliente.Find(id);
            _context.Cliente.Remove(obj);
            _context.SaveChanges();
        }

        public async Task UpdateAsync(Cliente obj)
        {
            bool hasAny = await _context.Cliente.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new DllNotFoundException("Id not Found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    } 
}
