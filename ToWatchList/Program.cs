using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using ToWatchList.Data;
using ToWatchList.Interfaces;

namespace ToWatchList
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            
            // Injecting Implementation directly 
            builder.Services.AddSingleton<TMDBService>();
            
            // Injecting Interface
            // swith bewteen Redis and SQLite
            //builder.Services.AddSingleton<IDatabaseStorage>(DatabaseStorageFactory.GetRedisDatabaseStorage());
            builder.Services.AddSingleton<IDatabaseStorage>(DatabaseStorageFactory.GetSQLiteDatabaseStorage());

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }


            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}