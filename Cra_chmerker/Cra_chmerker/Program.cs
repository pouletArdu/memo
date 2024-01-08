using Cra_chmerker.Client.Pages;
using Cra_chmerker.Components;
using Infra;
using Infra.Entities;
using Memory;
using Memory.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddControllers();
builder.Services.AddScoped<ICraService, CraService>();

builder.Services.AddScoped<IImageService>(s =>
{
    var httpclient = new HttpClient();
    httpclient.BaseAddress = new Uri(builder.Configuration.GetSection("PhotoApi:Url").Value!);
    
    
    httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Client-ID", builder.Configuration.GetSection("PhotoApi:AccessKey").Value!);
    return new ImageService(httpclient);
});

builder.Services.AddScoped<Game>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Counter).Assembly);

//Create route for api to create Cra
app.MapControllers();

//minimal api
app.MapGet("/api/cra", (ICraService craService, int month, int year) => craService.Get(month, year));
app.MapPost("/api/cra", (ICraService craService, Cra cra) =>
{
    try
    {
        craService.Submit(cra);
        return 1;
    }
    catch (Exception)
    {

        return 0;
    }
});





app.Run();
