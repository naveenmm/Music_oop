using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Music_oop
{
    public class Scales
    {
        public long Sequence { get; set; }
        public string Name { get; set; }
    }

    public class Collection : AbsCollection
    {
        public List<Scales> seq_list;
        public int[] getsequence(List<Scales> s,string n)
        {
            foreach (var item in s)
            {
                if (item.Name == n)
                {
                    key = sequence_convert(item.Sequence);
                }
            }
            return key;
            //get the sequence of the name            
        }
        public List<Scales> sequence_list()
        {

            StreamReader r = new StreamReader("scales.json");
            string json = r.ReadToEnd();
            List<Scales> items = JsonConvert.DeserializeObject<List<Scales>>(json);
           // Scales adder = new Scales();
            r.Close();
            int flag = 0;
            name = Util.Console.Ask("Enter Scale name::");
            foreach(var item in items)
            {
                if (name == item.Name)
                {
                    flag = 1;
                }
            }
            if(flag==0)
            {
                Console.WriteLine("Scale does not exist::\nEnter any of these::");
                foreach (var item in items)
                {
                    Console.WriteLine(item.Name);
                }
                sequence_list();
            }
            //get all scales name and sequence from file
            return items;
        }
        public int[] sequence_convert(long n)
        {
            int[] seq3 = new int[n.ToString().Length];
            for (int i = 0; i < n.ToString().Length; i++)
            {
                seq3[i] = Convert.ToInt32(n.ToString()[i] - 48);
            }

            return seq3;
            //returns sequences as array

        }
        //public Collection()
        //{
        //    Console.WriteLine("Collection constr");
        //    List<Scales> item = getsequence(name);
        //    if (key == 0)
        //    {
        //        Console.WriteLine("Scale not available::");
        //        foreach (var items in item)
        //        {
        //            Console.WriteLine(items.Name);
        //        }

        //        name = Util.Console.Ask("Enter any of these::");
        //        getsequence(name);
        //    }
        //}
        //key from abs
        //name from abs
        //string[] scales = new string[];
        //public List<Scales> getsequence(string n)
        //{
        //    StreamReader r = new StreamReader("scales.json");
        //    string json = r.ReadToEnd();
        //    List<Scales> items = JsonConvert.DeserializeObject<List<Scales>>(json);
        //    Scales adder = new Scales();
        //    r.Close();
        //    Console.WriteLine("getsequence called");
        //    foreach (var item in items)
        //    {
        //        if (item.Name == name)
        //        {
        //            key = item.Sequence;
        //            Console.WriteLine(key);
        //        }
        //    }            

        //    return items;
        //}


    }
    
}


