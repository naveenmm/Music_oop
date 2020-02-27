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
                int i = int.Parse(Util.Console.Ask("Scale does not exist::\n1.ADD\n2.Retype"));
                if (i == 1)
                {                    
                    Scales adder = new Scales();
                    adder.Name = name;                    
                    string inp_seq = format_convert(Util.Console.Ask("Enter new sequence::").ToLower());
                    adder.Sequence = long.Parse(inp_seq);
                    items.Add(adder);
                    string output = JsonConvert.SerializeObject(items);
                    File.WriteAllText("scales.json", output);
                    Console.WriteLine("New Scale added::\n");
                    sequence_list();
                }
                else
                {
                    foreach (var item in items)
                    {
                        Console.WriteLine(item.Name);
                    }
                    sequence_list();
                }
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
                Console.Write(seq3[i]);
            }

            return seq3;
            
        }
        
        public string format_convert(string s)
        {
            if (s.StartsWith("w") || s.StartsWith("h"))
            {
                int[] ar = new int[s.Length];
                int j = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    char c1 = s[i];
                    char c2 = '.';
                    if (i < s.Length - 1)
                    {
                        c2 = s[i + 1];
                    }
                    if (c2 == '+')
                    {
                        char c3 = s[i + 2];
                        if ((c1 == 'w' && c3 == 'h') || (c1 == 'h' && c3 == 'w'))
                        {
                            ar[j] = 3;
                            j++;
                        }
                        else if (c1 == 'w' && c3 == 'w')
                        {
                            ar[j] = 4;
                            j++;
                        }
                        else if (c1 == 'h' && c3 == 'h')
                        {
                            ar[j] = 2;
                            j++;
                        }
                        i += 2;
                    }
                    else
                    {
                        if (c1 == 'w')
                        {
                            ar[j] = 2;
                            j++;
                        }
                        else if (c1 == 'h')
                        {
                            ar[j] = 1;
                            j++;
                        }
                    }

                }
                string ss = String.Join(",", ar.Select(p => p.ToString()).ToArray());
                ss = ss.Replace(",", "");
                ss = ss.Replace("0", "");
                return ss;
            }
            else
            {
                return s;
            }
        }
    }
    
}


