namespace _0_Framework.Domain
{
    public abstract class BaseEntity<T> 
    {
        public T? Id => default;

        public DateTime CreationDate { get; private set; } = DateTime.Now;

        protected BaseEntity()
        {
            
        }

    }
}
