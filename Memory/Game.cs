using Memory.Services;
using System.Diagnostics;

namespace Memory;

public class Game(IImageService imageService)
{
    private readonly IImageService imageService = imageService;
    public int Score;
    public Stopwatch Time;

    public List<Card>? Cards { get; set; }

    public bool IsGameOver = true;

    public async Task Init(int numberOfPairs, string theme) 
    {
        var images = await imageService.Get(numberOfPairs, theme);
        Cards = images.SelectMany(i => new List<Card> {
           new(i), 
           new(i) 
        }).ToList();
        Cards.Shuffle();
        IsGameOver = false;
        Score = 0;
        Time = Stopwatch.StartNew();
    }

    public void Flip(Card card)
    {
        if(card.IsFlipped) return;

        if (Cards.Count(c => c.IsFlipped && !c.IsMatched) == 2) UnflipAll();

        card.IsFlipped = true;

        Score++;

        CheckMatch();
        

        if (Cards.All(c => c.IsMatched))
        {
            Time.Stop();
            IsGameOver = true;
        }
    }

    private void UnflipAll()
    {
        var flippedCards = Cards.Where(c => c.IsFlipped && !c.IsMatched).ToList();
        flippedCards.ForEach(c => c.IsFlipped = false);
    }

    private void CheckMatch()
    {
        var flippedCards = Cards.Where(c => c.IsFlipped && !c.IsMatched).ToList();
        if(flippedCards.Count == 2)
        {
            if (flippedCards[0].Name == flippedCards[1].Name)
            {
                flippedCards.ForEach(c => c.IsMatched = true);
            }
        }
    }

}
