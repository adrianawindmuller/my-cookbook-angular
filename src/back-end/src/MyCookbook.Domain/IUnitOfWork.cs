using System.Threading.Tasks;

namespace MyCookbook.Domain
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
    }
}
