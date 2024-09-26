using CoursBlazor.Models;
using System.Net.Http;

namespace CoursBlazor.Services;

public class FactFromAPIService
{
    #region Fields

    private IHttpClientFactory _httpClientFactory;

    #endregion

    #region Constructors

    public FactFromAPIService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    #endregion

    #region Methods

    public async Task<List<Fact>> GetRandomFactsAsync(int count)
    {
        List<Fact> facts = [];

        using HttpClient httpClient = _httpClientFactory.CreateClient("catfact");

        for (int i = 0; i < count; i++)
        {
            Fact fact = await httpClient.GetFromJsonAsync<Fact>("fact") ?? throw new Exception("Unable to get a valide fact from web service.");
            facts.Add(fact);
        }

        return facts;
    }

    #endregion
}
