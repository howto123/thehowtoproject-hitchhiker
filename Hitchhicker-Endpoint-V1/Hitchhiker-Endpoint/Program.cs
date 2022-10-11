using Hitchhicker_Endpoint.Services.Builder;
using Hitchhicker_Endpoint.Services.HitchhikerManager;
using Hitchhicker_Endpoint.StartUp;
using Hitchhicker_Endpoint.System;

const int INTERVALL_IN_SECONDS = 7;

var builder = WebApplication.CreateBuilder(args);

// subscribe services
builder.Services.AddControllers();
builder.Services.
    AddSingleton<IBuilderOfIHitchhiker, BuilderOfIHitchhiker>().
    AddSingleton<IHitchhikerManager, HitchhikerManager>();

var app = builder.Build();

// add endpoints
app.MapControllers();

// create dependencies for launcher
IHitchhikerManager hitchhikerManager = app.Services.GetRequiredService<IHitchhikerManager>();
TimerEventManager timerEventManager = new(INTERVALL_IN_SECONDS, hitchhikerManager);

// Reviewer: XML Comment is not visible for CustomLauncher. Why not?
var launcher = new CustomLauncher(app, timerEventManager);
launcher.Launch();


// Interesting read:
// https://andrewlock.net/exploring-dotnet-6-part-1-looking-inside-configurationmanager-in-dotnet-6/