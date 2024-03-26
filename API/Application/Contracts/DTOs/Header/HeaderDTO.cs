namespace API.Application.Contracts.DTOs.Header
{
    public class HeaderDTO
    {
        public virtual Guid? Id { get; set; }
        public virtual Guid? ConfigurationId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Value { get; set; }
        public virtual ICollection<HeaderTagDTO>? HeaderTag { get; set; }
    }
}
