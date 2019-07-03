using System;
using System.Collections.Generic;


namespace ClinicaVeterinaria.Models.ViewModels
{
    public class AnimalFormViewModel
    {

        public Animal Animal { get; set; }
     
        public ICollection<Especie> Especies { get; set; }
       
        public ICollection<Proprietario> Proprietarios { get; set; }

    }
}
