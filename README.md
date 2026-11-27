# REDSHIFT BlueStacks

Локальная Windows-оболочка для управления BlueStacks через поддерживаемые интерфейсы.

## Запуск

Требуется Windows 10/11 x64 и .NET 8 Desktop Runtime для framework-dependent сборки. Для сборки из исходников требуется .NET 8 SDK:

```powershell
.\run.ps1
```

## Сборка на GitHub

Репозиторий автоматически собирается workflow `Build REDSHIFT Windows` на Windows runner. Для ручной локальной сборки нужен .NET 8 SDK:

```powershell
dotnet restore REDSHIFT.csproj
dotnet build REDSHIFT.csproj -c Release
dotnet publish REDSHIFT.csproj -c Release -r win-x64 --self-contained false -o publish
```

Готовые файлы появляются в артефакте GitHub Actions `REDSHIFT-BlueStacks-win-x64`. Для self-contained EXE замени `--self-contained false` на `--self-contained true`.

В GitHub Actions workflow запускается на push, pull request и вручную. После завершения открой Actions → последний запуск → Artifacts и скачай `REDSHIFT-BlueStacks-win-x64`. Запускай `REDSHIFT.exe` из распакованной папки.

## Что уже подключено

- Dashboard с обнаружением и запуском BlueStacks.
- ADB: список устройств и пакетов, установка APK, удаление пакета, перезапуск Android, передача файлов.
- Standoff 2: шесть профилей, применение Android-размера/DPI, сохранение прежних значений и восстановление.
- Окно BlueStacks: отдельное изменение размера окна для 4:3.
- Gaming Center: поиск пакетов, запуск и избранное.
- Performance: CPU/RAM процессов BlueStacks и системные рекомендации; FPS не подменяется установленным лимитом.
- Overlay: поверхностное окно, таймер, RAM, прозрачность и масштаб.
- Профили управления, сетевой ping, диагностика, резервные копии, импорт/экспорт профилей.

## Ограничения

- Реальное растягивание картинки внутри окна может зависеть от версии и режима отображения BlueStacks; изменение размера окна само по себе не гарантирует несохранение пропорций изображения.
- Применение Android-размера работает через `adb shell wm size/density`, если выбранное устройство и сборка BlueStacks разрешают эти команды.
- FPS, GPU, графические API, импорт keymap в BlueStacks и создание экземпляров через Multi-Instance Manager ещё не подтверждены реальным BlueStacks.
- Updater пока содержит проверку HTTPS, версии и SHA-256 как сервисные функции; UI обновления и безопасная установка пакета не подключены.
- Перед первым запуском настройки ADB в Settings укажи путь к `adb.exe`, если он не доступен через PATH.

Приложение не изменяет закрытые компоненты BlueStacks и не завершает пользовательские процессы. Если BlueStacks или ADB недоступны, интерфейс показывает это явно.
