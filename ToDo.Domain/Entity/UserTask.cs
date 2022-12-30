namespace ToDo.Domain.Entity
{
    public class UserTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CompletedDate { get; set; }
        public bool Completed { get; set; }
    }
}
