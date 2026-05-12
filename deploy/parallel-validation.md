# Deployment — .NET Framework host only

**Demo App** ships as a **single** self-hosted Web API (`DemoApp.Legacy.ApiHost`) on **.NET Framework** (`net472`) via OWIN.

Build the executable (Release):

```bash
dotnet build src/DemoApp.Legacy.ApiHost/DemoApp.Legacy.ApiHost.csproj -c Release
```

Run the published output on a Windows machine (or your existing IIS / Windows service packaging). Base URL is read from `App.config` (`SelfHostBaseUrl`, default `http://localhost:8088/`).

When you later introduce a second runtime for migration, use separate routing, canaries, and monitoring; that process is not modeled in this baseline repo.
