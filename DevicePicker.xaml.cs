using System.Windows;
namespace Redshift;
public partial class DevicePicker:Window {
 public string? SelectedDevice=>Devices.SelectedItem as string;
 public DevicePicker(IEnumerable<string> devices){InitializeComponent();Devices.ItemsSource=devices.ToArray();Devices.SelectedIndex=0;}
 void Select_Click(object sender,RoutedEventArgs e){if(SelectedDevice==null)return;DialogResult=true;}
}
