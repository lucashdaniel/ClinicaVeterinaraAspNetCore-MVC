using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Models.ViewModels
{
    public class ConsultaFormViewModel
    {
        public Consulta Consulta { get; set; }

        public ICollection<Proprietario> Proprietarios { get; set; }

        public ICollection<Animal> Animal { get; set; }

        public ICollection<Veterinario> Veterinarios { get; set; }

        public ICollection<Especie> Especies { get; set; }

        public ICollection<Medicamento> Medicamentos { get; set; }
       
        

    }
}
