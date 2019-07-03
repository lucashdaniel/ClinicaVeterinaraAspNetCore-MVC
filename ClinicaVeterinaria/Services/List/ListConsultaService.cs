using ClinicaVeterinaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Services.List
{
    public class ListConsultaService
    {

        private readonly ClinicaVeterinariaContext _context;

        public ListConsultaService(ClinicaVeterinariaContext context)
        {
            _context = context;
        }

        public List<Consulta> FindAll()
        {
            return _context.Consultas.OrderBy(x => x.DataConsulta).ToList();
        }
    }
}

