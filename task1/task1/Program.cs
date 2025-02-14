// See https://aka.ms/new-console-template for more information
Quistion8();
static void Quistion1()
{
    Console.Write("Enter your name: ");
    string name =   Console.ReadLine();
    Console.Write("Age: ");
    string age = Console.ReadLine();
    Console.Write("Enter your Favorite Hoopy: ");
    string hoopy = Console.ReadLine();
    Console.WriteLine("\t\tYou Entered");
    Console.WriteLine($"your name is :{name}\nyour age is : {age}\nyour favorite hoppy is : {hoopy}");


}
static void Quistion2()
{
    int a;
    double b;
    string n;
    bool g;
    a = 15;
    b = 157545457745.858954;
    n = "sdfaf";
    g = true;
    Console.WriteLine($"{a}  {b}   {n}   {g}");


}

static void Quistion3()
{
    Console.Write("Entre Temperature in Celsius : ");
    double celuis = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine($"Temperatue in Fahrenheit is : {celuis*(9/5)+32}");
}
static void Quistion5()
{
    Console.Write("lenght is :");
    double len = Convert.ToDouble(Console.ReadLine());
    Console.Write("width is :");
    double width = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine($"area is :{len*width}");
}
static void Quistion6()
{
    Console.Write("Entre the number : ");

    int num = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine(num%2==0?"even":"odd");
}
static void Quistion7()
{
    Console.Write("your age is : ");
    int age = Convert.ToInt32(Console.ReadLine());
    if (age > 18)
    {
        Console.WriteLine("you are eligible to vote");
    }
    else
    {
        Console.WriteLine("you are not eligible to vote");
    }
    }
static void Quistion8()

{
start:
    Console.Write("Enter your Degree : ");
    double dig = Convert.ToDouble(Console.ReadLine());
    if (dig >= 90 && dig <= 100)
    {
        Console.WriteLine("your Grade is : A ");
    }
    else if (dig >= 80 && dig <= 89)
    {
        Console.WriteLine("your Grade is : B");
    }
    else if (dig >= 70 && dig <= 79)
    {
        Console.WriteLine("your Grade is : C");
    }
    else if (dig >= 60 && dig <= 69)
    {
        Console.WriteLine("your Grade is : D");
    }
    else if (dig < 60 && dig >= 0)
    {
        Console.WriteLine("your Grade is : F");
    }
    else
    {
        Console.WriteLine("please Enter a number between 0 and 100");
        goto start;
    }
}
 