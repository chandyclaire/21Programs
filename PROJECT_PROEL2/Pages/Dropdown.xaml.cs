namespace PROJECT_PROEL2;

public partial class Dropdown : ContentPage
{
	public Dropdown()
	{
		InitializeComponent();
        colorPicker.SelectedIndex = 0;

        var selectedColor = (string)colorPicker.SelectedItem;
        UpdateColor(selectedColor);
    }
    private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;

        if (picker.SelectedIndex == -1)
            return;

        string selectedColor = (string)picker.SelectedItem;
        UpdateColor(selectedColor);
    }
    private void UpdateColor(string selectedColor)
    {
        selectedColorLabel.Text = $"Your favorite color is: {selectedColor}";

        Color bgColor = selectedColor.ToLower() switch
        {
            "red" => Colors.Red,
            "green" => Colors.Green,
            "blue" => Colors.Blue,
            "yellow" => Colors.Yellow,
            "purple" => Colors.Purple,
            _ => Colors.White,
        };

        this.BackgroundColor = bgColor;
        selectedColorLabel.TextColor = bgColor;
    }
}




