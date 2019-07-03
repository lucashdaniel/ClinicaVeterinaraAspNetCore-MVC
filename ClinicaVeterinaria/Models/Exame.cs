using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Models
{
    public class Exame
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        public string NomeDoExame { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        public int AnimalId { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        public int ProprietarioId { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        public int EspecieId { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        public double ValorExame { get; set; }

        public bool Realizado { get; set; }

        public virtual Especie Especie { get; set; }

        public virtual Animal Animal { get; set; }

        public virtual Proprietario Proprietario { get; set; }
     
        public Exame()
        {

        }

        public Exame(int id, string nomeDoExame, int animalId, int proprietarioId, int especieId, double valorExame, bool realizado)
        {
            Id = id;
            NomeDoExame = nomeDoExame;
            AnimalId = animalId;
            ProprietarioId = proprietarioId;
            EspecieId = especieId;
            ValorExame = valorExame;
            Realizado = realizado;
        }
    }


}
