using System;
using System.Collections.Generic;
using System.Linq;

public class Task
{
    public int Id { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }

    public Task(int id, string description)
    {
        Id = id;
        Description = description;
        IsCompleted = false;
    }

    public void MarkAsCompleted()
    {
        IsCompleted = true;
    }

    public override string ToString()
    {
        return $"{Id}. {Description} {(IsCompleted ? "Completed" : "Not Completed")}";
    }
}

public class TaskManager
{
    private List<Task> tasks = new List<Task>();
    private int nextId = 1;

    public void AddTask(string description)
    {
        Task task = new Task(nextId, description);
        tasks.Add(task);
        nextId++;
    }

    public void EditTask(int id, string newDescription)
    {
        Task task = tasks.Find(t => t.Id == id);
        if (task != null)
        {
            task.Description = newDescription;
        }
    }

    public void DeleteTask(int id)
    {
        Task task = tasks.Find(t => t.Id == id);
        if (task != null)
        {
            tasks.Remove(task);
        }
    }

    public void MarkTaskAsCompleted(int id)
    {
        Task task = tasks.Find(t => t.Id == id);
        if (task != null)
        {
            task.MarkAsCompleted();
        }
    }

    public void DisplayTasks()
    {
        foreach (Task task in tasks)
        {
            Console.WriteLine(task.ToString());
        }
    }
}

public class Program
{
    private TaskManager taskManager = new TaskManager();

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("Меню списка задач:");
            Console.WriteLine("1. Добавить задачу");
            Console.WriteLine("2. Изменить задачу");
            Console.WriteLine("3. Удалить задачу");
            Console.WriteLine("4. Пометить как выполненное");
            Console.WriteLine("5. Отобразить все задачи");
            Console.WriteLine("6. Выход");

            Console.Write("Выберите действие: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddTask();
                    break;
                case 2:
                    EditTask();
                    break;
                case 3:
                    DeleteTask();
                    break;
                case 4:
                    MarkTaskAsCompleted();
                    break;
                case 5:
                    DisplayTasks();
                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("Невозможно выполнить. Попробуйте ещё раз.");
                    break;
            }
        }
    }

    private void AddTask()
    {
        Console.Write("Введите описание задачи: ");
        string description = Console.ReadLine();
        taskManager.AddTask(description);
        Console.WriteLine("Задание успешно добавлено!");
    }

    private void EditTask()
    {
        Console.Write("Введите ID задачи: ");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите новое описание задачи: ");
        string newDescription = Console.ReadLine();
        taskManager.EditTask(id, newDescription);
        Console.WriteLine("Задача успешно отредактирована!");
    }

    private void DeleteTask()
    {
        Console.Write("Введите ID задачи: ");
        int id = Convert.ToInt32(Console.ReadLine());
        taskManager.DeleteTask(id);
        Console.WriteLine("Задача успешно удалена!");
    }

    private void MarkTaskAsCompleted()
    {
        Console.Write("Введите ID задачи: ");
        int id = Convert.ToInt32(Console.ReadLine());
        taskManager.MarkTaskAsCompleted(id);
        Console.WriteLine("Задача помечена как выполненная!");
    }

    private void DisplayTasks()
    {
        taskManager.DisplayTasks();
    }
}

class MainClass
{
    static void Main(string[] args)
    {
        Program program = new Program();
        program.Run();
    }
}