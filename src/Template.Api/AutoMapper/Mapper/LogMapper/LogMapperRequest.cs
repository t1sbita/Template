using AutoMapper;
using Template.Api.Core.Domain.Entities;
using Template.Api.Models.DTO;

namespace Template.Api.AutoMapper.Mapper.LogMapper
{
    /// <summary>
    /// LogMapperRequest
    /// </summary>
    public static class LogMapperRequest
    {
        /// <summary>
        /// LogMapperRequest.Map
        /// </summary>
        /// <param name="profile"></param>
        public static void Map(Profile profile)
        {
            if (profile != null)
                profile.CreateMap<LogDto, Log>();
        }
    }
}
