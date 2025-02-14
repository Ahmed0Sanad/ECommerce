namespace ConsoleApp1.Entity
{
    internal class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<EmployeeDepartment> employees { get; set; }

    }
}
