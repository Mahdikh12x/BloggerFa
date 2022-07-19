namespace BlogManagement.Application.Contracts.Tag
{
    public class TagViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string CreationDate { get; set; } = null!;
    }
}
