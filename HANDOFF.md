# REDSHIFT BlueStacks — handoff

## Implemented
- .NET 8 WPF application with REDSHIFT dark/crimson UI and navigation.
- Dashboard, BlueStacks discovery/launch, profile persistence and diagnostics.
- ADB integration for device/package listing, APK install, package uninstall, Android reboot and file push/pull.
- Six Standoff 2 display profiles with device selection, Android size/DPI application, captured prior state and restore.
- BlueStacks window discovery and independent 4:3 window resizing. This changes window dimensions; it cannot guarantee image stretching in every BlueStacks mode.
- Gaming Center package search, launch and persisted favorites.
- CPU/RAM monitoring, safe resource recommendations, draggable overlay with session time/RAM.
- Keymap editing and persistence (manual import/apply in BlueStacks is not implemented).
- Network ping, diagnostics report export, settings backup/restore, profile import/export.
- GitHub Actions workflow publishes self-contained win-x64 artifact.

## Latest GitHub Actions fix
The failed Actions run `45942047524` reported `OverlaySettings` missing in `Core.cs` and WPF warnings for fields named `Title`/`Content`.
- Added `using Redshift.Services;` to `Core.cs`.
- Renamed named XAML fields to `PageTitle` and `PageContent`.
- Updated all `MainWindow.xaml.cs` references to the new names.

## Validation and limitations
- Local static smoke test passed before applying the same fixes to GitHub.
- No .NET SDK is installed in this environment, so compilation has not yet been verified after the patch.
- BlueStacks is not installed/detected here; ADB and emulator runtime actions remain untested.
- FPS/GPU telemetry, graphical renderer selection, guaranteed stretched-image mode, BlueStacks keymap import, official multi-instance creation and updater UI/install are not implemented or verified.

## Build
Push/merge the fix, then check GitHub Actions workflow `Build REDSHIFT Windows`. Download `REDSHIFT-BlueStacks-win-x64` from the run's Artifacts when it succeeds. Build uses Windows runner, .NET 8, smoke test, then self-contained publish.
