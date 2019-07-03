using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Models
{
    public class Historico
    {
        public int Id { get; set; }

        public int AnimalId { get; set; }


        public virtual Animal Animal { get; set; }


        public Historico()
        {

        }

        public Historico(int id, int animalId)
        {
            Id = id;
            AnimalId = animalId;
        }
    }
}

        
