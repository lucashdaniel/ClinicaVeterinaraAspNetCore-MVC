using ClinicaVeterinaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Services
{
    public class ListVeterinarioService
    {
        private readonly ClinicaVeterinariaContext _context;

        public ListVeterinarioService(ClinicaVeterinariaContext context)
        {
            _context = context;
        }

        public List<Veterinario> FindAll()
        {
            return _context.Veterinarios.OrderBy(x => x.Nome).ToList();
        }
    }
}
