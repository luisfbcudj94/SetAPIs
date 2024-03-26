using API.Application.Contracts.DTOs.Tag;

namespace API.Application.Contracts.DTOs.Body
{
    public class BodyTagDTO
    {
        public virtual Guid? Id { get; set; }
        public virtual Guid? BodyId { get; set; }
        public virtual Guid? TagId { get; set; }
        public virtual TagDTO? Tag { get; set; }
    }
}
