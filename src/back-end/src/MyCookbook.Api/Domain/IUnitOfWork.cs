using System.Threading.Tasks;

namespace MyCookbook.Api.Domain.SharedKernel
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
    }
}
