using Ardalis.Specification;

namespace huzcodes.Persistence.Interfaces.Repositories
{
    /// <summary>
    /// This interface is used for saving entities into SQL db using EF core and Ardalis.Specifications
    /// </summary>
    /// <typeparam name="TEntity">Entity data model as generic type</typeparam>
    public interface IRepository<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
    }

}
