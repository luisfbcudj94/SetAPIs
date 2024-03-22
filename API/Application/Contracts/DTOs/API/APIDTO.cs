namespace API.Application.Contracts.DTOs.API
{
    public class APIDTO
    {
        public virtual Guid? Id { get; set; }
        public virtual Guid ApiTypeId { get; set; }
        public virtual string Name { get; set; }
    }
}
