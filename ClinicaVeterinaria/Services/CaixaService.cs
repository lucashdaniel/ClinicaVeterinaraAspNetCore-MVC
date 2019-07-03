using ClinicaVeterinaria.Models;
using ClinicaVeterinaria.Services.Exception;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Services
{
    public class CaixaService
    {

        private readonly ClinicaVeterinariaContext _context;
        

        public CaixaService(ClinicaVeterinariaContext context)
        {
            _context = context;
        }


        public async Task<List<Caixa>> FindAllAsync()
        {
            return await _context.Caixas.Include(obj => obj.Consultas).Include(obj => obj.Exames).Include(obj => obj.Animals).Include(obj=> obj.Proprietarios).ToListAsync();

        }


        public void Insert(Caixa obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Caixa FindById(int id)
        {
            return _context.Caixas.FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Caixas.Find(id);
            _context.Caixas.Remove(obj);
            _context.SaveChanges();
        }

        public async Task UpdateAsync(Caixa obj)
        {
            bool hasAny = await _context.Caixas.AnyAsync(x => x.Id == obj.Id);
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
    

