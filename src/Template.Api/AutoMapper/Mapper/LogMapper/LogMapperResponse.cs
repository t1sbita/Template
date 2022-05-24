using AutoMapper;
using Template.Api.Core.Domain.Entities;
using Template.Api.Models.ViewModels;

namespace Template.Api.AutoMapper.Mapper.LogMapper
{
    /// <summary>
    /// LogMapperResponse
    /// </summary>
    public static class LogMapperResponse
    {
        /// <summary>
        /// LogMapperResponse.Map
        /// </summary>
        /// <param name="profile"></param>
        public static void Map(Profile profile)
        {
            if (profile != null)
                profile.CreateMap<Log, LogViewModel>();
        }
    }
}
