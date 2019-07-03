using ClinicaVeterinaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Services.List
{
    public class ListExameService
    {
        private readonly ClinicaVeterinariaContext _context;

        public ListExameService(ClinicaVeterinariaContext context)
        {
            _context = context;
        }

        public List<Exame> FindAll()
        {
            return _context.Exames.OrderBy(x => x.NomeDoExame).ToList();
        }
    }
}
