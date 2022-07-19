namespace _0_Framework.Domain
{
    public abstract class BaseEntity<T>
    {
        public T? Id { get; private set; }

        public DateTime CreationDate { get; private set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; }
        protected BaseEntity()
        {

        }

    }
}
