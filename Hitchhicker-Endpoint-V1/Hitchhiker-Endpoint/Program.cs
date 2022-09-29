using Hitchhicker_Endpoint.Services.Builder;
using Hitchhicker_Endpoint.Services.HitchhikerManager;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.
    AddSingleton<IBuilderOfIHitchhiker, BuilderOfIHitchhiker>().
    AddSingleton<IHitchhikerManager, HitchhikerManager>();

var app = builder.Build();

app.MapControllers();

app.Run();
