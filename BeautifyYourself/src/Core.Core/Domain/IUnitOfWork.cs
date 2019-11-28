namespace Core.Core.Domain
{
    public interface IUnitOfWork
    {
        bool Commit();
    }
}
