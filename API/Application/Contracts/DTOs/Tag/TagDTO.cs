namespace API.Application.Contracts.DTOs.Tag
{
    public class TagDTO
    {
        public virtual Guid? Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Value { get; set; }
    }
}
