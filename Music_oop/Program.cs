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
                List<Scales> items =obj.sequence_list();
                int[] a=obj.getsequence(items,obj.name);                
                var obj2 = new Note();
                obj2.root= Util.Console.Ask("\nEnter ROOT::");
                obj2.notes=obj2.Compute(obj2.root.ToUpper(),a);
                obj2.print();
                Console.WriteLine("\nContinue(Y/N)");
                if (Console.ReadLine() != "y")
                {
                    opt = false;
                }
            }
        }
    }
}
