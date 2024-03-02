namespace Mission08_Team0104.Models
{
    public class EFTaskRepository : ITaskRepository
    {
        private TaskContext _context;

        public EFTaskRepository(TaskContext temp) 
        { 
            _context = temp;
        }

        public List<Task> Tasks => _context.Tasks.ToList();

        public List<Category> Categories => _context.Categories.ToList();


        public void AddTask(Task task)
        {
            _context.Add(task);
            _context.SaveChanges();
        }
        public void UpdateTask(Task task)
        {
            _context.Update(task);
            _context.SaveChanges();
        }
    }
}
