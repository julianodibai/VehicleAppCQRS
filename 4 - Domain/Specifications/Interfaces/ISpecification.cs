namespace _4___Domain.Specifications.Interfaces
{
    public interface ISpecification<in T> where T : class
    {
        bool IsSatisfiedBy(T candidate);
    }
}
