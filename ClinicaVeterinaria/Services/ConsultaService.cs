using ClinicaVeterinaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClinicaVeterinaria.Services.Exception;


namespace ClinicaVeterinaria.Services
{
    public class ConsultaService
    {
        private readonly ClinicaVeterinariaContext _context;
        
        public ConsultaService(ClinicaVeterinariaContext context)
        {
            _context = context;
        }

        public async Task<List<Consulta>> FindAllAsync()
        {
            return await _context.Consultas
                .Include(obj => obj.Animal)
                .Include(obj => obj.Proprietario)
                .Include(obj => obj.Veterinario)
                .Include(obj => obj.Medicamento)
                .Include(obj=>obj.Especies).ToListAsync();
            
        }

        public async Task<List<Consulta>> PesquisaConsulta(string searchString)
        {
            var consulta = from m in _context.Consultas
                        select m;

            

            if (!String.IsNullOrEmpty(searchString))
            {
                
                consulta = consulta.Where(s => s.Sintomas.Contains(searchString))
                    .Include(s => s.Animal)
                    .Include(s => s.Proprietario);
                    
            }

            return await consulta.Include(obj => obj.Animal).Include(obj => obj.Proprietario).Include(obj=>obj.Especies).Include(obj=>obj.Veterinario).Include(obj => obj.Medicamento).ToListAsync();
        }




        public async Task InsertAsync(Consulta obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Consulta> FindByIdAsync(int id)
        {
            return await _context.Consultas.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Consultas.FindAsync(id);
            _context.Consultas.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public void Update(Consulta obj)
        {
            if(!_context.Consultas.Any(x =>x.Id == obj.Id))
            {
                throw new NotFoundException("Id not Found");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }


    }
}
