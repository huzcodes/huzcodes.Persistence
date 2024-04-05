using Ardalis.Specification;

namespace huzcodes.Persistence.Interfaces.Repositories
{
    /// <summary>
    /// This interface is used for reading entities into SQL db using EF core and Ardalis.Specifications
    /// </summary>
    /// <typeparam name="TEntity">Entity data model as generic type</typeparam>
    public interface IReadRepository<TEntity> : IReadRepositoryBase<TEntity> where TEntity : class
    {
    }
}
