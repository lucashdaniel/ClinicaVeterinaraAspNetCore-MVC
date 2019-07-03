using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ClinicaVeterinaria.Models
{
    public class Veterinario
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        public string Celular { get; set; }

        

        [Required(ErrorMessage = "{0} Required")]
        public int Registro { get; set; }


        

        
        public Veterinario()
        {

        }

        public Veterinario(int id, string cPF, string nome, string email, string celular, int registro)
        {
            Id = id;
            CPF = cPF;
            Nome = nome;
            Email = email;
            Celular = celular;
            Registro = registro;
        }
    }
}
