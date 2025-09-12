namespace PROJECT_PROEL2;

public partial class RegistrationForm : ContentPage
{
	public RegistrationForm()
	{
		InitializeComponent();
	}

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        if (PasswordEntry.Text != ConfirmPasswordEntry.Text)
        {
            await DisplayAlert("Error", "Passwords do not match.", "OK");
        }
        else
        {
            
            await DisplayAlert("Success", "Registration complete!", "OK");
        }
    }

}