using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicaVeterinaria.Models;

namespace ClinicaVeterinaria.Data
{
    public class SeedingService
    {
        private ClinicaVeterinariaContext _context;


        public SeedingService(ClinicaVeterinariaContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Cliente.Any() ||
                _context.Animal.Any() ||
                
                _context.Veterinarios.Any() ||
                _context.Consultas.Any() || 
                _context.Exames.Any())
               
            {
                return; // DB ja foi populado
            }

            Cliente c1 = new Cliente(1, "Lucas Horn Daniel", "lucashorndaniel@hotmail.com", new DateTime (1996,03,4), "429938-8163", "05053869928", "Parana", "Medianeira", "Jardim Irene", "Rua 14", 475);



           

            

            Veterinario v1 = new Veterinario(1, "23" , "Jose Augusto", "joseaugusto@gmail.com", "4599388163", 1111);

            

            


            _context.Cliente.AddRange(c1);

            

            _context.Veterinarios.AddRange(v1);

            

           


            _context.SaveChanges();





        }

    }
}
