namespace API.Application.Contracts.DTOs.Body
{
    public class BodyDTO
    {
        public virtual Guid? Id { get; set; }
        public virtual string Value { get; set; }
        public virtual ICollection<BodyTagDTO>? BodyTag { get; set; }
    }
}
