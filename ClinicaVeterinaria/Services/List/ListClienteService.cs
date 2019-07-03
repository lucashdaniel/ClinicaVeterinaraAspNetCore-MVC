using ClinicaVeterinaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Services.List
{
    public class ListClienteService
    {
        private readonly ClinicaVeterinariaContext _context;

        public ListClienteService(ClinicaVeterinariaContext context)
        {
            _context = context;
        }

        public List<Cliente> FindAll()
        {
            return _context.Cliente.OrderBy(x => x.Nome).ToList();
        }
    }
}
