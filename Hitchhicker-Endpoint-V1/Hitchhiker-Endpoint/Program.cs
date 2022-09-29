using Hitchhicker_Endpoint.Services.Builder;
using Hitchhicker_Endpoint.Services.HitchhikerManager;
using Hitchhicker_Endpoint_V1.System;

CustomLauncher.Launch(args);

public static class CustomLauncher
{
    public static string[] launcherArgs = new string[0];

    public static void Launch(string[] args)
    {
        launcherArgs = args;

        Thread threadWeb = new Thread(launchWebApp);
        Thread threadTimer = new Thread(launchTimer);

        threadWeb.Start();
        threadTimer.Start();
    }

    public static void launchTimer()
    {
        TimerEventCreator.CreateTimer();
    }

    public static void launchWebApp()
    {
        // prepare
        var builder = WebApplication.CreateBuilder(launcherArgs);

        builder.Services.AddControllers();
        builder.Services.
            AddSingleton<IBuilderOfIHitchhiker, BuilderOfIHitchhiker>().
            AddSingleton<IHitchhikerManager, HitchhikerManager>();

        var app = builder.Build();
        app.MapControllers();

        // start
        app.Run();
    }
}