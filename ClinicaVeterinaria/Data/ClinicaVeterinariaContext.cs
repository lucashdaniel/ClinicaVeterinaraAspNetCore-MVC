using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClinicaVeterinaria.Models;


namespace ClinicaVeterinaria.Models
{
    public class ClinicaVeterinariaContext : DbContext
    {
        public ClinicaVeterinariaContext(DbContextOptions<ClinicaVeterinariaContext> options)
            : base(options)
        {
        }

        public DbSet<ClinicaVeterinaria.Models.Especie> Especies { get; set; }

        public DbSet<ClinicaVeterinaria.Models.Animal> Animal { get; set; }

        public DbSet<ClinicaVeterinaria.Models.Cliente> Cliente { get; set; }

        public DbSet<ClinicaVeterinaria.Models.Veterinario> Veterinarios { get; set; }

        public DbSet<ClinicaVeterinaria.Models.Consulta> Consultas { get; set; }

        public DbSet<ClinicaVeterinaria.Models.Exame> Exames { get; set; }

        public DbSet<ClinicaVeterinaria.Models.Proprietario> Proprietarios { get; set; }

        public DbSet<ClinicaVeterinaria.Models.Medicamento> Medicamentos { get; set; }

        public DbSet<ClinicaVeterinaria.Models.Caixa> Caixas { get; set; }

        
        

        

        

       

       

        
    }
}
