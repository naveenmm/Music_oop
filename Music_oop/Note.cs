using System;
using System.Collections.Generic;
using System.Text;

namespace Music_oop
{
    public class Note:Scale
    {
        public Note(string [] notes)
        {
            print(notes);
        }
        public void print(string [] notes)
        {
            foreach (var item in notes)
            {
                Console.Write(item + " ");
            }
        }
    }
}