using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
namespace Redshift.Services;
public sealed class WindowScaler {
 [DllImport("user32.dll")] static extern bool EnumWindows(EnumWindowsProc callback,nint extra);
 [DllImport("user32.dll")] static extern uint GetWindowThreadProcessId(nint hwnd,out uint processId);
 [DllImport("user32.dll")] static extern bool IsWindowVisible(nint hwnd);
 [DllImport("user32.dll")] static extern bool GetWindowRect(nint hwnd,out RECT rect);
 [DllImport("user32.dll")] static extern bool SetWindowPos(nint hwnd,nint insertAfter,int x,int y,int cx,int cy,uint flags);
 [DllImport("user32.dll",CharSet=CharSet.Unicode)] static extern int GetWindowText(nint hwnd,StringBuilder text,int max);
 delegate bool EnumWindowsProc(nint hwnd,nint extra);
 [StructLayout(LayoutKind.Sequential)] struct RECT{public int Left,Top,Right,Bottom;}
 public sealed record Target(nint Handle,int ProcessId,string Title,int X,int Y,int Width,int Height);
 public IReadOnlyList<Target> FindBlueStacksWindows(){var ids=Process.GetProcessesByName("HD-Player").Select(p=>p.Id).ToHashSet();var found=new List<Target>();EnumWindows((h,_)=>{GetWindowThreadProcessId(h,out var pid);if(!ids.Contains((int)pid)||!IsWindowVisible(h)||!GetWindowRect(h,out var r))return true;var sb=new StringBuilder(512);GetWindowText(h,sb,sb.Capacity);found.Add(new(h,(int)pid,sb.ToString(),r.Left,r.Top,r.Right-r.Left,r.Bottom-r.Top));return true;},0);return found;}
 public bool Resize(Target t,int width,int height){if(width<320||height<240)return false;return SetWindowPos(t.Handle,0,t.X,t.Y,width,height,0x0004|0x0010);}
 public bool ApplyStretched43(Target t,int height){if(height<240)return false;return Resize(t,height*4/3,height);}
}
