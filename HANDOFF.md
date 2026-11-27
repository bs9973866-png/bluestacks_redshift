# REDSHIFT BlueStacks — handoff

## Implemented
- New .NET 8 WPF project with REDSHIFT dark/crimson design system.
- Dashboard navigation and real BlueStacks executable detection.
- Safe process launch and official ADB device check.
- Local JSON profile persistence and starter Standoff 2 profiles.
- Diagnostics for BlueStacks, ADB and free disk space.
- Separate Resolution, Performance, Android Manager and Settings screens.

## Validation
- Source files created and reviewed.
- Build not run: this machine has .NET runtimes but no .NET SDK (`dotnet --info` reports no SDKs).

## Location
- Working copy: `C:\Users\stefan\Documents\Codex\2026-11-27\new-chat-2`
- Desktop copy: `C:\Users\stefan\Desktop\REDSHIFT-BlueStacks`

## Next task
Install .NET 8 SDK, build the WPF project, fix compile issues, then add BlueStacks-specific settings discovery and profile application only through supported interfaces.

## Known limitations
- No BlueStacks installation was detected during discovery.
- Real FPS/GPU telemetry, stretched scaling, overlay, APK/file transfer and multi-instance control require a running BlueStacks/ADB environment and should not be presented as active until verified.

## Latest work
- Added configurable BlueStacks/ADB paths to persisted settings.
- Added profile export to Desktop.
- Added explicit auto-profile state to diagnostics.
- Added local backup creation and profile export actions.
- Added deterministic profile validation for aspect ratio, DPI and FPS presets.
- Added separate persisted scaling settings and Stretched 4:3 validation.
- Added real BlueStacks process-memory reporting when HD-Player is running.
- Added structured ADB device parsing and Windows/architecture diagnostics.
- Added duplicate-safe profile creation and `smoke-test.ps1` static verification.
- Added modular `Services` layer with ADB client, resolution validation, backup service, and contracts.
- Added GitHub Actions Windows build/publish workflow, `global.json`, and repository `.gitignore`.
- Added Android Manager service for package listing, APK installation, uninstall and Android reboot through ADB.
- Added Gaming Center service for package discovery and safe game launch through Android `monkey`.

## Session validation
- 10 development cycles completed in this session.
- Static smoke test: PASS.
- .NET build: BLOCKED because no .NET SDK is installed; only runtimes are present.
- GitHub build preparation: ready; workflow publishes a `win-x64` artifact.
- BlueStacks integration: executable and ADB are detected/used when configured or installed; no BlueStacks installation was present during this session, so runtime integration could not be exercised.
- Android Manager UI now supports APK install, package listing and Android restart; service supports adb push/pull.
- Added Keymapping profile persistence, Overlay settings validation, and Multi-Instance process discovery/launch service.
- Connected Keymapping Studio and Overlay validation screens to the WPF navigation.
- Added diagnostics report generation and export service.
- Added real NetworkMonitor ping sampling with reachability and latency results.
- Added HTTPS-only updater primitives with version comparison and SHA-256 verification.
- Added real BlueStacks CPU/RAM sampling through Windows Process API; FPS remains unreported unless a verified telemetry source exists.
- Added AutoProfileService to read the foreground Android package via ADB and map it to a configured profile.
- Added ProfileCatalog with six validated Standoff 2 profiles.
- Integrated Gaming Center package discovery, Standoff profile apply via adb wm size/density, instance process listing and ping UI.
- Performance screen now samples CPU/RAM per emulator process; Settings allows editing BlueStacks and ADB executable paths; Multi Instance includes launch action.
- Added settings backup restore workflow and changed ADB stream reads to concurrent reads to avoid process pipe deadlocks.
- Resolution profiles now require selecting a ready ADB device; supports restoring Android wm size/density defaults.
- Implemented always-on-top draggable overlay window with session timer and live BlueStacks process RAM; FPS remains explicitly unavailable.
- Expanded Android Manager UI with device selection, APK install, package uninstall and ADB file push/pull actions.
- Gaming Center now supports live package search, launch via ADB and persisted favorites.
- Resolution UI now exposes persisted scaling mode and horizontal scale control, ADB device selection and Android display reset.
- Added Windows WindowScaler to find visible HD-Player windows and resize the first window to 4:3 independently of Android wm size.
- Keymapping UI now edits and validates key bindings; overlay UI controls opacity/scale and configures the always-on-top window.
- Overlay appearance settings persist across launches; Standoff profile captures current wm size/density before first apply and offers restore.
- Added SmartBooster analysis and Performance UI recommendations based on host memory and emulator process count; no automatic process termination.
- Fixed display profile safety: do not apply when reading current wm state fails; now report command success/failure and validate saved restore state.
- Settings now imports profile JSON with validation and duplicate-name rejection before saving.
- Finalization pass added explicit XAML navigation smoke checks and validated named instance IDs; smoke-test quoting error was caught and fixed.

## Final status (2026-11-27)
- GitHub workflow configured to publish a self-contained win-x64 app artifact.
- Static smoke test passes.
- Local compile and runtime validation remain pending: .NET SDK and BlueStacks are not installed/detected in this environment.
- Read README.md for features that are implemented and specific unverified limitations.
