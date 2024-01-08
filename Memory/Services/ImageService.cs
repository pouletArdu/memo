using System.Net.Http.Json;

namespace Memory.Services;

public class ImageService(HttpClient httpClient) : IImageService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<List<Image>> Get(int count)
    {
        try
        {
            string uri = $"photos?per_page={count}";


            var images = await _httpClient.GetFromJsonAsync<List<Image>>(uri);
            return images;

        }
        catch (Exception e)
        {
            throw;
        }
    }
}


