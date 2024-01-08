using Memory;
using Microsoft.AspNetCore.Components;

namespace Cra_chmerker.Client.Pages.Games
{
    public partial class Memory : ComponentBase
    {
        [Inject]
        private Game game { get; set; }

        private int numberOfPairs = 5;

        private const string bgUrl = "https://static.vecteezy.com/system/resources/previews/028/148/064/non_2x/poker-card-game-pattern-seamless-casino-background-with-card-suits-clubs-hearts-spades-and-diamonds-with-white-outline-vector.jpg";


    protected override async Task OnInitializedAsync()
        {
             await game.Init(5);
        }
    }
}