using System.Threading.Tasks;
using Test.Thunders.Domain.Base;

namespace Test.Thunders.Data.Base;

public class UnitOfWork : IUnitOfWork
{
    private readonly TestDbContext context;

    public UnitOfWork(TestDbContext context)
    {
        this.context = context;
    }

    public async Task SaveAsync()
    {
        await context.SaveChangesAsync();
    }
}