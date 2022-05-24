using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace Template.Api.Security
{
    /// <summary>
    /// Utilizado para identificar as claims do usuário
    /// </summary>
    public class ClaimRequirementAttribute : TypeFilterAttribute
    {
        /// <summary>
        /// Guarda os valores das claims 
        /// </summary>
        /// <param name="claimType">Tipo da Claim</param>
        /// <param name="claimValue">Valor da Claim</param>
        public ClaimRequirementAttribute(string claimType, string[] claimValue) : base(typeof(ClaimRequirementFilter))
        {
            Arguments = new object[] { claimValue.Select(c => new Claim(claimType, c)).ToList() };
        }
    }
}
