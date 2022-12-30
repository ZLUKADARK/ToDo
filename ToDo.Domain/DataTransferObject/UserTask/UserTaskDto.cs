namespace ToDo.Domain.DataTransferObject.Task
{
    public class UserTaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
    }
}
