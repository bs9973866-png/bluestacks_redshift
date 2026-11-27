$ErrorActionPreference='Stop'
$required=@('REDSHIFT.csproj','App.xaml','MainWindow.xaml','MainWindow.xaml.cs','Core.cs','Models.cs','HANDOFF.md')
foreach($f in $required){if(-not(Test-Path (Join-Path $PSScriptRoot $f))){throw "Missing $f"}}
foreach($f in @('Services/Contracts.cs','Services/AdbClient.cs','Services/ResolutionEngine.cs','Services/BackupService.cs')){if(-not(Test-Path (Join-Path $PSScriptRoot $f))){throw "Missing service $f"}}
if(-not(Test-Path (Join-Path $PSScriptRoot 'Services/AndroidManager.cs'))){throw 'Missing Android manager'}
if(-not(Test-Path (Join-Path $PSScriptRoot 'Services/GameLibrary.cs'))){throw 'Missing game library'}
foreach($f in @('Services/Keymapping.cs','Services/OverlaySettings.cs')){if(-not(Test-Path (Join-Path $PSScriptRoot $f))){throw "Missing gameplay service $f"}}
if(-not(Test-Path (Join-Path $PSScriptRoot 'Services/MultiInstanceManager.cs'))){throw 'Missing multi-instance manager'}
if(-not(Test-Path (Join-Path $PSScriptRoot 'Services/DiagnosticsService.cs'))){throw 'Missing diagnostics service'}
foreach($f in @('DevicePicker.xaml','DevicePicker.xaml.cs')){if(-not(Test-Path (Join-Path $PSScriptRoot $f))){throw "Missing Android device picker $f"}}
foreach($f in @('OverlayWindow.xaml','OverlayWindow.xaml.cs')){if(-not(Test-Path (Join-Path $PSScriptRoot $f))){throw "Missing overlay window $f"}}
foreach($f in @('TextInputDialog.xaml','TextInputDialog.xaml.cs')){if(-not(Test-Path (Join-Path $PSScriptRoot $f))){throw "Missing input dialog $f"}}
if(-not(Test-Path (Join-Path $PSScriptRoot 'Services/NetworkMonitor.cs'))){throw 'Missing network monitor'}
if(-not(Test-Path (Join-Path $PSScriptRoot 'Services/UpdaterService.cs'))){throw 'Missing updater service'}
if(-not(Test-Path (Join-Path $PSScriptRoot 'Services/WindowScaler.cs'))){throw 'Missing window scaler'}
if(-not(Test-Path (Join-Path $PSScriptRoot 'Services/PerformanceMonitor.cs'))){throw 'Missing performance monitor'}
if(-not(Test-Path (Join-Path $PSScriptRoot 'Services/SmartBooster.cs'))){throw 'Missing smart booster'}
if(-not(Test-Path (Join-Path $PSScriptRoot 'Services/AutoProfileService.cs'))){throw 'Missing auto profile service'}
if(-not(Test-Path (Join-Path $PSScriptRoot 'Services/ProfileCatalog.cs'))){throw 'Missing profile catalog'}
if(-not(Test-Path (Join-Path $PSScriptRoot '.github/workflows/build-windows.yml'))){throw 'Missing GitHub build workflow'}
$core=Get-Content (Join-Path $PSScriptRoot 'Core.cs') -Raw
$android=Get-Content (Join-Path $PSScriptRoot 'Services/AndroidManager.cs') -Raw
$ui=Get-Content (Join-Path $PSScriptRoot 'MainWindow.xaml.cs') -Raw
$xaml=Get-Content (Join-Path $PSScriptRoot 'MainWindow.xaml') -Raw
foreach($token in @('ValidateProfile','ValidateScaling','RunAdbAsync','BackupAsync')){if($core -notmatch [regex]::Escape($token)){throw "Missing Core feature: $token"}}
foreach($token in @('Launch','Stop','Diagnostics','Resolution')){if($ui -notmatch [regex]::Escape($token)){throw "Missing UI feature: $token"}}
foreach($token in @('InstallApkAsync','PushFileAsync','PullFileAsync')){if($android -notmatch [regex]::Escape($token)){throw "Missing Android feature: $token"}}
foreach($token in @('Gaming','Standoff','Performance','Resolution','Android','Keymapping','Overlay','Instances','Network','Diagnostics','Settings')){$pattern='Click="'+$token+'"';if($xaml -notmatch [regex]::Escape($pattern) -or $ui -notmatch ('\b'+$token+'\(')){throw "Navigation event not wired: $token"}}
foreach($f in Get-ChildItem (Join-Path $PSScriptRoot 'Services') -Filter '*.cs'){if((Get-Content $f.FullName -Raw).Trim().Length -eq 0){throw "Empty service file: $($f.Name)"}}
Write-Output 'REDSHIFT smoke test PASS (static checks)'
