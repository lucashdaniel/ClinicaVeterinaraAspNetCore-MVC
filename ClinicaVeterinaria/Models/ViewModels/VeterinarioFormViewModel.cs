using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Models.ViewModels
{
    public class VeterinarioFormViewModel
    {
        public Veterinario Veterinario { get; set; }

        public ICollection<Veterinario> Veterinarios { get; set; }
    }
}
