using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
 

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoriesController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger<StoriesController> _logger;
        private readonly ApiUrls _apiUrls;
        private readonly IMemoryCache _cache;

        public StoriesController(ILogger<StoriesController> logger, IHttpClientFactory clientFactory, IOptions<ApiUrls> apiUrls, IMemoryCache cache)
        {
            _logger = logger;
            _clientFactory = clientFactory;
            _apiUrls = apiUrls.Value;
            _cache = cache;
        }

        [HttpGet("{n}")]
        [ResponseCache(Duration = 60)] // Cache the response for 60 seconds
        public async Task<IActionResult> GetBestStories(int n)
        {
            try
            {
                var client = _clientFactory.CreateClient();

                var bestStoriesIds = await GetBestStoriesIds(client);

                var stories = await GetStoriesDetails(client, bestStoriesIds, n);



                var bestNStories = FilterAndSortStories(stories);

                var response = new ApiResponse
                {
                    Message = "Best stories retrieved successfully",
                    Success = true,
                    Status = "success",
                    Data = bestNStories
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching best stories");
                var response = new ApiResponse
                {
                    Message = "An error occurred while fetching best stories",
                    Success = false,
                    Status = "error",
                    StackTrace = ex.StackTrace
                };

                return StatusCode(500, response);
            }
        }


        // retrieve the IDs of the best stories
        private async Task<int[]> GetBestStoriesIds(HttpClient client)
        {
            return await client.GetFromJsonAsync<int[]>(_apiUrls.BestStories);
        }

        // retrieve details of each story
        private async Task<List<Story>> GetStoriesDetails(HttpClient client, int[] bestStoriesIds,int n)
        {


            var nbestStoriesIds = bestStoriesIds.Take(n);

            var stories = new List<Story>();

            //Get cache stories
            var cachedResponse = _cache.Get<List<Story>>("BestStories");

            if (cachedResponse != null)
            {
                foreach (var cStory in cachedResponse)
                {
                    stories.Add(cStory);
                    nbestStoriesIds = nbestStoriesIds.Where(id => id != cStory.Id).ToArray();
                }
            }

            foreach (var storyId in nbestStoriesIds)
            {
          
                var story = await client.GetFromJsonAsync<Story>(string.Format(_apiUrls.StoryDetails, storyId));
                stories.Add(story);
            }

            var sortedStories = stories.OrderByDescending(s => s.Score).ToList();
            // Cache the fetched stories
            _cache.Set("BestStories", sortedStories, TimeSpan.FromMinutes(5)); // Cache for 5 minutes

            return stories;
        }

        // filter and sort the stories
        private List<Story> FilterAndSortStories(List<Story> stories)
        {
            return stories.Where(s => s.Type == "story" && !s.Deleted && !s.Dead)
                          .OrderByDescending(s => s.Score)
                          .ToList();
        }
    }
}
