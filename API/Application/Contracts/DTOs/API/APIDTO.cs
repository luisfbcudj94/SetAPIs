using API.Application.Contracts.DTOs.Configuration;

namespace API.Application.Contracts.DTOs.API
{
    public class APIDTO
    {
        public virtual Guid? Id { get; set; }
        public virtual Guid? ApiTypeId { get; set; }
        public virtual string Name { get; set; }
        public virtual APITypeDTO? APIType { get; set; }
        public virtual ConfigurationDTO? Configuration { get; set; }
    }
}
