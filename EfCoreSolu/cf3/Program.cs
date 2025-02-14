using Microsoft.Extensions.Configuration;

namespace cf3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Department department = new Department() {Dept_name="blabla500", Emplyee_num=500000};
            using (var con = new Contet())
            {
                con.Add(department);
                con.SaveChanges();
                Console.WriteLine("done");


            }
        }
    }
}
