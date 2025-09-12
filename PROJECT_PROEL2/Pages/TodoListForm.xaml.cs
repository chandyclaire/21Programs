namespace PROJECT_PROEL2;

public partial class TodoListForm : ContentPage
{
	public TodoListForm()
	{
		InitializeComponent();

        var todoList = new List<ToDoList>
        {
            new ToDoList {Task = "Washing Dishes"},
            new ToDoList {Task = "Cleaning the house"},
            new ToDoList {Task = "Make Breakfast"},

        };

        foreach (var task in todoList)
        {
            task.BulletTask = "• " + task.Task;
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
        // Toggle visibility of the Entry field
        newTaskEntry.IsVisible = !newTaskEntry.IsVisible;

        // Optionally, you can also change the button text to "Cancel" when the Entry is visible.
        if (newTaskEntry.IsVisible)
        {
            addTaskButton.Text = "Cancel";
        }
        else
        {
            addTaskButton.Text = "Add Task";
        }
    }

    private void OnAddTaskConfirmed(object sender, EventArgs e)
    {
        var newTaskText = newTaskEntry.Text?.Trim();

        if (!string.IsNullOrEmpty(newTaskText))
        {
            var newTask = new ToDoList
            {
                Task = newTaskText,
                BulletTask = "• " + newTaskText
            };

            // Add new task to the list and refresh the ListView
            var todoList = (List<ToDoList>)listView.ItemsSource;
            todoList.Add(newTask);
            listView.ItemsSource = null; // Reset the ListView's ItemsSource
            listView.ItemsSource = todoList; // Reassign the updated list
        }

        // Clear the entry field after adding the task
        newTaskEntry.Text = string.Empty;

        // Hide the Entry again
        newTaskEntry.IsVisible = false;

        // Change the button text back to "Add Task"
        addTaskButton.Text = "Add Task";
    }
}