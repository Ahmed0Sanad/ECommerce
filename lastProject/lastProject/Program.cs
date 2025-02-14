// See https://aka.ms/new-console-template for more information
using lastProject;

Console.WriteLine("Hello, World!");
Class1 c1 = new Class1();
Class1 c2 = new Class1();
Class1 c3 = new Class1();
c1.x = 10;
c2.x = 20;
c3 = c1 + c2;
Console.WriteLine(c3.x);