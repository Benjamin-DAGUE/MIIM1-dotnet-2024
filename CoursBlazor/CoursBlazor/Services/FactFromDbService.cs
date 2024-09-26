using CoursBlazor.Models;
using Microsoft.EntityFrameworkCore;

namespace CoursBlazor.Services;

public class FactFromDbService
{
    #region Fields

    private IDbContextFactory<FactDbContext> _contextFactory;

    #endregion

    #region Constructors

    public FactFromDbService(IDbContextFactory<FactDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    #endregion

    #region Methods

    public async Task<List<Fact>> GetFactsAsync(int count)
    {
        using FactDbContext context = await _contextFactory.CreateDbContextAsync();
        return context.Facts.Take(count).ToList();
    }

    #endregion
}
