using API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Persistence.Seeds
{
    public class APITypeSeed : IEntityTypeConfiguration<APIType>
    {
        public void Configure(EntityTypeBuilder<APIType> builder)
        {
            builder.HasData(
                new APIType { Id = new Guid("62ffbd2a-30f3-4e8e-bb8e-774a7d95e924"), Name = "GRAPHQL" },
                new APIType { Id = new Guid("8028a4d9-53cf-4a23-bb5c-949b0a2a5806"), Name = "SOAP" },
                new APIType { Id = new Guid("d09b4952-47c8-4c9d-a39a-d3d57643c02b"), Name = "REST" }
            );
        }
    }
}
