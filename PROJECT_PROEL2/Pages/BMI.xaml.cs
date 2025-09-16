namespace PROJECT_PROEL2;

public partial class BMI : ContentPage
{
	public BMI()
	{
		InitializeComponent();
	}
    private void OnCalculateBMIClicked(object sender, EventArgs e)
    {
        if (double.TryParse(WeightEntry.Text, out double weight) &&
            double.TryParse(HeightEntry.Text, out double heightCm))
        {
            double heightM = heightCm / 100; // convert cm to meters
            double bmi = weight / (heightM * heightM);

            string category = GetBMICategory(bmi);

            ResultLabel.Text = $"Your BMI is {bmi:F1} ({category})";
        }
        else
        {
            ResultLabel.Text = "Please enter valid numbers.";
        }
    }
    private string GetBMICategory(double bmi)
    {
        if (bmi < 18.5)
            return "Underweight";
        else if (bmi < 24.9)
            return "Normal";
        else if (bmi < 29.9)
            return "Overweight";
        else
            return "Obese";
    }
}