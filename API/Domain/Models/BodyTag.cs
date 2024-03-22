namespace API.Domain.Models
{
    public class BodyTag
    {
        public virtual Guid Id { get; set; }
        public virtual Guid BodyId { get; set; }
        public virtual Guid TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
