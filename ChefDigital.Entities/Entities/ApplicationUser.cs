using ChefDigital.Entities.Enums;
using Microsoft.AspNetCore.Identity;

namespace ChefDigital.Entities.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string CPF { get; set; }
        public TipoUsuario? Tipo { get; set; }
    }
}
