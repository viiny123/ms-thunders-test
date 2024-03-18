using System.Threading.Tasks;

namespace Test.Thunders.Domain.Base;

public interface IUnitOfWork
{
    Task SaveAsync();
}