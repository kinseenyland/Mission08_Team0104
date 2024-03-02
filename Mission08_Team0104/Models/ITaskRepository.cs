namespace Mission08_Team0104.Models
{
    public interface ITaskRepository
    {
        List<Task> Tasks { get; }

        List<Category> Categories { get; }

        public void AddTask(Task task);
        public void UpdateTask(Task task);

        //public void SaveChanges(Task task);
    }
}
