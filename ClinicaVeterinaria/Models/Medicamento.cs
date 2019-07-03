using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Models
{
    public class Medicamento
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 2, ErrorMessage = "{0} size should be between {2} and {1}")]
        public string NomeMedicamento { get; set; }

        [StringLength(120, MinimumLength = 2, ErrorMessage = "{0} size should be between {2} and {1}")]        
        public string DescricaoMedicamento { get; set; }

        public int AnimalId { get; set; }

        public int ProprietarioId { get; set; }

        public virtual Animal Animal { get; set; }

        public virtual Proprietario Proprietario { get;set; }

        
        public double Valor { get; set; }


        public Medicamento()
        {

        }

        public Medicamento(int id, string nomeMedicamento, string descricaoMedicamento, double valor)
        {
            Id = id;
            NomeMedicamento = nomeMedicamento;
            DescricaoMedicamento = descricaoMedicamento;
            Valor = valor;
        }
    }
}
