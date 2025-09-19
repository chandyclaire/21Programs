namespace PROJECT_PROEL2;

public partial class DatePickerForm : ContentPage
{
	public DatePickerForm()
	{
		InitializeComponent();

        DatePicker.Date = DateTime.Today;
        UpdateLabel(DatePicker.Date);
    }

    private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
    {
        UpdateLabel(e.NewDate);
    }

    private void UpdateLabel(DateTime date)
    {

        SelectDateLabel.Text = $"Selected date: {date:dddd, MMMM dd, yyyy}";
    }
}