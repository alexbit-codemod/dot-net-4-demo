using System;
using System.Net;

namespace DemoApp.Legacy.Infrastructure;

public sealed class WebCatalogClient
{
    private readonly Uri _baseUri;

    public WebCatalogClient(Uri baseUri) => _baseUri = baseUri;

    public string DownloadRaw(string relativePath)
    {
        using var client = new WebClient();
        client.BaseAddress = _baseUri.ToString();
        return client.DownloadString(new Uri(relativePath, UriKind.Relative));
    }
}
