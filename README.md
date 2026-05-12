# Demo App

A small **.NET Framework 4.7.2** solution used as a **legacy baseline** for modernization work: running Upgrade Assistant or other analyzers, exercising **OWIN‑hosted Web API 2**, and testing migration tooling (for example codemods) against realistic Framework patterns.

It is **not** a production app. It **does not** target .NET 8 or ship a modern host; a migration fork would add those separately.

## What’s in the repo

| Area | Role |
|------|------|
| `src/DemoApp.Legacy.ApiHost` | OWIN self‑host, Web API 2 (`ApiController`), `App.config` |
| `src/DemoApp.Legacy.ClassicLib` | **Non‑SDK** csproj + `packages.config` (“before modernization” style) |
| `src/DemoApp.Legacy.Data` | EF6 `DbContext` |
| `src/DemoApp.Legacy.Infrastructure` | `WebClient`, shared infrastructure |
| `src/DemoApp.Shared` / `src/DemoApp.Abstractions` | Shared types and interfaces |
| `tests/DemoApp.Tests` | Unit tests |
| `.github/workflows` | Windows CI: build, test, publish **`DemoApp.Legacy.ApiHost.exe`** as an artifact |
| `deploy/parallel-validation.md` | Notes on Framework‑only deployment and migration‑era rollout (out of scope for this baseline) |

**Smoke URL** after starting the host: `http://localhost:8088/api/orders/1` (base URL from `App.config`).

## Build and run (Windows)

Requires a machine with the **.NET Framework 4.7.2** developer pack or build tools and runtime where appropriate.

From the repository root:

```powershell
dotnet restore DemoApp.sln
dotnet build DemoApp.sln -c Release
dotnet test DemoApp.sln -c Release
dotnet run --project src\DemoApp.Legacy.ApiHost\DemoApp.Legacy.ApiHost.csproj -c Release
```

Release output for the API host is under `src\DemoApp.Legacy.ApiHost\bin\Release\` (plus dependency copies as usual for Framework apps).

## CI build artifact (GitHub Actions)

If you do not have Windows locally, you can still **build and test** on GitHub’s Windows runners:

1. Push to GitHub and open **Actions** → **demo-app-ci** (wait for green, or **Run workflow**).
2. Open the **`build-artifacts`** artifact and download the zip.
3. On **any Windows machine or cloud Windows VM**, unzip the `api-host` folder and run **`DemoApp.Legacy.ApiHost.exe`**. Install the [.NET Framework 4.7.2 runtime](https://dotnet.microsoft.com/download/dotnet-framework/net472) if prompted.

That gives you a runnable Framework host without needing macOS/Linux to execute `net472` binaries.

## macOS, Linux, and Docker

- **.NET Framework** has **no** official runtime on macOS or Linux. You cannot `dotnet run` this host the same way you run a `net8.0` console app on a Mac.
- **Docker Desktop on Mac** does not run **Windows containers** the way a Windows Server host does; Framework‑based images are a Windows container story.
- **Practical options:** use the **CI artifact** on a Windows environment, use a **short‑lived Windows VM** in the cloud if you need an interactive shell, or keep validation **CI‑only** until you have Windows access.

## Intentional legacy patterns (for assessors and tooling)

Run **`upgrade-assistant analyze`** or your preferred modernization analyzer against **`DemoApp.sln`**. The codebase **deliberately** mixes patterns that migration tools flag when moving toward .NET (Core / 5+ / 8+).

### Included on purpose

| Pattern | Where to look |
|---------|----------------|
| Legacy non‑SDK csproj + `packages.config` | `src/DemoApp.Legacy.ClassicLib/` |
| `BinaryFormatter` | `src/DemoApp.Legacy.ClassicLib/BinaryFormatterProbe.cs` |
| `System.Web.Http` / Web API 2 (`ApiController`) | `src/DemoApp.Legacy.ApiHost/OrdersController.cs` |
| `WebClient` | `src/DemoApp.Legacy.Infrastructure/WebCatalogClient.cs` |
| EF6 `DbContext` | `src/DemoApp.Legacy.Data/LegacyCatalogContext.cs` |
| `ConfigurationManager` / `appSettings` | `src/DemoApp.Legacy.ApiHost/Program.cs`, `App.config` |
| Binding redirects + `connectionStrings` | `src/DemoApp.Legacy.ApiHost/App.config` |
| Newtonsoft.Json (not `System.Text.Json`) | `src/DemoApp.Shared/OrderJson.cs` |

### Not in this repo (avoid false expectations)

- WCF service host, .NET Remoting, explicit AppDomains — **omitted** so assessors do not hunt for blockers that were never added.

### Mixed baseline

- **`DemoApp.Legacy.ClassicLib`** is the **“left behind”** project (non‑SDK + `packages.config`).
- **Other projects** are already SDK‑style with `PackageReference`, so analysis output will look **mixed**, like many real solutions mid‑rollout.
- **Not modeled here:** a pinned .NET 8 SDK (`global.json`), multitargeting (`net472` + `net8.0`), a Kestrel host, or post‑migration validation — this tree stays a **single .NET Framework stack** on purpose.

Attach analyzer output to issues or migration notes when using this repo as a teaching or test fixture.
