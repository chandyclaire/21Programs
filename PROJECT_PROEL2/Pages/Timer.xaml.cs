using System.Timers;

namespace PROJECT_PROEL2;

public partial class Timer : ContentPage
{

    private int remainingSeconds;
    private System.Timers.Timer countdownTimer;
    public Timer()
	{
		InitializeComponent();
	}

    private void OnStartClicked(object sender, EventArgs e)
    {
        if (int.TryParse(SecondsEntry.Text, out int seconds) && seconds > 0)
        {
            remainingSeconds = seconds;

            TimerLabel.Text = $"Time left: {remainingSeconds}";

            countdownTimer?.Stop();
            countdownTimer?.Dispose();

            countdownTimer = new System.Timers.Timer(1000);
            countdownTimer.Elapsed += OnTimerElapsed;
            countdownTimer.Start();
        }
        else
        {
            TimerLabel.Text = "Please enter a valid number.";
        }
    }

    private void OnTimerElapsed(object sender, ElapsedEventArgs e)
    {
        remainingSeconds--;

        // Update UI from main thread
        MainThread.BeginInvokeOnMainThread(() =>
        {
            TimerLabel.Text = $"Time left: {remainingSeconds}";

            if (remainingSeconds <= 0)
            {
                countdownTimer.Stop();
                TimerLabel.Text = "? Timefs up!";
            }
        });
    }
}