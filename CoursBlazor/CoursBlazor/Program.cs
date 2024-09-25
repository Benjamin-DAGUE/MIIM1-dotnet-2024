using CoursBlazor.Components;

namespace CoursBlazor;

public class Program
{
    public static void Main(string[] args)
    {
        //Blazor s'appui sur ASP.NET Core
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        //ASP.NET Core dispose d'un conteneur de composition (injection de d�pendance).
        //Vous pouvez inscrire ici des services qui seront alors injectable dans les composants et les classes.

        //Blazor n�cessite l'inscription de services.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();


        //Apr�s l'inscription des services et la configuration de la WebApp, il faut construire la WebApplication.
        WebApplication app = builder.Build();

        //Ensuite, c'est le pipeline HTTP qui est construit.

        //Le pipeline est constitu� de Middleware (interjiciel) qui sont appel� les un � la suite des autres.

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        //Par exemple, ce middleware redirige l'utilisateur qui acc�s au site via http:// vers https://
        app.UseHttpsRedirection();

        //Celui-ci met en place l'acc�s aux fichiers statiques (par exemple le contenu de wwwroot).
        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        //Enfin, apr�s l'inscription des middleware, la web app peut �tre d�marr�e.
        //Un serveur Web (Kestrel) est d�marr� et se met alors � l'�coute des demandes entrantes.
        app.Run();
    }
}
