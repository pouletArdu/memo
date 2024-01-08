namespace Memory;

public class Card(Image image)
{
    public string Name { get; set; } = image.Id;
    public Urls ImageUrl { get; init; } = image.Urls;
    public bool IsFlipped { get; set; }
    public bool IsMatched { get; set; }
}
