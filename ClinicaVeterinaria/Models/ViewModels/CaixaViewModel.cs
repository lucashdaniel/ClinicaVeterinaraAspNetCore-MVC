using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Models.ViewModels
{
    public class CaixaViewModel
    {
        public Caixa Caixa { get; set; }

        public ICollection<Consulta> Consultas { get; set; }

        public ICollection<Exame> Exames { get; set; }

        public ICollection<Animal> Animals { get; set; }

        public ICollection<Proprietario> Proprietarios { get; set; }


    }
}
