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
        if (e.Key != Key.Return || string.IsNullOrWhiteSpace(MessageInput.Text)) return;

        // Remove leading white spaces
        var trimmedMessage = MessageInput.Text.TrimStart();

        // Add a new line every 80 characters
        const int maxCharactersPerLine = 80;
        var formattedMessage = new StringBuilder();
        for (var i = 0; i < trimmedMessage.Length; i += maxCharactersPerLine)
        {
            var charactersToTake = Math.Min(maxCharactersPerLine, trimmedMessage.Length - i);
            formattedMessage.AppendLine(trimmedMessage.Substring(i, charactersToTake));
        }

        Messages.Items.Add("You: " + formattedMessage.ToString());
        MessageInput.Clear();

        Chat.ScrollToBottom();
    }


    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        Messages.Items.Add("Sender: New Message");
    }
}