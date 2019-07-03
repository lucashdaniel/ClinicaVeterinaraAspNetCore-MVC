using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Models.ViewModels
{
    public class ClienteFormViewModel
    {

        public Cliente Cliente { get; set; }

        ICollection<Cliente> Clientes { get; set; }
        
    }
}
