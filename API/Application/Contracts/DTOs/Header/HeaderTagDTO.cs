using API.Application.Contracts.DTOs.Tag;

namespace API.Application.Contracts.DTOs.Header
{
    public class HeaderTagDTO
    {
        public virtual Guid? Id { get; set; }
        public virtual Guid? HeaderId { get; set; }
        public virtual Guid? TagId { get; set; }
        public virtual TagDTO? Tags { get; set; }
    }
}
