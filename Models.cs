namespace Redshift;
public record SystemSnapshot(double Cpu, double Ram, double DiskFreeGb, bool Bluestacks, bool Adb);
public record GameProfile(string Name, string Aspect, int Width, int Height, int Dpi, int Fps, bool Stretch);
public record ScalingSettings(string Mode, double Horizontal, double Vertical, bool Fullscreen);
