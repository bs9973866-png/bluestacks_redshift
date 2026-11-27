using System.Windows;
namespace Redshift;
public partial class TextInputDialog:Window {
 public string Value=>Input.Text.Trim();
 public TextInputDialog(string prompt){InitializeComponent();Prompt.Text=prompt;}
 void Continue_Click(object sender,RoutedEventArgs e){if(string.IsNullOrWhiteSpace(Value))return;DialogResult=true;}
}
