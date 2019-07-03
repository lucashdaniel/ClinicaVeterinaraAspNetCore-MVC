using ClinicaVeterinaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Services.List
{
    public class ListEspecieService
    {
        private readonly ClinicaVeterinariaContext _context;

        public ListEspecieService(ClinicaVeterinariaContext context)
        {
            _context = context;
        }

        public List<Especie> FindAll()
        {
            return _context.Especies.OrderBy(x => x.NomeEspecie).ToList();
        }



    }
}
