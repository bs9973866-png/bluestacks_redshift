using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using Redshift.Services;
namespace Redshift;
public partial class OverlayWindow:Window {
 readonly Stopwatch clock=Stopwatch.StartNew(); readonly DispatcherTimer timer=new(){Interval=TimeSpan.FromSeconds(1)};
 public OverlayWindow(){InitializeComponent();timer.Tick+=(_,_)=>Refresh();timer.Start();Refresh();}
 public void Configure(OverlaySettings s){Opacity=s.Opacity;Width=290*s.Scale;Height=150*s.Scale;Left=s.X;Top=s.Y;}
 void Refresh(){Session.Text=$"Session {clock.Elapsed:hh\\:mm\\:ss}";var ps=Process.GetProcessesByName("HD-Player");Metrics.Text=ps.Length==0?"BlueStacks not running":string.Join(" · ",ps.Select(p=>{try{return $"RAM {p.WorkingSet64/1024/1024} MB";}catch{return "RAM unavailable";}}));}
 void Drag(object sender,MouseButtonEventArgs e){try{DragMove();}catch{}}
 protected override void OnClosed(EventArgs e){timer.Stop();base.OnClosed(e);}
}
