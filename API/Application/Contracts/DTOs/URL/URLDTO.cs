using API.Application.Contracts.DTOs.HTTPMethod;

namespace API.Application.Contracts.DTOs.URL
{
    public class URLDTO
    {
        public virtual Guid? Id { get; set; }
        public virtual Guid? HTTPMethodId { get; set; }
        public virtual string? Value { get; set; }
        public virtual ICollection<URLTagDTO>? URLTag { get; set; }
        public virtual HTTPMethodDTO? HttpMethods { get; set; }
    }
}
