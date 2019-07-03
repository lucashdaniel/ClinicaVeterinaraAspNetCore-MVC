using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Models
{
    public class Especie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        public string NomeEspecie { get; set; }

           

        public Especie()
        {

        }

        public Especie(int id, string nomeEspecie)
        {
            Id = id;
            NomeEspecie = nomeEspecie;
            
        }
    }

    


}
