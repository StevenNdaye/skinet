// using Core.Interfaces;
// using Infrastructure.Data;
// using Microsoft.EntityFrameworkCore;

// var builder = WebApplication.CreateBuilder(args);
// var services = new ServiceCollection();

// // Add services to the container.

// builder.Services.AddControllers();
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// builder.Services.AddScoped<StoreContext>();
// builder.Services.AddScoped<IProductRepository, ProductRepository>();

// using (ServiceProvider serviceProvider = services.BuildServiceProvider())
// {
//     // var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
//     try
//     {
//         var context = serviceProvider.GetRequiredService<StoreContext>();
//         Console.WriteLine("I am here");
//         await context.Database.MigrateAsync();
//         await StoreContextSeed.SeedAsync(context);
//     } catch(Exception ex){
//         Console.WriteLine(ex.Message);
//         // var logger = loggerFactory.CreateLogger<Program>();
//         // logger.LogError(ex, "An error occured during migration");
//     }

// }

// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();

// app.UseAuthorization();

// app.MapControllers();

// app.Run();
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();
            try 
            {
                var context = services.GetRequiredService<StoreContext>();
                await context.Database.MigrateAsync();
                await StoreContextSeed.SeedAsync(context, loggerFactory);
                
                // var userManager = services.GetRequiredService<UserManager<AppUser>>();
                // var identityContext = services.GetRequiredService<AppIdentityDbContext>();
                // await identityContext.Database.MigrateAsync();
                // await AppIdentityDbContextSeed.SeedUsersAsync(userManager);
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "An error occurred during migration");
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}