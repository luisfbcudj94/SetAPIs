namespace API.Application.Contracts.DTOs.Configuration
{
    public class ConfigurationDTO
    {
        public virtual Guid? Id { get; set; }
        public virtual Guid ApiId { get; set; }
        public virtual Guid BodyId { get; set; }
        public virtual Guid UrlId { get; set; }
    }
}
