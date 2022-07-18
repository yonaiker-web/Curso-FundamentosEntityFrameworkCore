namespace FEF.Models
{
    public class Task
    {
        public Guid TaskId { get; set; }
        public Guid CategoyId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority PriorityTask { get; set; }
        public DateTime Creation { get; set; }
        public virtual Category Category { get; set; }
    }

    public enum Priority
    {
        Baja,
        Media,
        Alta
    }
}