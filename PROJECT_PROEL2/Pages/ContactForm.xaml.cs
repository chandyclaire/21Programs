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
			Email = entry_Email.Text,
			Message = entry_Message.Text,
			Name = entry_Name.Text,
			Phone = entry_Phone.Text,
		};
			
    }
}
public class Contact
{
    public string Email { get; set; }
    public string Message { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
}