using API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Persistence.Seeds
{
    public class HTTPMethodsSeed : IEntityTypeConfiguration<HTTPMethods>
    {
        public void Configure(EntityTypeBuilder<HTTPMethods> builder)
        {
            builder.HasData(
                new HTTPMethods { Id = new Guid("587e4311-f39f-4c0e-b909-81f7f4571d7b"), Name = "GET"},
                new HTTPMethods { Id = new Guid("a05fd283-d09d-45b1-8f67-9832c4e21e0f"), Name = "POST" },
                new HTTPMethods { Id = new Guid("c1acbd7a-8d8d-4f5d-bb72-6d6b0f7939b1"), Name = "PUT" },
                new HTTPMethods { Id = new Guid("9b0f3a02-12a6-4b1f-bc48-1e631b79c2fd"), Name = "PATCH" },
                new HTTPMethods { Id = new Guid("f2fc5b6c-8ab7-49e0-ae56-733c889b45c6"), Name = "DELETE" }
            );
        }
    }
}
