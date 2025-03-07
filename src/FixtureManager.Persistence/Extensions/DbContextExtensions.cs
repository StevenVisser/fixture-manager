using Microsoft.EntityFrameworkCore;

namespace FixtureManager.Persistence.Extensions;

public static class DbContextExtensions
{
    // TODO: Turn this into a transaction
    public static async Task<T> PerformAction<T>(
        this IDbContextFactory<FixtureManagerDbContext> contextFactory,
        Func<FixtureManagerDbContext,Task<T>> action)
    {
        using var dbContext = contextFactory.CreateDbContext();
        return await action(dbContext);
    }
}
