using Application.Core;
using Application.LearningSpaces;
using Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using FluentValidation;
using System.Text.Json.Serialization;

namespace API.Extentions
{
  public static class ApplicationServicesExtention
  {
    public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration config)
        {

          services.AddEndpointsApiExplorer();
          services.AddSwaggerGen();
          services.AddCors(options => {
            options.AddPolicy("CorsPolicy", policy =>{
              policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
            });
          });

          services.AddDbContext<DataContext>(opt =>
          {
            opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
          });
          services.AddMediatR(typeof(GetAll.Handler));
          services.AddAutoMapper(typeof(MappingProfile).Assembly);
          services.AddFluentValidationAutoValidation();
          services.AddValidatorsFromAssemblyContaining<Create>();

          services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.WriteIndented = true;
            });

          return services;
        }
  }
}