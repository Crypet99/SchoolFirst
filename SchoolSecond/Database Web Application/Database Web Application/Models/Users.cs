using System.ComponentModel.DataAnnotations;

namespace Database_Web_Application.Models
{
    public class Users
    {
        [Required(ErrorMessage = "Feld nicht leer sein")]
        public string? Username { get; set; }
        [Required(ErrorMessage ="Feld darf nicht leer sein")]
        public string? Password { get; set; }
       

    }
}
