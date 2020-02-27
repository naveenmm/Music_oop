using System;
using System.Collections.Generic;
using System.Text;

namespace Music_oop
{
    public class Note : Scale
    {
        public Note()
        {
        }
        public void print()
        {
            foreach(var item in notes)
            {
                Console.Write(item+" ");
            }            
        }       
    }
}