namespace PROJECT_PROEL2;

public partial class TodoListForm : ContentPage
{
    private List<ToDoList> todoList;
    public TodoListForm()
	{
		InitializeComponent();

        todoList = new List<ToDoList>
        {
            new ToDoList {Task = "Washing Dishes"},
            new ToDoList {Task = "Cleaning the house"},
            new ToDoList {Task = "Make Breakfast"},

        };

        foreach (var task in todoList)
        {
            task.BulletTask = "ÅE" + task.Task;
        }

        listView.ItemsSource = todoList;
	}

    public class ToDoList
    {
        public string Task { get; set; }
        public string BulletTask { get; set; }
    }

    private void AddTask(object sender, EventArgs e)
    {
        if (addTaskButton.Text == "Add Task")
        {
            // Switch to add mode
            newTaskEntry.IsVisible = true;
            addTaskButton.Text = "Confirm";
            RemoveOrCancelbtn.Text = "Cancel";
        }
        else if (addTaskButton.Text == "Confirm")
        {
            // Confirm new task
            var newTaskText = newTaskEntry.Text?.Trim();

            if (!string.IsNullOrEmpty(newTaskText))
            {
                var newTask = new ToDoList
                {
                    Task = newTaskText,
                    BulletTask = "ÅE" + newTaskText
                };

                todoList.Add(newTask);

                // Refresh list
                listView.ItemsSource = null;
                listView.ItemsSource = todoList;
            }

            // Reset UI
            newTaskEntry.Text = string.Empty;
            newTaskEntry.IsVisible = false;
            addTaskButton.Text = "Add Task";
            RemoveOrCancelbtn.Text = "Remove";
        }
    }

    private void OnAddTaskConfirmed(object sender, EventArgs e)
    {
       
    }

    private void RemoveOrCancel(object sender, EventArgs e)
    {
        if (RemoveOrCancelbtn.Text == "Remove")
        {
            // Remove selected task
            var selectedTask = listView.SelectedItem as ToDoList;
            if (selectedTask != null)
            {
                todoList.Remove(selectedTask);
                listView.ItemsSource = null;
                listView.ItemsSource = todoList;
            }
            else
            {
                DisplayAlert("Remove Task", "Please select a task to remove.", "OK");
            }
        }
        else if (RemoveOrCancelbtn.Text == "Cancel")
        {
            // Cancel adding a task
            newTaskEntry.Text = string.Empty;
            newTaskEntry.IsVisible = false;
            addTaskButton.Text = "Add Task";
            RemoveOrCancelbtn.Text = "Remove";
        }
    }

    private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
       
    }
}
