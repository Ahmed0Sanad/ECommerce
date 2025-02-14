using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1.Entity
{
    internal class teacher
    {
        public int Id { get; set; }
        [ForeignKey("Students")]
        public int studentId { get; set; }

        public ICollection<Student> Students { get; set; } = new HashSet<Student>();
    }
}
