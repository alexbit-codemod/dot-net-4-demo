using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace DemoApp.Legacy.Infrastructure;

public sealed class WebCatalogClient
{
    private readonly Uri _baseUri;

    public WebCatalogClient(Uri baseUri) => _baseUri = baseUri;

    public async Task<string> DownloadRaw(string relativePath)
    {
        using var client = new HttpClient { BaseAddress = _baseUri };
        return await client.GetStringAsync(new Uri(relativePath, UriKind.Relative));
    }
}
