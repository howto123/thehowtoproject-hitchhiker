using Hitchhicker_Endpoint.Services.Builder;
using Hitchhicker_Endpoint.Services.HitchhikerManager;
using Hitchhicker_Endpoint_V1.System;

// prepare
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.
    AddSingleton<IBuilderOfIHitchhiker, BuilderOfIHitchhiker>().
    AddSingleton<IHitchhikerManager, HitchhikerManager>();

var app = builder.Build();
app.MapControllers();


var launcher = new CustomLauncher(app, app.Services.GetRequiredService<IHitchhikerManager>());
launcher.Launch();

public class CustomLauncher
{
    private IHitchhikerManager _hitchhikerManager;
    private TimerEventManager _timerEventManager;
    private WebApplication _app;

    public CustomLauncher(WebApplication app, IHitchhikerManager hitchhikerManager)
    {
        const int INTERVALL_IN_SECONDS = 7;
        _app = app;
        _hitchhikerManager = hitchhikerManager;
        _timerEventManager = new TimerEventManager(INTERVALL_IN_SECONDS, _hitchhikerManager);
    }
    public void Launch()
    {
        Thread threadWeb = new Thread(LaunchWebApp);
        Thread threadTimer = new Thread(LaunchTimer);

        threadWeb.Start();
        threadTimer.Start();
    }

    private void LaunchTimer()
    {
        _timerEventManager.LaunchTimerEvents();
    }

    private void LaunchWebApp()
    {
        _app.Run();
    }
}