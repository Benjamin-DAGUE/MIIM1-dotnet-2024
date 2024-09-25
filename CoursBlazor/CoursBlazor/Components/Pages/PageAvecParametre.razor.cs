
using Microsoft.AspNetCore.Components;

namespace CoursBlazor.Components.Pages;

public partial class PageAvecParametre
{
    [Parameter]
    public int Id { get; set; }

    [Parameter]
    public EventCallback<int> IdChanged { get; set; }

    private void IncrementCount()
    {
        //Ceci est exécuté côté serveur
        Id++;
        IdChanged.InvokeAsync(Id);
        if (NavigationManager.ToBaseRelativePath(NavigationManager.Uri).StartsWith("page/"))
        {
            NavigationManager.NavigateTo("page/" + Id);
        }
    }
}
