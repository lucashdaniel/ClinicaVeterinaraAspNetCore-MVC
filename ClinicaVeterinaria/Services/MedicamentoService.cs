using ClinicaVeterinaria.Models;
using ClinicaVeterinaria.Services.Exception;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Services
{
    public class MedicamentoService
    {

        private readonly ClinicaVeterinariaContext _context;

        public MedicamentoService(ClinicaVeterinariaContext context)
        {
            _context = context;
        }


        public async Task<List<Medicamento>> FindAllAsync()
        {
            return await _context.Medicamentos.Include(obj => obj.Animal).Include(obj=>obj.Proprietario).ToListAsync();

        }


        public void Insert(Medicamento obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Medicamento FindById(int id)
        {
            return _context.Medicamentos.FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Medicamentos.Find(id);
            _context.Medicamentos.Remove(obj);
            _context.SaveChanges();
        }

        public async Task UpdateAsync(Medicamento obj)
        {
            bool hasAny = await _context.Medicamentos.AnyAsync(x => x.Id == obj.Id);
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
