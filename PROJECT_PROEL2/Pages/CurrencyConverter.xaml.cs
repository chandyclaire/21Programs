namespace PROJECT_PROEL2;

public partial class CurrencyConverter : ContentPage
{
	public CurrencyConverter()
	{
		InitializeComponent();
	}

    private void ConvertCurrency_Click(object sender, EventArgs e)
    {
		if (FromCurrency.SelectedIndex == -1 || ToCurrency.SelectedIndex == -1)
		{
            DisplayAlert("Convertion", "Please select a value to convert", "Okay");
        }
        int amount = int.Parse(entry_Amount.Text); 

		string from = FromCurrency.Items[FromCurrency.SelectedIndex];
		string to = ToCurrency.Items[ToCurrency.SelectedIndex];

		double toUSD = from switch
		{
			"PHP" => 0.018 * amount,
			"EUR" => 1.18 * amount,
			"GBP" => 1.36 * amount,
			"JPY" => 0.0068 * amount,
			"RMB" => 0.14 * amount,
			_ => amount 
		};

		double fromUSD = to switch
		{
			"PHP" => toUSD / 0.018,
			"EUR" => toUSD / 1.18,
			"GBP" => toUSD / 1.36,
			"JPY" => toUSD / 0.0068,
			"RMB" => toUSD / 0.14,
			_ => toUSD
		};

		DisplayAlert("Convertion", $"{from} to {to}: {Math.Round(fromUSD, 2).ToString("N2")}", "Okay");
    }
}