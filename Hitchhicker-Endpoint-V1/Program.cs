using Hitchhicker_Endpoint_V1.Services.BuilderOfIHitchhiker;
using Hitchhicker_Endpoint_V1.Services.HitchhikerManager;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.
    AddSingleton<IBuilderOfIHitchhiker, BuilderOfIHitchhiker>().
    AddSingleton<IHitchhikerManager, HitchhikerManager>();

var app = builder.Build();

app.MapControllers();

app.Run();
