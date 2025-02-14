namespace ConsoleApp1.Entity
{
    public class inhirtance
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class c1 : inhirtance
    {
        public DateTime hireDate { get; set; }
    }
    public class c2 : inhirtance
    {
        public DateTime ddDate { get; set; }
    }
}
