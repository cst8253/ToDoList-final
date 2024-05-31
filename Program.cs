using ToDoList;

internal class Program
{
    private static List<Item> items = [];
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Your To Do List.");
        bool isActive = true;

        while (isActive)
        {
            Console.Write("\nChoose an action (Add, View, Mark, or Exit): ");
            string? action = Console.ReadLine();

            if (string.IsNullOrEmpty(action))
            {
                Console.WriteLine("\nNot a valid response.");
                continue;
            }

            switch (action.ToLower())
            {
                case "add":
                    AddItem();
                    break;
                case "view":
                    DisplayItems();
                    break;
                case "mark":
                    MarkItem();
                    break;
                case "exit":
                    isActive = false;
                    Console.WriteLine("\nGoodbye");
                    break;
                default:
                    Console.WriteLine("\nNot a valid response.");
                    break;
            }
        }
    }

    private static void AddItem ()
    {
      string? task = null;
      Item item;
     
      while (string.IsNullOrEmpty(task)) 
      {
        Console.Write("\nProvide the task for the new item: ");
        task = Console.ReadLine();

        if (!string.IsNullOrEmpty(task)) 
        {
          item = new Item(task);
          items.Add(item);
          Console.WriteLine("Item has been added");
        }
      }  
    }

    private static void DisplayItems ()
    {
      Console.WriteLine();
      for (int i = 0; i < items.Count; i++) 
      {
        Console.WriteLine($"{i} - {(items[i].IsComplete ? "x" : " ")} {items[i].Task}");
      }
    }

    private static void MarkItem ()
    {
      while (true)
      {
        Console.Write("\nProvide the index of the item to mark complete: ");
        string? input = Console.ReadLine();
        bool isValid = int.TryParse(input, out int index);
        
        if (isValid && items.ElementAtOrDefault(index) != null)
        {
          items[index].MarkTask();
          Console.WriteLine("Item has been marked complete");
          return;
        }
        Console.WriteLine("Not a valid response");
      }
    }
}