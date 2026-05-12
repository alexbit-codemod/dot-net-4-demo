# Demo App

Small **.NET Framework 4.7.2** sample (OWIN / Web API 2) used for modernization exercises.

## Easiest path (recommended): GitHub Actions

You can stay on macOS for day-to-day work and still **build, test, and get a runnable Windows app** from CI.

1. Push this repo to GitHub (or open it in a repo you already have).
2. Open **Actions** → **demo-app-ci** → wait for the run to finish (uses `windows-latest`).
3. Open the run → **Artifacts** → download **`build-artifacts`**.
4. Unzip on a **Windows** PC or VM. Open folder **`api-host`**.
5. Run **`DemoApp.Legacy.ApiHost.exe`** (may require **[.NET Framework 4.7.2 runtime](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net472)** if not already installed).
6. Call the API (default from `App.config`): [http://localhost:8088/api/orders/1](http://localhost:8088/api/orders/1)

You can also start a run manually: **Actions** → **demo-app-ci** → **Run workflow**.

## All-in-one on Windows

If you already have Windows (local or cloud VM), from the repo root:

```powershell
dotnet restore DemoApp.sln
dotnet build DemoApp.sln -c Release
dotnet test DemoApp.sln -c Release
dotnet run --project src\DemoApp.Legacy.ApiHost\DemoApp.Legacy.ApiHost.csproj -c Release
```

## Why not Docker on Mac?

This project targets **.NET Framework**, not .NET 8. Framework-dependent containers are **Windows-only**; Mac Docker cannot run them. CI on GitHub avoids that entirely.

See `docs/migration-assessment.md` for intentional legacy patterns in the code.
