using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Models
{
    public class Proprietario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        public string NomeProprietario { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        public string Telefone { get; set; }

        [EmailAddress(ErrorMessage = "Enter a valid email")]
        [Required(ErrorMessage = "{0} Required")]
        public string Email { get; set; }

        public ICollection<Animal> Animals { get; set; } = new List<Animal>();
        
        
        
        

        
       
        
    
        

        public Proprietario()
        {

        }

        public Proprietario(int id, string nomeProprietario, string telefone, string email)
        {
            Id = id;
            NomeProprietario = nomeProprietario;
            Telefone = telefone;
            Email = email;
        }
    }
}
