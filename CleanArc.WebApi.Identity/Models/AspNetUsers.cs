using Microsoft.AspNetCore.Identity;

namespace CleanArc.WebApi.Identity.Models
{
    public class AspNetUsers : IdentityUser
    {
        public int TipoUsuario { get; set; }
        public byte[]? Imagem { get; set; }

    }
}
