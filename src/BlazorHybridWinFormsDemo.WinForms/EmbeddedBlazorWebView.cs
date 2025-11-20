using BlazorHybridWinFormsDemo.Razor;
using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.FileProviders;

namespace BlazorHybridWinFormsDemo.WinForms;

public class EmbeddedBlazorWebView : BlazorWebView
{
    public override IFileProvider CreateFileProvider(string contentRootDir)
    {
        var embedded = new ManifestEmbeddedFileProvider(typeof(App).Assembly, "wwwroot");
        return embedded;
    }
}
