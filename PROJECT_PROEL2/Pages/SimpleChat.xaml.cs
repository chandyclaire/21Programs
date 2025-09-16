using System.Collections.ObjectModel;

namespace PROJECT_PROEL2;

public partial class SimpleChat : ContentPage
{
	public ObservableCollection<string> Chats { get; set; } = new();

	public SimpleChat()
	{
		InitializeComponent();
        BindingContext = this;
	}

    private void OnSendClicked(object sender, EventArgs e)
    {
		if (!string.IsNullOrWhiteSpace(MessageEntry.Text))
        {
            Chats.Add($"{DateTime.Now.ToShortTimeString()}: {MessageEntry.Text}");

            MessageEntry.Text = string.Empty;
        }
    }
}

public class ChatMessage
{
    public string Sender { get; set; }
    public string Message { get; set; }
}
