using ClinicaVeterinaria.Models;
using ClinicaVeterinaria.Services.Exception;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Services
{
    public class EspecieService
    {
        private readonly ClinicaVeterinariaContext _context;

        public EspecieService(ClinicaVeterinariaContext context)
        {
            _context = context;
        }

        public async Task<List<Especie>> FindAllAsync()
        {
            return await _context.Especies.ToListAsync();
        }

        public async Task InsertAsync(Especie obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Especie> FindByIdAsync(int id)
        {
            return await _context.Especies.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Especies.FindAsync(id);
            _context.Especies.Remove(obj);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateAsync(Especie obj)
        {
            bool hasAny = await _context.Especies.AnyAsync(x => x.Id == obj.Id);
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
