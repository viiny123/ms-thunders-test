using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Test.Thunders.Domain.Base;

namespace Test.Thunders.Data.Extensions;

public static class QueryablePageListExtensions
{
    public static async Task<Paginate<T>> ToPagedListAsync<T>(this IQueryable<T> source, int page, int pageSize, CancellationToken cancellationToken = default) where T : class
    {
        var count = await source.CountAsync(cancellationToken).ConfigureAwait(false);
        var items = await source.Skip(pageSize * (page - 1))
                                .Take(pageSize).ToListAsync(cancellationToken).ConfigureAwait(false);
        var totalPages = (int)Math.Ceiling(count / (double)pageSize);
        return new Paginate<T>(pageSize, page, count, totalPages, items);
    }
}
