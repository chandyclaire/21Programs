namespace PROJECT_PROEL2;

public partial class Dropdown : ContentPage
{
	public Dropdown()
	{
		InitializeComponent();
    }
    private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;

        if (picker.SelectedIndex == -1)
            return;

        string selectedColor = (string)picker.SelectedItem;
        selectedColorLabel.Text = $"Your favorite color is: {selectedColor}";

        // Set background color based on selection
        switch (selectedColor.ToLower())
        {
            case "red":
                this.BackgroundColor = Colors.Red;
                break;
            case "green":
                this.BackgroundColor = Colors.Green;
                break;
            case "blue":
                this.BackgroundColor = Colors.Blue;
                break;
            case "yellow":
                this.BackgroundColor = Colors.Yellow;
                break;
            case "purple":
                this.BackgroundColor = Colors.Purple;
                break;
            default:
                this.BackgroundColor = Colors.White;
                break;
        }
    }

}


