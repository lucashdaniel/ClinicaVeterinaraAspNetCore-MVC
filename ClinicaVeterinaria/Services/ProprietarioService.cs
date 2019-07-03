using ClinicaVeterinaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicaVeterinaria.Services.Exception;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVeterinaria.Services
{
    public class ProprietarioService
    {
        private readonly ClinicaVeterinariaContext _context;
        public ProprietarioService(ClinicaVeterinariaContext context)

        
        {
            _context = context;
        }

        public async Task<List<Proprietario>> FindAllAsync()
        {
            return await _context.Proprietarios.ToListAsync();
        }

        public async Task InsertAsync(Proprietario obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Proprietario> FindByIdAsync(int id)
        {
            return await _context.Proprietarios.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Proprietarios.FindAsync(id);
            _context.Proprietarios.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Proprietario obj)
        {
            bool hasAny = await _context.Proprietarios.AnyAsync(x => x.Id == obj.Id);
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
