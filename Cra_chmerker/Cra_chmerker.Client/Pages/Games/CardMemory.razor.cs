using Memory;
using Microsoft.AspNetCore.Components;

namespace Cra_chmerker.Client.Pages.Games
{
    public partial class CardMemory : ComponentBase
    {
        [Inject]
        private Game game { get; set; }

        private int numberOfPairs = 5;
        private string theme = "animals";

        private const string bgUrl = "Assets/cardbg.png";


        protected override async Task OnInitializedAsync()
        {
        }
    }
}