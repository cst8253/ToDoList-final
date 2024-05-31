namespace ToDoList;

public class Item (string task)
{
  public string Task { get; set; } = task;
  public bool IsComplete { get; set; } = false;

  public void MarkTask () 
  {
    IsComplete = true;
  }
}
