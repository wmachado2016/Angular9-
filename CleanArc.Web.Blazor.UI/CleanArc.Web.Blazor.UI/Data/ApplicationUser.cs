using Microsoft.AspNetCore.Identity;

namespace CleanArc.Web.Blazor.UI.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public int TipoUsuario { get; set; }
        public byte[]? Imagem { get; set; }
    }

}
