using Hitchhicker_Endpoint_V1.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<HitchhikerManager, HitchhikerManager>();

var app = builder.Build();

app.MapControllers();

HitchhikerManager.GetInstance();
Console.WriteLine("Mangaer started");

app.Run();
