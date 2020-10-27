using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCookbook.Api.Domain.SharedKernel
{
    /// <summary>
    /// Represents a generic repository.
    /// Implements the <see cref="IRepository{T}" />.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <seealso cref="IRepository{T}" />
    public interface IRepository<T>
        where T : Entity
    {
        IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// Gets the entity by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The entity.</returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Adds a new entity.
        /// </summary>
        /// <param name="entity">The new entity.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Update the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(T entity);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete(T entity);

        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns>The entities.</returns>
        Task<IReadOnlyList<T>> ListAllAsync();
    }
}
