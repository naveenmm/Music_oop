using System;
using System.Collections.Generic;

namespace Music_oop
{
    class Program
    {
        static void Main(string[] args)
        {
            var opt = true;
            while (opt)
            {                
                var obj = new Collection();                             
                var obj2 = new Scale(obj.a,obj.get__notes());               
                
                Console.WriteLine("\nContinue(Y/N)");
                if (Console.ReadLine() != "y")
                {
                    opt = false;
                }
            }
        }
    }
}
