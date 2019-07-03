using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Models.ViewModels
{
    public class MedicamentoFormViewModel
    {
        public Medicamento Medicamento { get; set; }

        public ICollection <Animal> Animals { get; set; }

        public ICollection <Proprietario> Proprietarios { get; set; }
    }
}
