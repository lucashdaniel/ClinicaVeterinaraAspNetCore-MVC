using ClinicaVeterinaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Services.List
{
    public class ListAnimalService
    {
        private readonly ClinicaVeterinariaContext _context;

        public ListAnimalService(ClinicaVeterinariaContext context)
        {
            _context = context;
        }

        public List<Animal> FindAll()
        {
            return _context.Animal.OrderBy(s => s.NomeAnimal).ToList();
        }
    }
}
 
