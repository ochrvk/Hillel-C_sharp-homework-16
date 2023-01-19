struct TaskField
{
    public int number;
    public string heading;
    public string description;
    public DateTime date;
    public DateTime deadline;
}


class Task
{
    List<TaskField> fields = new List<TaskField>();

    public delegate void Notify(string s);
    public event Notify notification = (string s) => { Console.WriteLine(s); };

    public void Add()
    {
        TaskField taskField = new TaskField();

        taskField.number = fields.Count + 1;

        Console.Write("Enter heading: ");
        taskField.heading = Console.ReadLine();

        Console.Write("Enter description: ");
        taskField.description = Console.ReadLine();

        taskField.date = DateTime.Today;

        Console.Write("Enter deadline: ");
        while (true)
        {
            try
            {
                taskField.deadline = DateTime.Parse(Console.ReadLine());
                break;
            }
            catch (Exception)
            {
                Console.Write("Wrong input! Please try again:");
            }
        }


        fields.Add(taskField);
    }

    public void showAll()
    {
        if (fields.Count == 0)
        {
            Console.WriteLine("No tasks here");
        }
        else
        {
            foreach (var item in fields)
            {
                Console.WriteLine("Task number: " + item.number);
                Console.WriteLine("Task heading: " + item.heading);
                Console.WriteLine("Task description: " + item.description);
                Console.WriteLine("Task creation date: " + item.date.ToString("d"));
                Console.WriteLine("Task deadline: " + item.deadline.ToString("d"));
            }
        }
    }

    public void Delete()
    {
        int tmp;
        int deleteNumber = -1;
        Console.WriteLine("Enter task number to delete: ");
        while (true)
        {
            try
            {
                tmp = int.Parse(Console.ReadLine());
                break;
            }
            catch (Exception)
            {
                Console.Write("Incorrect type! Please try again: ");
            }
        }


        TaskField tmpField = new TaskField();
        if (fields.Count == 0)
        {
            Console.WriteLine("No tasks here.");
        }
        else
        {
            foreach (var item in fields)
            {
                if (item.number == tmp)
                {
                    tmpField = item;
                    break;
                }
            }
        }
    }

    public void EditTask()
    {
        Console.Write("Enter task number to edit: ");
        int tmp;
        while (true)
        {
            try
            {
                tmp = int.Parse(Console.ReadLine());
                break;
            }
            catch (Exception)
            {
                Console.Write("Incorrect type! Please try again: ");
            }
        }

        if (fields.Count == 0)
        {
            Console.WriteLine("No tasks here.");
        }
        else
        {
            for (int i = 0; i < fields.Count; i++)
            {
                if (fields[i].number == tmp)
                {
                    TaskField taskField = new TaskField();

                    taskField.number = fields.Count - 1;

                    Console.Write("Enter heading: ");
                    taskField.heading = Console.ReadLine();

                    Console.Write("Enter description: ");
                    taskField.description = Console.ReadLine();

                    taskField.date = DateTime.Today;

                    Console.Write("Enter deadline: ");
                    while (true)
                    {
                        try
                        {
                            taskField.deadline = DateTime.Parse(Console.ReadLine());
                            break;
                        }
                        catch (Exception)
                        {
                            Console.Write("Wrong input! Please try again:");
                        }
                    }

                    fields.RemoveAt(i);
                    fields.Add(taskField);
                    break;
                }
            }
            notification("Task has been changed");
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        int option;
        Task task = new Task();

        while (true)
        {
            Console.WriteLine("----Chose option----");
            Console.WriteLine("1. Add task");
            Console.WriteLine("2. Delete task");
            Console.WriteLine("3. Show all task");
            Console.WriteLine("4. Edit task");
            Console.WriteLine("5. Exit");
            Console.Write("Enter: ");
            while (true)
            {
                try
                {
                    option = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Wrong input! Please try again!");
                }
            }
            Console.WriteLine("------------------");
            switch (option)
            {
                case 1:
                    task.Add();
                    break;
                case 2:
                    task.Delete();
                    break;
                case 3:
                    task.showAll();
                    break;
                case 4:
                    task.EditTask();
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Wrong type! Please try again!");
                    break;
            }
        }
    }
}
