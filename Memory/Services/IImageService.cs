namespace Memory.Services;

public interface IImageService
{
    public Task<List<Image>> Get(int count, string theme = "animals");
}
