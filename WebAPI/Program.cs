using Infrastructure.Context;
using Infrastructure.Repositories;
using Infrastructure.Services.Custom_Services.DepartmentServices;
using Infrastructure.Services.Custom_Services.EmployeeServices;
using Infrastructure.Services.Custom_Services.SallaryServices;
using Infrastructure.Services.Generic_Services;
using Microsoft.EntityFrameworkCore;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<MainDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
            builder.Services.AddTransient(typeof(IService<>),typeof(Service<>));
            builder.Services.AddTransient(typeof(IEmployeeService), typeof(EmployeeService));
            builder.Services.AddTransient(typeof(IDepartmentService), typeof(DepartmentService));
            builder.Services.AddTransient(typeof(ISallaryService), typeof(SallaryService));

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