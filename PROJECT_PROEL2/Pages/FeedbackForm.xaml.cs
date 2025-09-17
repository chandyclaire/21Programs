namespace PROJECT_PROEL2;

public partial class FeedbackForm : ContentPage
{
	public FeedbackForm()
	{
		InitializeComponent();
	}

    private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
    {
        double roundedValue = Math.Round(e.NewValue);
        ratingSlider.Value = roundedValue;
    }

    private void OnSubmitClicked(object sender, EventArgs e)
    {
        feedbackEditor.IsVisible = false;
        ratingSlider.IsVisible = false;

        
        feedbackSubmittedMessage.IsVisible = true;

        backButton.IsVisible = true;

        submitButton.IsVisible = false;
    }

    private void OnBackClicked(object sender, EventArgs e)
    {
       
        feedbackSubmittedMessage.IsVisible = false;
        backButton.IsVisible = false;

        feedbackEditor.IsVisible = true;
        ratingSlider.IsVisible = true;

        feedbackEditor.Text = string.Empty;
        ratingSlider.Value = 5;
        submitButton.IsVisible = true;
    }
}