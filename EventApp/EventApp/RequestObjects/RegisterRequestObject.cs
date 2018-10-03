using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventApp.RequestObjects
{
    public class RegisterRequestObject
    {
        [Required, MinLength(4), MaxLength(15), Display(Name = "Användarnamn")]
        public string Username  { get; set; }

        [Required, EmailAddress(ErrorMessage = "Det måste vara en giltig mailadress"), DataType(DataType.EmailAddress), Display(Name = "Email")]
        public string Email { get; set; }

        [Required, MaxLength(250), Display(Name = "Beskrivning om dig själv")]
        public string Description { get; set; }

        [Required, DataType(DataType.Password), Display(Name = "Lösenord")]
        public string Password { get; set; }

        [Required, DataType(DataType.Password), Display(Name = "Skriv lösenord igen"), Compare("Password")]
        public string ConfirmPassword { get; set; }

    }
}
