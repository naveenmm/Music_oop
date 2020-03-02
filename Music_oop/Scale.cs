using System;
using System.Collections.Generic;
using System.Text;

namespace Music_oop
{
  
    public class Scale : AbsCollection
    {
        public string root { get; set; }//c,b
        public string[] notes { get; set; }//output
        public string[] all_notes= new string[12]; //= { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
        //name :major,minor
        //key 2121121
        public Scale(int[] a,string[] note_list)
        {
            for (int i = 0; i < 12; i++)
            {
                all_notes[i] = note_list[i];
            }
            root = Util.Console.Ask("\nEnter ROOT::");
            notes = Compute(root.ToUpper(), a);
            var obj3 = new Note(notes);           
        }
        public Scale()
        {

        }        

        public string[] Compute(string val,int[] note)
        {
            int pos = 0;
            int flag = 0;
            string[] a = new string[note.Length];            
            for (int i = 0; i < 12; i++)
            {
                if (val == all_notes[i])
                {
                    pos = i;
                    for (int k = 0; k < note.Length; k++)
                    {
                        a[k] = all_notes[pos % 12];
                        pos = pos + note[k];
                    }
                    flag = 1;
                }                
            }
            if(val=="ALL")
            {
                for (int i = 0; i < 12; i++)
                {
                    for (int k = 0; k < note.Length; k++)
                    {
                        a[k] = all_notes[(i + pos) % 12];
                        pos = pos + note[k];
                        if (i < 11)
                        {
                            Console.Write(a[k] + " ");
                        }
                    }
                    Console.WriteLine();
                }
                flag = 1;
            }
            if(flag==0)
            {
                root = Util.Console.Ask("\nEnter valid ROOT::");
                a = Compute(root.ToUpper(), note);
            }
            return a;
        }

    }
}