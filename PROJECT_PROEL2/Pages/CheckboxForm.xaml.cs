using System.Collections.ObjectModel;

namespace PROJECT_PROEL2;

public partial class CheckboxForm : ContentPage
{

	public ObservableCollection<string> InterestList { get; set; } =
		 new()
		 {
			 "Playing games", "Dancing", "Singing", "Eating", "Jogging"
		 };

	public ObservableCollection<string> SelectedInterest { get; } = new();

	public CheckboxForm()
	{
		InitializeComponent();


		foreach (var interest in InterestList)
		{
			var cb = new CheckBox
			{
				BindingContext = interest,
				Color = Colors.Black,
				C
			};

			var label = new Label
			{
				Text = interest,
				VerticalOptions = LayoutOptions.Center,
				TextColor = Colors.Black
			};

			cb.CheckedChanged += OnCheckChanged;

			var row = new HorizontalStackLayout
			{
				Spacing = 8,
				Children = { cb, label }
			};

			CheckBoxContainer.Children.Add(row);
		}


	}

	private void OnCheckChanged (object sender, CheckedChangedEventArgs e)
	{
		if (sender is CheckBox cb && cb.BindingContext is string interest)
		{
			if (e.Value)
			{
				if (!SelectedInterest.Contains(interest))
				{
					SelectedInterest.Add(interest);
				}
				else
				{
					if (SelectedInterest.Contains(interest))
					{
						SelectedInterest.Remove(interest);
					}

				}


            }
        }

        SelectedLabel.Text = string.Join(", ", SelectedInterest);

    }


}