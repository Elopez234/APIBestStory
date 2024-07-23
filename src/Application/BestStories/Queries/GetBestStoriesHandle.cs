using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiBestSc.Application.Common.Models;
using ApiBestSc.Application.TodoItems.Queries.GetTodoItemsWithPagination;
using ApiBestSc.Application.WeatherForecasts.Queries.GetWeatherForecasts;
using Newtonsoft.Json;

namespace ApiBestSc.Application.BestStories.Queries;
public class GetBestStoriesQuery : IRequest<List<BestStoryDto>>;
public class GetBestStoriesQueryHandler : IRequestHandler<GetBestStoriesQuery, List<BestStoryDto>>
{
     
    public  async Task<List<BestStoryDto>> Handle(GetBestStoriesQuery request, CancellationToken cancellationToken)
    {
        List<BestStoryDto> res = new List<BestStoryDto>();
        List<int> BestStoriesId = await GetProductAsyncJson("https://hacker-news.firebaseio.com/v0/beststories.json");
        foreach (int id in BestStoriesId) {
            BestStoryDto result = await GetDetStorytAsync("https://hacker-news.firebaseio.com/v0/item/",id);
            res.Add(result);
        }
        return await Task.FromResult(res);
        
    }


    static async Task<BestStoryDto> GetDetStorytAsync(string path, int idStory )
    {
        BestStoryDto det = new BestStoryDto();
        using (var webClient = new HttpClient())
        {
            var response = webClient.GetStringAsync(path+idStory+".json");
            var jsonBestSt = response.Result;
            if (jsonBestSt != null)
            {
                var result = JsonConvert.DeserializeObject<BestStoryDto>(jsonBestSt);

                det = result is null ? new BestStoryDto() : result;
            }
        }
        return await Task.FromResult(det);
    }

    static async Task<List<int>> GetProductAsyncJson(string path) {
        List<int> product = new List<int>();

        using (var webClient = new HttpClient())
        {
            var response = webClient.GetStringAsync(path);
            var jsonBestSt = response.Result;
            if (jsonBestSt != null) {
                var result = JsonConvert.DeserializeObject<List<int>>(jsonBestSt);

                product = result is null ?  new List<int>(): result;
            }
        }
        return  await Task.FromResult( product);
    }

}
