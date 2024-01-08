namespace Memory;

public class Image
{
    public string Id { get; set; }
    public Urls Urls { get; set; }
}

public class Urls
{
    public string Raw { get; set; }
    public string Full { get; set; }
    public string Regular { get; set; }
    public string Small { get; set; }
    public string Thumb { get; set; }
    public string SmallS3 { get; set; }
}