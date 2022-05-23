using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Login_mvc_entity_framework.Models
{
    public class Usuario:IdentityUser 
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
