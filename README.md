# Demo App

Small **.NET Framework 4.7.2** sample (OWIN / Web API 2) used for modernization exercises.

## I don’t have Windows — what now?

The downloadable **`DemoApp.Legacy.ApiHost.exe`** is **.NET Framework**. That runtime **does not exist on macOS** (and Linux Docker on your Mac can’t run Framework apps either). So “unzip on Windows” really means: **some Windows environment**, not necessarily a PC you own.

**Practical options:**

1. **Cloud Windows VM (most common fix)**  
   Spin up a small **Windows Server** or **Windows 11** VM, use **Remote Desktop** from your Mac, then unzip the GitHub artifact (or clone the repo and `dotnet run` there).  
   Examples: **[Azure Virtual Machines](https://azure.microsoft.com/products/virtual-machines/windows/)** (Windows Server image), **[Amazon EC2 Windows](https://aws.amazon.com/windows/)**, **[Google Compute Engine Windows](https://cloud.google.com/compute/docs/instances/windows)**. You typically pay **per hour** when it’s on; turn the VM off when you’re done.

2. **GitHub Actions only (build + test, no “run on my Mac”)**  
   Pushing to GitHub still **builds and tests** on Microsoft’s **Windows** runners. That proves the project is healthy; it does **not** give you a local URL on your Mac for this Framework host.

3. **If you must run the API on your Mac with no Windows ever**  
   You’d need a **.NET (Core / 8+)** version of the host (Kestrel), not .NET Framework. This repo is intentionally Framework-only; adding or switching to a modern host is a separate change.

**TL;DR:** With **no Windows at all**, borrow it from the **cloud for an hour**, or accept **CI-only** validation until you do.

---

## GitHub Actions: build, test, and get a Windows `.exe`

1. Push this repo to GitHub.
2. **Actions** → **demo-app-ci** → wait for green (or **Run workflow**).
3. **Artifacts** → **`build-artifacts`** → download the zip.
4. On **any Windows machine or cloud Windows VM**, unzip → **`api-host`** → run **`DemoApp.Legacy.ApiHost.exe`**.  
   Install **[.NET Framework 4.7.2 runtime](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net472)** if the OS asks.
5. Open **`http://localhost:8088/api/orders/1`** (default in `App.config`).

---

## All-in-one on a Windows box

From the repo root:

```powershell
dotnet restore DemoApp.sln
dotnet build DemoApp.sln -c Release
dotnet test DemoApp.sln -c Release
dotnet run --project src\DemoApp.Legacy.ApiHost\DemoApp.Legacy.ApiHost.csproj -c Release
```

---

## Why not Docker on Mac?

This project targets **.NET Framework**. Official Framework images are **Windows containers**; **Docker Desktop on Mac cannot run those**. CI uses **Windows** so you don’t need local Framework tooling to **build/test in the cloud**.

See `docs/migration-assessment.md` for intentional legacy patterns in the code.
