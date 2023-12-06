using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Messaging_Interface;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }



    private void MessageInput_OnKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key != Key.Return) return;
        Messages.Items.Add("You: " + MessageInput.Text);
        MessageInput.Clear();
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        Messages.Items.Add("Sender: New Message");
    }
}