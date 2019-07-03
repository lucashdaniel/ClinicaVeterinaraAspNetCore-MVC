using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Models
{
    public class Consulta
    {
        public int Id { get; set; }

       
        public int EspecieId { get; set; }

        
        public int ProprietarioId { get; set; }

        
        public int AnimalId { get; set; }

        public double ValorConsulta { get; set; }

        public bool pago { get; set; }
        
        public string Sintomas { get; set; }

        
        public int VeterinarioId { get; set; }

        
        public int MedicamentoId { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime DataConsulta { get; set; }

        public ICollection<Veterinario> Veterinarios { get; set; } = new List<Veterinario>();

        public ICollection<Proprietario> Proprietarios { get; set; } = new List<Proprietario>();

        public virtual Animal Animal { get; set; }

        public virtual Proprietario Proprietario { get; set; }

        public virtual Especie Especies { get; set; }

        public virtual Veterinario Veterinario { get; set; }

        public virtual Medicamento Medicamento { get; set; }

       


        public Consulta()
        {

        }

        public Consulta(int id, int especieId, int proprietarioId, int animalId, double valorConsulta, bool pago, string sintomas, int veterinarioId, int medicamentoId, DateTime dataConsulta, ICollection<Veterinario> veterinarios, ICollection<Proprietario> proprietarios)
        {
            Id = id;
            EspecieId = especieId;
            ProprietarioId = proprietarioId;
            AnimalId = animalId;
            ValorConsulta = valorConsulta;
            this.pago = pago;
            Sintomas = sintomas;
            VeterinarioId = veterinarioId;
            MedicamentoId = medicamentoId;
            DataConsulta = dataConsulta;
            Veterinarios = veterinarios;
            Proprietarios = proprietarios;
        }
       
    }
    }

