using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1.Entity
{
    internal class EmployeeDepartment
    {
        public int id { get; set; }
        [ForeignKey("employee")]
        public int employeeId { get; set; }
        public Employee employee { get; set; }
        [ForeignKey("department")]
        public int departmentId { get; set; }
        public Department department { get; set; }


        public DateTime? date { get; set; }
    }
}
