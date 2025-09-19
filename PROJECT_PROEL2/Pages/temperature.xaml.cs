namespace PROJECT_PROEL2;

public partial class temperature : ContentPage
{
    public temperature()
    {
        InitializeComponent();
    }
    private void OnConvertClicked(object sender, EventArgs e)
    {
        if (double.TryParse(InputEntry.Text, out double inputTemp))
        {
 
            string conversionType = ConversionPicker.SelectedItem?.ToString();
            double result = 0;

            if (conversionType == "Celcius to Fahrenheit")
            {
                result = (inputTemp * 9 / 5) + 32;
                ResultLabel.Text = $"{inputTemp} °C = {result:F2} °F";
            }
            else if (conversionType == "Fahrenheit to Celcius")
            {
                result = (inputTemp - 32) * 5 / 9;
                ResultLabel.Text = $"{inputTemp} °F = {result:F2} °C";
            }
            else
            {
                ResultLabel.Text = "Please select a conversion type.";
            }
        }
        else
        {
            ResultLabel.Text = "Invalid input. Please enter a number.";
        }
    }

}