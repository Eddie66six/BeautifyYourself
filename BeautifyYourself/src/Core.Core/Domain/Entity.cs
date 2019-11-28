namespace Core.Core.Domain
{
    public abstract class Entity : ErrorEvent
    {
        protected abstract void Validate();
    }
}
