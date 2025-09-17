using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace PROJECT_PROEL2;

public partial class ContactForm : ContentPage
{
	public ContactForm()
	{
		InitializeComponent();
	}

    private void Continue_Click(object sender, EventArgs e)
    {

		Contact currentContact = new Contact()
		{
			Email = entry_Email.Text.Trim(),
			Message = entry_Message.Text.Trim(),
			Name = entry_Name.Text.Trim(),
			Phone = entry_Phone.Text.Trim(),
		};


		var validator = new EmailAddressAttribute();
		if (!validator.IsValid(currentContact.Email))
		{
			DisplayAlert("Invalid Email", "Error: email is invalid", "okay");
			return;
		}
		// Clear entry
		entry_Email.Text = "";
		entry_Message.Text = "";
		entry_Name.Text = "";
		entry_Phone.Text = "";

		string message = $"Name: {currentContact.Name}\n" +
			$"Email: {currentContact.Email}\n" +
			$"Phone: {currentContact.Phone}\n" +
			$"Message: {currentContact.Message}";
		DisplayAlert("Details", message, "okay");
    }	
}
public   class Contact
{
    public string Email { get; set; }
    public string Message { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
}