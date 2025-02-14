using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lastProject
{
    internal class Class1
    {
      public  int x;
        int y;

        public Class1()
        {
            Console.WriteLine("hello all from ctor");
        }

        public static Class1 operator + (Class1 x, Class1 y) { 
            return new Class1() {x= y.x  + x.x} ;
       
        }

        
    }
}
