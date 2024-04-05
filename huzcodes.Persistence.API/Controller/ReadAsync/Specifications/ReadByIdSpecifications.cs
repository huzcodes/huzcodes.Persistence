using Ardalis.Specification;

namespace huzcodes.Persistence.API.Controller.ReadAsync.Specifications
{
    public class ReadByIdSpecifications : Specification<DataModel>
    {
        public ReadByIdSpecifications(int id)
        {
            Query.Where(o => o.Id == id);
        }
    }
}
