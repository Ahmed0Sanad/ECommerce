namespace EF_Core
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var c = new context();
            var employee = new Employee {name="a90h"};
            c.Add(employee);
            c.SaveChanges();
            
        }
    }
}
