using _0_Framework.Domain;
using BlogManagement.Domain.PostAgg;

namespace BlogManagement.Domain.TagAgg
{
    public class Tag:BaseEntity<long>
    {
      
        public string Name { get; private set; } = null!;
        public ICollection<Post>? Posts { get; private set; }

        protected Tag()
        {
            
        }
        public Tag(string name)
        {
            Name = name;
           
        }

        public void Edit(string name)
        {
            Name = name;
        }
    }
}

