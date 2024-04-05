using Ardalis.Specification.EntityFrameworkCore;
using huzcodes.Persistence.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace huzcodes.Persistence.Implementations.EfRepository
{
    /// <summary>
    /// This class is used to be inherited and passing the app db context of the solution to its own base class,
    /// To be able to use IRepository interface that uses in its own implementation EF core, 
    /// Ardalis.Specifications and Ardalis.EntityFrameWorkCore
    /// </summary>
    /// <typeparam name="TEntity">Entity data model as generic type</typeparam>
    public abstract class HuzcodesRepository<TEntity> : RepositoryBase<TEntity>, IReadRepository<TEntity>, IRepository<TEntity> where TEntity : class
    {
        public HuzcodesRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
