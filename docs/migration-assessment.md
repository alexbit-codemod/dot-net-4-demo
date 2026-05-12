# Step 3 — modernization assessment (inventory)

**Demo App** — sample .NET Framework codebase for modernization tooling exercises.

Run `upgrade-assistant analyze` (or Visual Studio modernization) against `DemoApp.sln`.

This repository is **.NET Framework only** (`net472`). It intentionally contains patterns that modernization tools typically flag before a move to .NET (Core / 5+ / 8+).

## Intentional patterns in this repo

| Blocker / pattern | Where |
|-------------------|--------|
| Legacy non-SDK csproj + `packages.config` | `src/DemoApp.Legacy.ClassicLib/` |
| `BinaryFormatter` | `BinaryFormatterProbe.cs` |
| `System.Web.Http` / Web API 2 (`ApiController`) | `src/DemoApp.Legacy.ApiHost/OrdersController.cs` |
| `WebClient` | `src/DemoApp.Legacy.Infrastructure/WebCatalogClient.cs` |
| EF6 `DbContext` | `src/DemoApp.Legacy.Data/LegacyCatalogContext.cs` |
| `ConfigurationManager` / `appSettings` | `src/DemoApp.Legacy.ApiHost/Program.cs`, `App.config` |
| Binding redirects + `connectionStrings` | `src/DemoApp.Legacy.ApiHost/App.config` |
| Newtonsoft.Json (not `System.Text.Json`) | `DemoApp.Shared/OrderJson.cs` |

## Not present (no false positives)

- WCF service host, .NET Remoting, explicit AppDomains — listed here for assessor expectations only.

## Mapping: guide steps → repo (legacy baseline)

| Step | Artifact |
|------|-----------|
| 1 | `.github/workflows/ci.yml` |
| 2 | *(not applicable — no `global.json` / .NET 8 SDK pin in this baseline)* |
| 3 | This file + assessor output (attach to work items) |
| 4–5 | Mixed: ClassicLib = “before”; other projects already SDK + `PackageReference` |
| 6 | *(not applicable — no multi-target / `net8.0`)* |
| 7 | *(not applicable — no `IAppSettings` abstraction layer; direct `ConfigurationManager` in host)* |

Steps 8–15 describe introducing and validating a modern host; this repo stops at a **single .NET Framework stack** on purpose.
