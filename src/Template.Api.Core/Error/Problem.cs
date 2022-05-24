using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace Template.Api.Core.Error
{
    [ExcludeFromCodeCoverage]
    public class Problem
    {
        public int Status { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public string Instance { get; set; }
        public string Method { get; set; }
        public string TraceId { get; set; }

        public List<ErrorField> Erros { get; set; } = new List<ErrorField>();

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
