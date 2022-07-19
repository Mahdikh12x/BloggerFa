using _0_Framework.Domain;
using BlogManagement.Application.Contracts.Tag;

namespace BlogManagement.Domain.TagAgg
{
    public interface ITagRepository:IRepository<long,Tag>
    {
        EditTag? GetDetails(long id);
        List<TagViewModel>? Search(TagSearchModel searchModel);

    }
}
