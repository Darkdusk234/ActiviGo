
using ActiviGoApi.Services;
using ActiviGoApi.Services.Interfaces;
using ActiviGoApi.Services.Mapping;
using ActiviGoApi.Infrastructur.Data;
using ActiviGoApi.Services.Validation.DataValidation;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ActiviGoApi.Core.Models;
using Microsoft.EntityFrameworkCore;
using ActiviGoApi.Services.Services;
using ActiviGoApi.Infrastructur.Repositories;

namespace ActiviGoApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IBookingService, BookingService>();
            builder.Services.AddScoped<ILocationService, LocationService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ISubLocationService, SubLocationService>();
            builder.Services.AddScoped<IActivityService, ActivityService>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


            // Adding FluentValidation
            builder.Services.AddValidatorsFromAssemblyContaining<LocationRequestDTO_Validator>();

            builder.Services.AddDbContext<ToadContext>(options => 
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Adding AutoMapper profiles
            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<LocationMappingProfile>();

                cfg.AddProfile<CategoryMappingProfile>();

                cfg.AddProfile<BookingMappingProfile>();

                cfg.AddProfile<SubLocationMappingProfile>();

            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(
                c =>
                {
                    c.SwaggerDoc("v1", new()
                    {
                        Title = "ActiviGO API",
                        Version = "v1",
                        Description = "An API for being youuuu"
                    });

                    var jwtSecurityScheme = new OpenApiSecurityScheme
                    {
                        Scheme = "bearer",
                        BearerFormat = "JWT",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.Http,
                        Description = "Put ** _ONLY_** your JWT Bearer token on textbox below!",
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    };

                    c.AddSecurityDefinition("Bearer", jwtSecurityScheme);
                    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {  jwtSecurityScheme, Array.Empty<string>() }
                    });


                }

                );


            // Identity
            builder.Services.AddIdentity<User, IdentityRole>(opt =>
            {
                opt.Password.RequireDigit = true;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = true;
                opt.Password.RequireLowercase = false;

                opt.Password.RequiredLength = 6;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ToadContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();

            // Authentication & Authorization

            var jwt = builder.Configuration.GetSection("Jwt");
            var keyString = jwt["Key"];
            Console.WriteLine(keyString);
            if (string.IsNullOrWhiteSpace(keyString))
                throw new Exception("JWT key is missing or empty!");
            Console.WriteLine($"JWT Key Length: {keyString.Length}");
            var key = Encoding.UTF8.GetBytes(jwt["Key"]);

            if (key == null)
            {
                throw new Exception("key null?");
            }

            builder.Services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })
                            .AddJwtBearer(opt =>
                            {
                                opt.TokenValidationParameters = new TokenValidationParameters
                                {
                                    ValidateIssuer = true,
                                    ValidateAudience = true,
                                    ValidateLifetime = true,
                                    ValidateIssuerSigningKey = true,
                                    ValidIssuer = jwt["Issuer"],
                                    ValidAudience = jwt["Audience"],
                                    IssuerSigningKey = new SymmetricSecurityKey(key)
                                };

                                opt.IncludeErrorDetails = true;
                            });

            builder.Services.AddAuthorization(opt =>
            {
                opt.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
                opt.AddPolicy("UserPolicy", policy => policy.RequireRole("User", "Admin"));
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
