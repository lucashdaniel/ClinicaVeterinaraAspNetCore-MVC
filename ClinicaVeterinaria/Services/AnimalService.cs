using ClinicaVeterinaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicaVeterinaria.Services.Exception;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVeterinaria.Services
{
    public class AnimalService
    {
        private readonly ClinicaVeterinariaContext _context;

        public AnimalService(ClinicaVeterinariaContext context)
        {
            _context = context;
        }

        public async Task<List<Animal>> FindAllAsync()
        {
            return  await _context.Animal.Include(obj => obj.Especie).Include(obj => obj.Proprietario).ToListAsync();
        }

        public async Task<List<Animal>> Pesquisa(string searchString)
        {
            var lucas = from m in _context.Animal
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                lucas = lucas.Where(s => s.NomeAnimal.Contains(searchString)).
                    Include(s => s.Proprietario).           
                    Include(s => s.Especie);
            }

            return await lucas.Include(obj => obj.Especie).Include(obj => obj.Proprietario).ToListAsync();
        }


        public async Task  InsertAsync(Animal obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        


        public async Task<Animal> FindByIdAsync(int id)
        {
            return await _context.Animal.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Animal.FindAsync(id);
            _context.Animal.Remove(obj);
            await _context.SaveChangesAsync();
        }

      

        public async Task UpdateAsync(Animal obj)
        {
            bool hasAny = await _context.Animal.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new DllNotFoundException("Id not Found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch(DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
            
    }
}
