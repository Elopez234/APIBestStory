using System.Collections.Generic;
using ApiBestSc.Application.BestStories.Queries;
using ApiBestSc.Application.Common.Models;
using ApiBestSc.Application.TodoItems.Queries.GetTodoItemsWithPagination;

namespace ApiBestSc.Web.Endpoints;

public class BestStories : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetBestStories);
    }
    public async Task <List<BestStoryDto>> GetBestStories(ISender sender)
    {
        //List<BestStoryDto> res = new List<BestStoryDto>([new BestStoryDto() { CommentCount = 2, PostedBy = "not" }]) ;
        
        return await sender.Send(new GetBestStoriesQuery());
    }
}
