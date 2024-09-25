
using Microsoft.AspNetCore.Components;

namespace CoursBlazor.Components.Pages;

public partial class PageAvecParametre
{
    [Parameter]
    public int Id { get; set; }

    private void IncrementCount()
    {
        //Ceci est exécuté côté serveur
        Id++;
        if (NavigationManager.ToBaseRelativePath(NavigationManager.Uri).StartsWith("page/"))
        {
            NavigationManager.NavigateTo("page/" + Id);
        }
    }
}
