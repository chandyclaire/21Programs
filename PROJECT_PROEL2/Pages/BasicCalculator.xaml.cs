namespace PROJECT_PROEL2.Pages;

public partial class BasicCalculator : ContentPage
{
    private Entry ?_focusedEntry;

    public BasicCalculator()
	{
		InitializeComponent();

        Entry1.Focused += (s, e) => _focusedEntry = Entry1;
        Entry2.Focused += (s, e) => _focusedEntry = Entry2;
    }

    private void OnDigitClicked(object sender, EventArgs e)
    {
        if (sender is Button button && _focusedEntry != null)
        {
            _focusedEntry.Text += button.Text;
        }
    }

    private bool TryGetInputs(out double num1, out double num2)
    {
        bool isValid1 = double.TryParse(Entry1.Text, out num1);
        bool isValid2 = double.TryParse(Entry2.Text, out num2);

        return isValid1 && isValid2;
    }

    private async void OnAddClicked(object sender, EventArgs e)
    {
        if (TryGetInputs(out double a, out double b))
        {
            await DisplayAlert("Result", $"Result: {a + b}", "OK");
            ClearEntries();
        }
        else
        {
            await DisplayAlert("Invalid Input", "Please enter valid numbers.", "OK");
            ClearEntries();
        }
    }

    private async void OnSubtractClicked(object sender, EventArgs e)
    {
        if (TryGetInputs(out double a, out double b))
        {
            await DisplayAlert("Result", $"Result: {a - b}", "OK");
            ClearEntries();
        }
        else
        {
            await DisplayAlert("Invalid Input", "Please enter valid numbers.", "OK");
            ClearEntries();
        }
    }

    private async void OnMultiplyClicked(object sender, EventArgs e)
    {
        if (TryGetInputs(out double a, out double b))
        {
            await DisplayAlert("Result", $"Result: {a * b}", "OK");
            ClearEntries();
        }
        else
        {
            await DisplayAlert("Invalid Input", "Please enter valid numbers.", "OK");
            ClearEntries();
        }
    }

    private async void OnDivideClicked(object sender, EventArgs e)
    {
        if (TryGetInputs(out double a, out double b))
        {
            if (b == 0)
            {
                await DisplayAlert("Error", "Cannot divide by zero.", "OK");
                ClearEntries();
            }
            else
            {
                await DisplayAlert("Result", $"Result: {a / b}", "OK");
                ClearEntries();
            }
        }
        else
        {
            await DisplayAlert("Invalid Input", "Please enter valid numbers.", "OK");
            ClearEntries();
        }
    }

    private void ClearEntries()
    {
        Entry1.Text = string.Empty;
        Entry2.Text = string.Empty;
    }

}