
using DeliverySystem.Application.Interfaces;
using DeliverySystem.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using DeliverySystem.Infrastructure.Services.DelivaryService;
using DeliverySystem.Infrastructure.Services.ProductService;
using DeliverySystem.Core.RepositoryInterfaces;
using DeliverySystem.Infrastructure.Repositories;
using DeliverySystem.Application.Mappings;

namespace DeliverySystem.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //connectionString
            builder.Services.AddDbContext<DeliveryDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            builder.Services.AddAutoMapper(typeof(productProfile).Assembly);


            builder.Services.AddScoped<IDeliveryScheduler, DeliveryScheduler>();
            builder.Services.AddScoped<IProductService, ProductService>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy", policy =>
                    policy.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()
                );
            });


            var app = builder.Build();

            app.UseCors("MyPolicy");


            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            app.UseSwagger();
                app.UseSwaggerUI();
            //}

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
