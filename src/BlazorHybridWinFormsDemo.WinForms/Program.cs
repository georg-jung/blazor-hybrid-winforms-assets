// Copyright (c) gimas gmbh. All rights reserved.

using System.Globalization;

using BlazorHybridWinFormsDemo.Razor;
using Dapplo.Microsoft.Extensions.Hosting.WinForms;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BlazorHybridWinFormsDemo.WinForms;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    public static Task Main(string[] args)
    {
        // 1.   Pick the culture you want - here the built-in invariant one
        var invariant = CultureInfo.InvariantCulture;

        // 2.   Apply it globally **before** WinForms, DI or Blazor are touched
        CultureInfo.DefaultThreadCurrentCulture = invariant;
        CultureInfo.DefaultThreadCurrentUICulture = invariant;

        // 3.   Make the already-running main thread use it right now
        Thread.CurrentThread.CurrentCulture = invariant;
        Thread.CurrentThread.CurrentUICulture = invariant;

        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        return CreateHostBuilder(args).Build().RunAsync();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
        => Host.CreateDefaultBuilder(args)
            .ConfigureWinForms<MainForm>()
            .ConfigureServices((hostContext, services) =>
            {
                services.AddWindowsFormsBlazorWebView();
#if DEBUG
                services.AddBlazorWebViewDeveloperTools();
                services.AddLogging(b => b.AddDebug());
#endif
            })
            .UseWinFormsLifetime()
            .UseConsoleLifetime();
}
