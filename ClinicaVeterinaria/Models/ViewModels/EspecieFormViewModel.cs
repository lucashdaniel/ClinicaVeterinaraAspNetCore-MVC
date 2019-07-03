using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Models.ViewModels
{
    public class EspecieFormViewModel
    {
        public Especie Especie { get; set; }

        public ICollection<Animal> Animals { get; set; }

    }
}
