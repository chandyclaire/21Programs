using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;

namespace PROJECT_PROEL2;

public partial class TodoListForm : ContentPage
{
    private ObservableCollection<ToDoList> todoList;

    public TodoListForm()
    {
        InitializeComponent();

        todoList = new ObservableCollection<ToDoList>
        {
            new ToDoList { Task = "Washing Dishes" },
            new ToDoList { Task = "Cleaning the house" },
            new ToDoList { Task = "Make Breakfast" },
        };

        foreach (var task in todoList)
        {
            task.BulletTask = "ÅE" + task.Task;
        }

        listView.ItemsSource = todoList;
    }

    public class ToDoList : INotifyPropertyChanged
    {
        public string Task { get; set; }
        public string BulletTask { get; set; }

        private bool isSelected;
        public bool IsSelected
        {
            get => isSelected;
            set
            {
                if (isSelected != value)
                {
                    isSelected = value;
                    OnPropertyChanged(nameof(IsSelected));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void AddTask(object sender, EventArgs e)
    {
        if (addTaskButton.Text == "Add Task")
        {
            newTaskEntry.IsVisible = true;
            addTaskButton.Text = "Confirm";
            RemoveOrCancelbtn.Text = "Cancel";
        }
        else if (addTaskButton.Text == "Confirm")
        {
            var newTaskText = newTaskEntry.Text?.Trim();

            if (!string.IsNullOrEmpty(newTaskText))
            {
                var newTask = new ToDoList
                {
                    Task = newTaskText,
                    BulletTask = "ÅE" + newTaskText
                };

                todoList.Add(newTask);
            }

            newTaskEntry.Text = string.Empty;
            newTaskEntry.IsVisible = false;
            addTaskButton.Text = "Add Task";
            RemoveOrCancelbtn.Text = "Remove";
        }
    }

    private void RemoveOrCancel(object sender, EventArgs e)
    {
        if (RemoveOrCancelbtn.Text == "Remove")
        {
            var selectedTask = listView.SelectedItem as ToDoList;
            if (selectedTask != null)
            {
                todoList.Remove(selectedTask);
            }
            else
            {
                DisplayAlert("Remove Task", "Please select a task to remove.", "OK");
            }
        }
        else if (RemoveOrCancelbtn.Text == "Cancel")
        {
            newTaskEntry.Text = string.Empty;
            newTaskEntry.IsVisible = false;
            addTaskButton.Text = "Add Task";
            RemoveOrCancelbtn.Text = "Remove";
        }
    }

    private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;

        foreach (var task in todoList)
            task.IsSelected = false;

        ((ToDoList)e.SelectedItem).IsSelected = true;
    }
}

public class BoolToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (bool)value ? Colors.LightBlue : Colors.Transparent;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
