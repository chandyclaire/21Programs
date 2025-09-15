namespace PROJECT_PROEL2;

public partial class ImageSelectorForm : ContentPage
{
	public ImageSelectorForm()
	{
		InitializeComponent();
	}

    private async void OnPickImageClicked(object sender, EventArgs e)
    {
        try
        {
        
            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Pick an image",
                FileTypes = FilePickerFileType.Images
            });

            // If a file was picked, display it in the Image control
            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                SelectedImage.Source = ImageSource.FromStream(() => stream);
            }
        }
        catch (Exception ex)
        {
            // Handle error
            await DisplayAlert("Error", $"An error occurred while picking the image: {ex.Message}", "OK");
        }
    }
}