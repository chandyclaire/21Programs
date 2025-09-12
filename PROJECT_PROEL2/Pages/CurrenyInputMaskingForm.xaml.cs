using System.Globalization;

namespace PROJECT_PROEL2;

public partial class CurrenyInputMaskingForm : ContentPage
{
    private readonly List<string> currencies = new() { "USD", "EUR", "JPY", "PHP" };

    public CurrenyInputMaskingForm()
	{
		InitializeComponent();

        currencyPicker.ItemsSource = currencies;
        currencyPicker.SelectedIndex = 1; // Default to USD
        currencyPicker.SelectedIndexChanged += OnCurrencyChanged;

    }

    private void OnCurrencyChanged(object sender, EventArgs e)
    {
        UpdateFormattedAmount();
    }

    private void OnAmountChanged(object sender, TextChangedEventArgs e)
    {
        UpdateFormattedAmount();
    }

    private void UpdateFormattedAmount()
    {
        if (currencyPicker.SelectedItem == null || string.IsNullOrWhiteSpace(amountEntry.Text))
        {
            resultLabel.Text = string.Empty;
            return;
        }

        if (decimal.TryParse(amountEntry.Text, out decimal amount))
        {
            string currencyCode = currencyPicker.SelectedItem.ToString();

            // Pick culture based on selected currency
            var culture = currencyCode switch
            {
                "USD" => new CultureInfo("en-US"),  // US Dollar
                "EUR" => new CultureInfo("fr-FR"),  // Euro
                "JPY" => new CultureInfo("ja-JP"),  // Yen
                "PHP" => new CultureInfo("en-PH"),  // Philippine Peso
                _ => CultureInfo.InvariantCulture
            };

            // Format currency live
            resultLabel.Text = string.Format(culture, "{0:C}", amount);
        }
        else
        {
            resultLabel.Text = "Invalid input!";
        }
    }

}