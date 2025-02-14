using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1.Entity
{
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FirstName { get; set; }
        [ForeignKey("Teachers")]

        public int teacherId { get; set; }
        public ICollection<teacher> Teachers { get; set; } = new HashSet<teacher>();
    }
}
