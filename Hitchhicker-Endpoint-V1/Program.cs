using Hitchhicker_Endpoint_V1.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<IHitchhikerManager, HitchhikerManager>();

var app = builder.Build();

app.MapControllers();

app.Run();
