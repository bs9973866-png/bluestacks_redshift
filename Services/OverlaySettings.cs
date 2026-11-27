namespace Redshift.Services;
public sealed record OverlaySettings(bool Enabled=true,bool ShowFps=true,bool ShowFrameTime=true,bool ShowCpu=true,bool ShowRam=true,double Opacity=0.85,int X=20,int Y=20,double Scale=1.0);
public static class OverlayValidator { public static string Validate(OverlaySettings s)=>s.Opacity is <0.1 or >1?"Opacity must be between 0.1 and 1":s.X<0||s.Y<0?"Position cannot be negative":s.Scale is <0.6 or >2.0?"Scale must be between 0.6 and 2.0":"Overlay settings valid"; }
