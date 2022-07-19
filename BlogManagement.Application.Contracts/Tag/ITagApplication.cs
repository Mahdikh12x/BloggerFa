using _0_Framework.Application;

namespace BlogManagement.Application.Contracts.Tag;

public interface ITagApplication
{
    EditTag? GetDetails(long id);
    OperationResult Edit(EditTag command);
    OperationResult Create(CreateTag command);
    List<TagViewModel>? Search(TagSearchModel searchModel);
}