using ClinicaVeterinaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Services.List
{
    public class ListMedicamentoService
    {

        private readonly ClinicaVeterinariaContext _context;

        public ListMedicamentoService(ClinicaVeterinariaContext context)
        {
            _context = context;
        }

        public List<Medicamento> FindAll()
        {
            return _context.Medicamentos.OrderBy(x => x.Valor).ToList();
        }
    }
}
