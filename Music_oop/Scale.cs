using System;
using System.Collections.Generic;
using System.Text;

namespace Music_oop
{
  
    public class Scale : AbsCollection
    {
        public string root { get; set; }//c,b
        public string[] notes { get; set; }//output
        public string[] all_notes;//= { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
        //name :major,minor
        //key 2121121
        public Scale()
        {
            all_notes = new string[12];
            all_notes[0] = "C";
            all_notes[1]= "C#";
            all_notes[2]= "D";
            all_notes[3]= "D#";
            all_notes[4]= "E";
            all_notes[5]= "F";
            all_notes[6]= "F#";
            all_notes[7]= "G";
            all_notes[8]= "G#";
            all_notes[9]= "A";
            all_notes[10]= "A#";
            all_notes[11]= "B";         
            //root = Util.Console.Ask("Enter root:");
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
            if(flag==0)
            {
                root = Util.Console.Ask("\nEnter valid ROOT::");
                a = Compute(root.ToUpper(), note);
            }
            return a;
        }

    }
}