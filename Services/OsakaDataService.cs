using System.Net.Http.Json;
using uiux_soft2.Models;

namespace uiux_soft2.Services;

public class OsakaDataService(HttpClient httpClient)
{
    public async Task<List<TopicItem>> GetTopicsAsync()
    {
        var topics = await httpClient.GetFromJsonAsync<List<TopicItem>>("data/osaka-topics.json");

        return topics ?? new List<TopicItem>();
    }
}
