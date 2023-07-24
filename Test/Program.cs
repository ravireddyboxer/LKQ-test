using Microsoft.EntityFrameworkCore;
using Test.API.BusinessLogic;
using Test.API.DataAccess;
using Test.API.Interfaces;

namespace Test
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

            // Adding custom services to the DI
            builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer("connetion string"));
            builder.Services.AddTransient<IInvoiceCreator, InvoiceCreator>();
            builder.Services.AddTransient<IPaymentsExtractorFromFile, PaymentsExtractorFromFile>();
            builder.Services.AddTransient<IInvoiceAndPaymentsComparer, InvoiceAndPaymentsComparer>();

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