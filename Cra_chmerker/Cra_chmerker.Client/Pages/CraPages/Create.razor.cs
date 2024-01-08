global using Infra.Entities;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Cra_chmerker.Client.Pages.CraPages;

public partial class Create : ComponentBase
{
    private readonly HttpClient _httpClient = new HttpClient();
    public Cra cra;
    public Dictionary<int, int> Days;
    public int test { get; set; }
    protected override void OnInitialized()
    {
        if(cra == null)
        {
        cra = new Cra(DateTime.Now);
        Days = cra.Days;

        }
    }

    //updateValue
    private void UpdateDay(int day, int value)
    {
        Days[day] = value;
    }

    private async Task HandleSubmit()
    {
        // call the API to save the Cra
        await _httpClient.PostAsJsonAsync("https://localhost:7248/api/Cra", cra);  
    }

    private void Cancel()
    {
        // Handle the cancel action here
    }
}