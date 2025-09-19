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

        if (string.IsNullOrWhiteSpace(entry_Name.Text) ||
            string.IsNullOrWhiteSpace(entry_Email.Text) ||
            string.IsNullOrWhiteSpace(entry_Phone.Text) ||
            string.IsNullOrWhiteSpace(entry_Message.Text))
        {
            DisplayAlert("Missing Information", "Please fill in all fields.", "OK");
            return;
        }

        var validator = new EmailAddressAttribute();
        if (!validator.IsValid(entry_Email.Text.Trim()))
        {
            DisplayAlert("Invalid Email", "Error: email is invalid", "OK");
            return;
        }

        Contact currentContact = new Contact()
        {
            Email = entry_Email.Text.Trim(),
            Message = entry_Message.Text.Trim(),
            Name = entry_Name.Text.Trim(),
            Phone = entry_Phone.Text.Trim(),
        };

        entry_Email.Text = "";
        entry_Message.Text = "";
        entry_Name.Text = "";
        entry_Phone.Text = "";

        string message = $"Name: {currentContact.Name}\n" +
                         $"Email: {currentContact.Email}\n" +
                         $"Phone: {currentContact.Phone}\n" +
                         $"Message: {currentContact.Message}";

        DisplayAlert("Details", message, "OK");
    }	
}
public   class Contact
{
    public string Email { get; set; }
    public string Message { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
}