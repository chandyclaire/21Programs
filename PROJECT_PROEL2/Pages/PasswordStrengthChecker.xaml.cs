using System.Text.RegularExpressions;

namespace PROJECT_PROEL2;

public partial class PasswordStrengthChecker : ContentPage
{
    bool _isPasswordHidden = true;

    public PasswordStrengthChecker()
	{
		InitializeComponent();
	}

    private void TogglePasswordVisibility_Clicked(object sender, EventArgs e)
    {
        _isPasswordHidden = !_isPasswordHidden;
        PasswordEntry.IsPassword = _isPasswordHidden;
    }

    private void PasswordEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        var pw = e.NewTextValue ?? string.Empty;
        var (score, label) = EvaluatePassword(pw);


        // ProgressBar expects 0..1
        StrengthBar.Progress = score;


        StrengthLabel.Text = $"Strength: {label}";


        // ProgressColor uses Microsoft.Maui.Graphics.Color
        StrengthBar.ProgressColor = GetColorFromScore(score);


        AdviceLabel.Text = GetAdvice(pw, score);
    }
    private (double score, string label) EvaluatePassword(string pw)
    {
        if (string.IsNullOrEmpty(pw))
            return (0.0, "—");


        double score = 0.0;


        // Length contribution
        if (pw.Length >= 8) score += 0.25;
        if (pw.Length >= 12) score += 0.10; // bonus for longer


        // Character variety
        if (Regex.IsMatch(pw, "[a-z]")) score += 0.15;
        if (Regex.IsMatch(pw, "[A-Z]")) score += 0.15;
        if (Regex.IsMatch(pw, "[0-9]")) score += 0.15;
        if (Regex.IsMatch(pw, "[^a-zA-Z0-9]")) score += 0.10;


        // Deduct for obvious repeats / simple patterns (three identical chars in a row)
        for (int i = 0; i < pw.Length - 2; i++)
        {
            if (pw[i] == pw[i + 1] && pw[i + 1] == pw[i + 2])
            {
                score -= 0.10;
                break;
            }
        }


        // Clamp 0..1
        score = Math.Max(0, Math.Min(1, score));


        string label;
        if (score <= 0.25) label = "Very weak";
        else if (score <= 0.45) label = "Weak";
        else if (score <= 0.70) label = "Medium";
        else if (score <= 0.90) label = "Strong";
        else label = "Very strong";


        return (score, label);
    }

    private Color GetColorFromScore(double score)
    {
        if (score <= 0.25) return Colors.Red;
        if (score <= 0.45) return Colors.OrangeRed;
        if (score <= 0.70) return Colors.Orange;
        if (score <= 0.90) return Colors.YellowGreen;
        return Colors.Green;
    }

    private string GetAdvice(string pw, double score)
    {
        if (string.IsNullOrEmpty(pw))
            return "Tip: Use a mix of uppercase, lowercase, numbers and symbols. Min 8 characters.";


        if (pw.Length < 8)
            return "Make it at least 8 characters long.";


        if (!Regex.IsMatch(pw, "[A-Z]"))
            return "Add uppercase letters (A–Z).";


        if (!Regex.IsMatch(pw, "[a-z]"))
            return "Add lowercase letters (a–z).";


        if (!Regex.IsMatch(pw, "[0-9]"))
            return "Add numbers (0–9).";


        if (!Regex.IsMatch(pw, "[^a-zA-Z0-9]"))
            return "Add symbols like ! @ # $ % ^ & * to increase strength.";


        if (score < 0.7)
            return "Consider increasing length or mixing additional character types.";


        return "Nice — this is a good password. Consider using a password manager for storage.";
    }




}
