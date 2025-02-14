namespace join
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Employee[] emps = new Employee[3];
            //emps[0] = new Employee() { id = 0 ,age=60,name="ahmed",salary=5000};
            //emps[1] = new Employee() { id = 1, age = 20, name = "ahd", salary = 5000 };
            //emps[2] = new Employee() { id = 2, age = 30, name = "mkol", salary = 800 };

            //Department[] dept = new Department[2];
            //dept[0] = new Department() {DeptId= 0,empNum=80,MangId=1 };
            //dept[1] = new Department() { DeptId = 1, empNum = 100, MangId =0 };


            //var result = emps.Join(dept,
            //    emp => emp.id,
            //    dept=>dept.MangId,
            //    (emp, dept) => new {emp.name,emp.salary,dept.DeptId}
            //    );
            //foreach(var i in result)
            //{
            //    Console.WriteLine(i.DeptId+i.name);
            //}

            var numbers = new[] { 1, 2, 3, 4, 5 };
            var sum = numbers.Aggregate(3,(total, next) => total + next);
            Console.WriteLine(sum);
        }
    }
}
