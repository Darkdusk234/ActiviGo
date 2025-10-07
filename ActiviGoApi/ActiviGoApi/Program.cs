
using ActiviGoApi.Services.Mapping;
using ActiviGoApi.Services.Validation.DataValidation;
using FluentValidation;

namespace ActiviGoApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Adding FluentValidation
            builder.Services.AddValidatorsFromAssemblyContaining<LocationRequestDTO_Validator>();

            // Adding AutoMapper profiles
            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<LocationMappingProfile>();
                cfg.AddProfile<CategoryMappingProfile>();
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


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
