using System;
using System.Collections.Generic;
using System.Text;

namespace Music_oop
{
  
    public class Scale : AbsCollection
    {
        public string root { get; set; }//c,b
        public string[] notes { get; set; }//output
        public string[] all_notes= { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
        //name :major,minor
        //key 2121121
        public Scale()
        {
            //all_notes = new string[12];


        //root = Util.Console.Ask("Enter root:");
        }
    
        public string[] Compute(string val,int[] note)
        {
            int pos = 0;            
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
                }                
            }
            return a;
            //return list of notes
        }

    }
}