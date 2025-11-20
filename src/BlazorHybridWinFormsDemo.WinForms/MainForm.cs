// Copyright (c) gimas gmbh. All rights reserved.

using BlazorHybridWinFormsDemo.Razor;

using Dapplo.Microsoft.Extensions.Hosting.WinForms;

using Microsoft.AspNetCore.Components.WebView.WindowsForms;

namespace BlazorHybridWinFormsDemo.WinForms;

public partial class MainForm : Form, IWinFormsShell
{
    private bool _isFullScreen = false;

    public MainForm(IServiceProvider serviceProvider)
    {
        InitializeComponent();

        blazorWebView.HostPage = "/index.html";
        blazorWebView.StartPath = "/";
        blazorWebView.Services = serviceProvider;
        blazorWebView.RootComponents.Add<App>("#app");
    }
}
