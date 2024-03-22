namespace API.Domain.Models
{
    public class Body
    {
        public virtual Guid Id { get; set; }
        public virtual string Value { get; set; }
        public virtual ICollection<BodyTag> BodyTag { get; set; }
    }
}
