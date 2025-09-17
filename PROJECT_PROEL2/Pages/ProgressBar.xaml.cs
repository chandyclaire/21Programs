using System.Threading.Tasks;

namespace PROJECT_PROEL2;

public partial class ProgressBar : ContentPage
{
	public ProgressBar()
	{
		InitializeComponent();
	}

    private async void ProgressBar_Click(object sender, EventArgs e)
    {
		// Reset
		progressBar.Progress = 0;
        progressBar.ProgressColor = Colors.Red;

		bool success = await RunProgress();

		if (success)
		{
			progressBar.ProgressColor = Colors.Green;
		}
		else
		{
			progressBar.ProgressColor = Colors.Red;
		}
    }

	private async Task<bool> RunProgress()
	{
		await progressBar.ProgressTo(1, 5000, Easing.CubicIn);

		return true;
	}
}