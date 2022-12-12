using _4___Domain.Entities;
using _4___Domain.Specifications.Interfaces;

namespace _4___Domain.Specifications
{
    public class TaxExempleLogic : ISpecification<VehicleEntity>
    {
        public bool IsSatisfiedBy(VehicleEntity candidate)
        {
            return (candidate.ModelYear < (DateTime.Now.Year - 20) ? true : false);
        }
    }
}
