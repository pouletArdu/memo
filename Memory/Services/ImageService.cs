using System.Net.Http.Json;

namespace Memory.Services;

public class ImageService(HttpClient httpClient) : IImageService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<List<Image>> Get(int count, string theme= "animals")
    {
        try
        {
            string uri = $"search/photos?per_page={count}&query={theme}";


            var images = await _httpClient.GetFromJsonAsync<Response>(uri);
            return images.Results;

        }
        catch (Exception e)
        {
            throw;
        }
    }

    public class Response
    {
        public List<Image> Results { get; set; }
    }
}


