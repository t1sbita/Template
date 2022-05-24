using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Template.Api.Core.Domain.Entities;
using Template.Api.Security;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace Template.Api.Controller
{

    /// <summary>
    /// BaseController
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [ApiController]
    [ExcludeFromCodeCoverage]
    public class BaseController<T> : ControllerBase
    {
        #region Identity
        /// <summary>
        /// 
        /// </summary>
        protected IIdentity LoggedInUser => User.Identity;


        /// <summary>
        /// BaseController.UserProfiles
        /// </summary>
        protected List<string> UserProfiles => ClaimTypes.Role == null || User == null ? null : User.FindAll(ClaimTypes.Role).Select(c => c.Value).ToList();

        #endregion

        /// <summary>
        /// BaseController.accessor
        /// </summary>
        protected IHttpContextAccessor Accessor { get; private set; }

        /// <summary>
        /// BaseController.logger
        /// </summary>
        protected ILogger<T> Logger { get; private set; }

        /// <summary>
        /// BaseController.mapper
        /// </summary>
        protected IMapper Mapper { get; private set; }

        /// <summary>
        /// BaseController (Constructor)
        /// </summary>
        /// <param name="accessor"></param>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        public BaseController(IHttpContextAccessor accessor, ILogger<T> logger, IMapper mapper)
        {
            this.Accessor = accessor;
            this.Logger = logger;
            this.Mapper = mapper;
        }

       
    }
}