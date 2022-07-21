using System.ComponentModel.DataAnnotations;

namespace FEF
{
    public class Category
    {
        //[Key]
        public Guid CategoryId { get; set; }

        //[Required]
        //[MaxLength(150)]
        public string Name { get; set; }
        public string Description { get; set; }

        //creamos una relacion virtual para poder hacer la relacion con la tabla Task
        public virtual ICollection<Task> Task { get; set; }
    }
}