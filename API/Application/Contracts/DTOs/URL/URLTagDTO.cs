using API.Application.Contracts.DTOs.Tag;

namespace API.Application.Contracts.DTOs.URL
{
    public class URLTagDTO
    {
        public virtual Guid? Id { get; set; }
        public virtual Guid? UrlId { get; set; }
        public virtual Guid? TagId { get; set; }
        public virtual TagDTO? Tags { get; set; }
    }
}
