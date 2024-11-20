
using Final_Project.EF;
using Final_Project.EF.Configuration;
using FinalProject.Core;
using Microsoft.EntityFrameworkCore;

namespace Final_Project.Api
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

            // Database Connection
            var ConnectionStrings = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection String not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(ConnectionStrings,
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                    ));

            // Dependency Injection
            builder.Services.AddTransient<IUnitOfWork, UnitOfWorkImp>();
            //builder.Services.AddScoped<IWebHostEnvironment>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
