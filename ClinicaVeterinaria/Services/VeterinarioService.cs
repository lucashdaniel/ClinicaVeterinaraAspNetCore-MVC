using ClinicaVeterinaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClinicaVeterinaria.Services.Exception;


namespace ClinicaVeterinaria.Services
{
    public class VeterinarioService
    {
        private readonly ClinicaVeterinariaContext _context;
        public VeterinarioService(ClinicaVeterinariaContext context)
        {
            _context = context;
        }

        public List<Veterinario> FindAll()
        {
            return _context.Veterinarios.ToList();
        }

        public void Insert(Veterinario obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Veterinario FindById(int id)
        {
            return _context.Veterinarios.FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Veterinarios.Find(id);
            _context.Veterinarios.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Veterinario obj)
        {
            if(!_context.Veterinarios.Any(x=>x.Id == obj.Id))
            {
                throw new DllNotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }
    }
}
