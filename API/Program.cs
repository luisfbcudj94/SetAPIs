
using API.Application.Contracts.Interfaces;
using API.Application.Services;
using API.Domain.Interfaces;
using API.Domain.Models;
using API.Domain.Repositories;
using API.Persistence.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            builder.Services.AddScoped<IOperations<API.Domain.Models.API>, OperationService<API.Domain.Models.API>>();
            builder.Services.AddScoped<IOperations<APIType>, OperationService<APIType>>();
            builder.Services.AddScoped<IOperations<Body>, OperationService<Body>>();
            builder.Services.AddScoped<IOperations<BodyTag>, OperationService<BodyTag>>();
            builder.Services.AddScoped<IOperations<Configuration>, OperationService<Configuration>>();
            builder.Services.AddScoped<IOperations<Header>, OperationService<Header>>();
            builder.Services.AddScoped<IOperations<HeaderTag>, OperationService<HeaderTag>>();
            builder.Services.AddScoped<IOperations<HTTPMethods>, OperationService<HTTPMethods>>();
            builder.Services.AddScoped<IOperations<Tag>, OperationService<Tag>>();
            builder.Services.AddScoped<IOperations<URL>, OperationService<URL>>();
            builder.Services.AddScoped<IOperations<URLTag>, OperationService<URLTag>>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
