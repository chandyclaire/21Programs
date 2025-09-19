namespace PROJECT_PROEL2;

public partial class SimpleLoginForm : ContentPage
{
	public SimpleLoginForm()
	{
		InitializeComponent();
	}

    private void OnLoginClicked(object sender, EventArgs e)
    {
        string username = UsernameEntry.Text;
        string password = PasswordEntry.Text;

        if (username == "chandyclaire" && password == "chandy")
        {
            DisplayAlert("Login Success", $"Welcome{username}!","OK");
            UsernameEntry.Text = string.Empty;
            PasswordEntry.Text = string.Empty;
        }
        else
        {
            ResultLabel.TextColor = Colors.Red;
            ResultLabel.Text = "Invalid credentials.";
        }

    }
}