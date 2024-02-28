namespace Mission08_Team0104.Models
{
    public class ITaskRepository
    {
        List<Task> Tasks { get; }

        public void AddTask(Task task);
    }
}
