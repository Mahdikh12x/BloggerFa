namespace _0_Framework.Domain;

public abstract class BaseEntityWithSeoTags<T>:BaseEntity<T>
{
    public string MetaDescription { get; private set; } = null!;
    public string Keywords { get; private set; } = null!;
    public string Slug { get; private set; } = null!;
    public string? CanonicalAddress { get; private set; }

    protected BaseEntityWithSeoTags(string metaDescription, string keywords, string slug, string? canonicalAddress)
    {
        MetaDescription = metaDescription;
        Keywords = keywords;
        Slug = slug;
        CanonicalAddress = canonicalAddress;
    }

    protected BaseEntityWithSeoTags()
    {
        
    }


    public  void Edit(string metaDescription, string keywords, string slug, string? canonicalAddress)
    {
        MetaDescription = metaDescription;
        Keywords = keywords;
        Slug = slug;
        CanonicalAddress = canonicalAddress;
    }
}