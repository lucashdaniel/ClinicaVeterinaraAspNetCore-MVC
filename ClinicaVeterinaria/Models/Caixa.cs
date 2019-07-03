using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Models
{
    public class Caixa
    {

        public int Id { get; set; }

        public double Valor { get; set; }

        public string Descricao { get; set; }

        public int ConsultaId { get; set; }

        public int AnimalId { get; set; }

        public int ProprietarioId { get; set; }

        public string Tipo { get; set; }

        public virtual Proprietario Proprietario { get; set; }


        public virtual ICollection<Consulta> Consultas { get; set; }

        public virtual ICollection<Exame> Exames { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }

        public virtual ICollection<Proprietario> Proprietarios { get; set; }



        public Caixa()
        {

        }

        public Caixa(int id, double valor, string descricao, int consultaId, int animalId, int proprietarioId, string tipo)
        {
            Id = id;
            Valor = valor;
            Descricao = descricao;
            ConsultaId = consultaId;
            AnimalId = animalId;
            ProprietarioId = proprietarioId;
            Tipo = tipo;
        }

        public Caixa(double valor, string descricao, int consultaId, int animalId, int proprietarioId, string tipo)
        {
            Valor = valor;
            Descricao = descricao;
            ConsultaId = consultaId;
            AnimalId = animalId;
            ProprietarioId = proprietarioId;
            Tipo = tipo;
        }


        public double EntradaCaixa()
        {
            return Consultas.Sum(consulta => consulta.ValorConsulta);
        }
       


    }


    

}
