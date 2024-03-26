using API.Application.Contracts.DTOs.Body;
using API.Application.Contracts.DTOs.Header;
using API.Application.Contracts.DTOs.URL;

namespace API.Application.Contracts.DTOs.Configuration
{
    public class ConfigurationDTO
    {
        public virtual Guid? Id { get; set; }
        public virtual Guid? ApiId { get; set; }
        public virtual Guid? BodyId { get; set; }
        public virtual Guid? UrlId { get; set; }
        public virtual URLDTO? URL { get; set; }
        public virtual BodyDTO? Body { get; set; }
        public virtual ICollection<HeaderDTO>? Header { get; set; }
    }
}
