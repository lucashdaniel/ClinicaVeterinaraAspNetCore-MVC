using ClinicaVeterinaria.Models;
using ClinicaVeterinaria.Services.Exception;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Services
{
    public class ExameService
    {
        private readonly ClinicaVeterinariaContext _context;

        public ExameService(ClinicaVeterinariaContext context)
        {
            _context = context;
        }


        public async Task<List<Exame>> FindAllAsync()
        {
            return await _context.Exames.Include(obj => obj.Animal).Include(obj => obj.Proprietario).Include(obj => obj.Especie).ToListAsync();

        }


        public void Insert(Exame obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Exame FindById(int id)
        {
            return _context.Exames.FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Exames.Find(id);
            _context.Exames.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Exame obj)
        {
            if (!_context.Exames.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
