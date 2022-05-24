using Microsoft.AspNetCore.Authorization;

namespace Template.Api.Security
{
    /// <summary>
    /// AuthorizeProfilesAttribute
    /// Resumo:
    /// Atributo utilizado na autorização.
    /// </summary>
    public class AuthorizeProfilesAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// Construtor sem parâmetros.
        /// É setado o perfil Administrador
        /// </summary>
        public AuthorizeProfilesAttribute()
        {
            base.Roles = UserProfile.Administrator;
        }
        /// <summary>
        /// Construtor com parâmetros.
        /// É setado os perfis passados
        /// </summary>
        public AuthorizeProfilesAttribute(params string[] roles) : this()
        {
            if (roles.Length > 0)
            {
                base.Roles += "," + string.Join(',', roles);
            }
        }
    }
}
