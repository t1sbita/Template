using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Claims;

namespace Template.Api.Security
{
    /// <summary>
    /// Filtro realizado nos request para identificar se o usuário tem a permissão necessária
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ClaimRequirementFilter : IAuthorizationFilter
    {
        readonly List<Claim> _claims;

        /// <summary>
        /// Construtor que recebe as claims do usuário logado
        /// </summary>
        /// <param name="claims">Claims do usuário logado</param>
        public ClaimRequirementFilter(List<Claim> claims)
        {
            _claims = claims;
        }


        /// <summary>
        /// Autorização para permitir ou não o request
        /// </summary>
        /// <param name="context"></param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var hasClaim = _claims.Any(x => context.HttpContext.User.Claims.Any(c => c.Type == x.Type && c.Value == x.Value));
            if (!hasClaim)
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
