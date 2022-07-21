using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FEF
{   
    public class Task
    {
        //[Key]
        public Guid TaskId { get; set; }

        //[ForeignKey("CategoryId")]
        public Guid CategoryId { get; set; }

        //[Required]
        //[MaxLength(200)]
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority PriorityTask { get; set; }
        public DateTime Creation { get; set; }
        public virtual Category Category { get; set; }

        //[NotMapped]
        public string Resumen { get; set; }
    }

    public enum Priority
    {
        Baja,
        Media,
        Alta
    }
}