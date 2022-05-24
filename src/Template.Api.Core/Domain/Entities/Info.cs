using Template.Api.Core.Domain.Entities.Base;

namespace Template.Api.Core.Domain.Entities
{
    public class Info : BaseEntity
    {
        public string Version { get; set; }
        public string Banner { get; set; }
    }
}
