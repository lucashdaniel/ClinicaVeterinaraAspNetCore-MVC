using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Models.ViewModels
{
    public class ProprietarioFormViewModel
    {
        
        public Proprietario Proprietario { get; set; }

        public ICollection<Proprietario> Proprietarios { get; set; }

       

        

    }
}
    

