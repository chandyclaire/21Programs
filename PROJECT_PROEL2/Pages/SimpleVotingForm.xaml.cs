namespace PROJECT_PROEL2;

public partial class SimpleVotingForm : ContentPage
{
    private int option1Votes = 0;
    private int option2Votes = 0;
    private int option3Votes = 0;
    private int totalVotes = 0;

    public SimpleVotingForm()
	{
		InitializeComponent();
	}

    private void OnVoteButtonClicked(object sender, EventArgs e)
    {
        if (Option1RadioButton.IsChecked)
        {
            option1Votes++;
        }
        else if (Option2RadioButton.IsChecked)
        {
            option2Votes++;
        }
        else if (Option3RadioButton.IsChecked)
        {
            option3Votes++;
        }

        totalVotes++;

        double option1Percentage = (option1Votes / (double)totalVotes) * 100;
        double option2Percentage = (option2Votes / (double)totalVotes) * 100;
        double option3Percentage = (option3Votes / (double)totalVotes) * 100;



        Option1Result.Text = $"{Option1RadioButton.Content}: {option1Percentage:F2}%";
        Option2Result.Text = $"{Option2RadioButton.Content}: {option2Percentage:F2}%";
        Option3Result.Text = $"{Option3RadioButton.Content}: {option3Percentage:F2}%";
    }
}