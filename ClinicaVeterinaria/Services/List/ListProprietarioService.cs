using ClinicaVeterinaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Services.List
{
    public class ListProprietarioService
    {
        private readonly ClinicaVeterinariaContext _context;

        public ListProprietarioService(ClinicaVeterinariaContext context)
        {
            _context = context;
        }

        public List<Proprietario> FindAll()
        {
            return _context.Proprietarios.OrderBy(x => x.NomeProprietario).ToList();
        }
    }
}


    