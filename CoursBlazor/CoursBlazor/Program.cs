using CoursBlazor.Components;
using CoursBlazor.Models;
using CoursBlazor.Services;
using Microsoft.EntityFrameworkCore;

namespace CoursBlazor;

public class Program
{
    public static async Task Main(string[] args)
    {
        //Blazor s'appui sur ASP.NET Core
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        //ASP.NET Core dispose d'un conteneur de composition (injection de dépendance).
        //Vous pouvez inscrire ici des services qui seront alors injectable dans les composants et les classes.

        //Blazor nécessite l'inscription de services.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        //Inscription d'une factory de contexte EntityFramework
        builder.Services.AddDbContextFactory<FactDbContext>(a => a.UseSqlite(@"Data Source=c:\_workdir\temp.db;"));

        //Inscription d'un HttpClient nommé
        builder.Services.AddHttpClient("catfact", (httpClient) =>
        {
            httpClient.BaseAddress = new("https://catfact.ninja/");
        });

        //Inscription d'un service de récupération de données depuis un WebService
        builder.Services.AddScoped<FactFromAPIService>();
        builder.Services.AddScoped<FactFromDbService>();

        //Après l'inscription des services et la configuration de la WebApp, il faut construire la WebApplication.
        WebApplication app = builder.Build();

        //Ensuite, c'est le pipeline HTTP qui est construit.

        //Le pipeline est constitué de Middleware (interjiciel) qui sont appelé les un à la suite des autres.

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        else
        {
            //Création d'un scrope pour accéder aux services via le ServiceProvider
            using IServiceScope serviceScope = app.Services.CreateScope();

            //Création de la factory de contexte EF
            IDbContextFactory<FactDbContext> contextFactory = serviceScope.ServiceProvider.GetRequiredService<IDbContextFactory<FactDbContext>>();

            //Création du contexte EF
            using DbContext dbContext = contextFactory.CreateDbContext();

            //Suppression et création de la base de donnéew
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            FactFromAPIService apiService = serviceScope.ServiceProvider.GetRequiredService<FactFromAPIService>();

            //Ajout de nouveaux Fact dans la base
            dbContext.AddRange(await apiService.GetRandomFactsAsync(20));

            //Enregistrement des données
            dbContext.SaveChanges();
        }

        //Par exemple, ce middleware redirige l'utilisateur qui accès au site via http:// vers https://
        app.UseHttpsRedirection();

        //Celui-ci met en place l'accès aux fichiers statiques (par exemple le contenu de wwwroot).
        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        //Enfin, après l'inscription des middleware, la web app peut être démarrée.
        //Un serveur Web (Kestrel) est démarré et se met alors à l'écoute des demandes entrantes.
        app.Run();
    }
}
