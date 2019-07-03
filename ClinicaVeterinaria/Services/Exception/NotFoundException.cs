using System;


namespace ClinicaVeterinaria.Services.Exception
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string message) : base(message)
        {

        }


    }
}
