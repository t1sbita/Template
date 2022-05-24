using AutoMapper;
using Template.Api.Core.Domain.Entities;
using Template.Api.Models.ViewModels;

namespace Template.Api.AutoMapper.Mapper.InfoMapper
{
    /// <summary>
    /// InfoMapperResponse
    /// /// </summary>
    public static class InfoMapperResponse
    {
        /// <summary>
        /// InfoMapperResponse.Map
        /// </summary>
        /// <param name="profile"></param>
        public static void Map(Profile profile)
        {
            if (profile != null)
            {
                profile.CreateMap<Info, InfoViewModel>().IgnoreAllNonExisting();
            }
        }
    }
}