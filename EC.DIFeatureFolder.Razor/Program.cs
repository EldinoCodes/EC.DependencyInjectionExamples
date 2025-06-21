using EC.DIFeatureFolder.Razor.Core.Extensions;

namespace EC.DIFeatureFolder.Razor;

/*
 * this project demonstrates the use of a feature folder structure in a .NET 8 Razor Pages application.
 * it allows independent feature folders to register their own services and middleware making them 
 * independent from the main application.  this allows for a more modular and maintainable codebase.
 * 
 * yes, there is a lot of code duplication in this project, but that is intentional to limit feature
 * dependencies.  each feature folder is independent and can be developed and modified in isolation.
 */

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddStartups(builder.Configuration);

        // Add services to the container.
        builder.Services.AddRazorPages();

        var app = builder.Build();

        app.AddApplicationStartups();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }
}
