using Hitchhicker_Endpoint.Services.Builder;
using Hitchhicker_Endpoint.Services.HitchhikerManager;
using Hitchhicker_Endpoint.StartUp;
using Hitchhicker_Endpoint.System;

// settings
const int INTERVALL_IN_SECONDS = 7;

// create builder
var builder = WebApplication.CreateBuilder(args);

// subscribe services
builder.Services.AddControllers();
builder.Services.
    AddSingleton<IBuilderOfIHitchhiker, BuilderOfIHitchhiker>().
    AddSingleton<IHitchhikerManager, HitchhikerManager>();

// create webapp
var app = builder.Build();

// add endpoints
app.MapControllers();

// create dependencies for launcher
IHitchhikerManager hitchhikerManager = app.Services.GetRequiredService<IHitchhikerManager>();
TimerEventManager timerEventManager = new(INTERVALL_IN_SECONDS, hitchhikerManager);

// launch
var launcher = new CustomLauncher(app, timerEventManager);
launcher.Launch();