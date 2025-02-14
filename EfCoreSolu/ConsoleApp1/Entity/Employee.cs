namespace ConsoleApp1.Entity
{
    internal class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }


        public ICollection<EmployeeDepartment> departments { get; set; }
    }
}
