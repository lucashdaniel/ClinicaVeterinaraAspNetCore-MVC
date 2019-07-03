using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;



namespace ClinicaVeterinaria.Models
{
    public class Cliente 
   
        
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="{0} Required")]
        [StringLength(60,MinimumLength = 3,ErrorMessage ="{0} size should be between {2} and {1}")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [EmailAddress(ErrorMessage ="Enter a valid email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [Display(Name ="Data Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        public string Celular { get; set; }

        [StringLength(11, MinimumLength = 11, ErrorMessage = "{0} size should be between {2} and {1}")]
        [Display(Name = "CPF")]
        [Required(ErrorMessage = "{0} Required")]
        public string CPF { get; set; }
               
        [Required(ErrorMessage = "{0} Required")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        public string Rua { get; set; }

        
        [Required(ErrorMessage = "{0} Required")]
        public int    Numero { get; set; }



        public Cliente()
        {

        }

        public Cliente(int id, string nome, string email, DateTime dataNascimento, string celular, string cPF, string estado, string cidade, string bairro, string rua, int numero)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            Celular = celular;
            CPF = cPF;
            Estado = estado;
            Cidade = cidade;
            Bairro = bairro;
            Rua = rua;
            Numero = numero;
        }



        public void AddClientes(Cliente cliente)
        {
            cliente.AddClientes(cliente); 
        }

        public void RemoveClientes(Cliente cliente)
        {
            cliente.RemoveClientes(cliente);
        }
    }
}
