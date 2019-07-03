using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Models
{
    public class Animal
    {
        

        public int Id { get; set; }

        [Required(ErrorMessage ="{0} Required")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "{0} size should be between {2} and {1}")]
        public string NomeAnimal { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        public int Idade { get; set; }

        [StringLength(60, MinimumLength = 2, ErrorMessage = "{0} size should be between {2} and {1}")]
        [Display(Name = "Raça do seu animal")]
        public string DescricaoEspecie { get; set; }

        [StringLength(1, MinimumLength = 1, ErrorMessage = "{0} size should be between {2} and {1}")]
        [Display(Name = "M(macho),F(femea)")]
        public string Sexo { get; set; }

        
        public int EspecieId { get; set; }

        [Display(Name = "Quilo(KG)")]
        [Required(ErrorMessage = "{0} Required")]
        public float Peso { get; set; }

        [Display(Name = "Centimetros")]
        [Required(ErrorMessage = "{0} Required")]
        public string Altura { get; set; }

        
        
        public  int ProprietarioId { get; set; }

        public virtual Especie Especie { get; set; }

        public virtual Proprietario Proprietario { get; set; }

         



        public virtual ICollection<Consulta> Consultas { get; set; }

        
        
        

        

        

        public Animal()
        {

        }
        
    
        public Animal(int id, string nomeAnimal, int idade, string descricaoEspecie, string sexo, int especieId, float peso, string altura, int proprietarioId, Especie especie, Proprietario proprietario)
        {
            Id = id;
            NomeAnimal = nomeAnimal;
            Idade = idade;
            DescricaoEspecie = descricaoEspecie;
            Sexo = sexo;
            EspecieId = especieId;
            Peso = peso;
            Altura = altura;
            ProprietarioId = proprietarioId;
            Especie = especie;
            Proprietario = proprietario;
        }

        public void AddAnimal(Animal animal)
        {
            animal.AddAnimal(animal);
        }

        public void RemoveAnimal(Animal animal)
        {
            animal.RemoveAnimal(animal);
        }

       
        
            
        
            
        


    }
}

