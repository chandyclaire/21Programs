namespace PROJECT_PROEL2;

public partial class RegistrationForm : ContentPage
{
	public RegistrationForm()
	{
		InitializeComponent();
	}

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(PasswordEntry.Text) || string.IsNullOrWhiteSpace(ConfirmPasswordEntry.Text))
        {
            await DisplayAlert("Error", "Please enter and confirm your password.", "OK");
            return;
        }

        if (PasswordEntry.Text != ConfirmPasswordEntry.Text)
        {
            await DisplayAlert("Error", "Passwords do not match.", "OK");
            return;
        }

        await DisplayAlert("Success", "Registration complete!", "OK");
    }

}