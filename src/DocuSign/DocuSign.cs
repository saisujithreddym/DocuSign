using System;
using System.Collections;
using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {

            //This Dictionary stores the prerequisite information given.
            //The value part of the Dictionary is a list which has two entries one for hot and one for cold
            Dictionary<String, List<String>> hash = new Dictionary<String, List<String>>();

            //list acts as a temporary List for entering values into hash.
            List<String> list = new List<String>();
            list.Add("sandals");
            list.Add("boots");
            hash.Add("1", list);
            list = new List<String>();

            list.Add("sand visor");
            list.Add("hat");
            hash.Add("2", list);
            list = new List<String>();

            list.Add("fail");
            list.Add("socks");
            hash.Add("3", list);
            list = new List<String>();

            list.Add("t-shirt");
            list.Add("shirt");
            hash.Add("4", list);
            list = new List<String>();

            list.Add("fail");
            list.Add("jacket");
            hash.Add("5", list);
            list = new List<String>();

            list.Add("shorts");
            list.Add("pants");
            hash.Add("6", list);
            list = new List<String>();

            list.Add("leaving house");
            list.Add("leaving house");
            hash.Add("7", list);
            list = new List<String>();

            list.Add("Removing PJs");
            list.Add("Removing PJs");
            hash.Add("8", list);
            list = new List<String>();

            Console.Write("Enter the input:");
            string line = Console.ReadLine();

            //splitting on space to get the temperature
            String[] aftersplit = line.Split(' ');
            String temp = aftersplit[0];

            //checking if there are numbers being entered after the temperature or not.If the length==1, then splitting the first element on , will not work 
            if (aftersplit.Length == 1)
            {
                Console.Write("fail");
                return;
            }

            //this index is used to select the appropriate temperature in hash.index=0 for HOT and index=1 for Cold.
            int index = 0;

            if (temp.Equals("COLD"))
                index = 1;
            else if (!temp.Equals("HOT"))
            {
                Console.Write("fail");
                return;
            }

            //splitting on commas for the input numbers
            String[] array = line.Split(' ')[1].Split(',');

            //checking if pajamas are taken off first
            if (!array[0].Equals("8"))
            {
                Console.Write("fail");
                return;
            }


            var processed = new HashSet<string>();

            for (int i = 0; i < array.Length - 1; i++)
            {

                //Checking if the input is correct. That is, checking if the input is between 1 and 8 which are the keys of the hash			
                if (!hash.ContainsKey(array[i]))
                {
                    Console.Write("fail");
                    return;
                }

                //leaving house is checked after the iteration.Hence if the input is 7 here, it is a fail
                if (array[i].Equals("7"))
                {
                    Console.Write("fail");
                    return;
                }

                //Checking for duplicates.processed is HashSet which contains unique values and can bed used for duplicate finding.
                //also checking if the value for a particular hash is fail as in for HOT and socks.			
                if (processed.Contains(array[i]) || hash[array[i]][index].Equals("fail"))
                {
                    Console.Write("fail");
                    return;
                }
                else
                    processed.Add(array[i]);

                //checking if socks and pants are put on before shoes
                if (array[i].Equals("1") && !processed.Contains("3") && !processed.Contains("6"))
                {
                    Console.Write("fail");
                    return;
                }

                //checking if shirt is put on before Head wear and Jacket
                if ((array[i].Equals("2") || array[i].Equals(5)) && !processed.Contains("4"))
                {
                    Console.Write("fail");
                    return;
                }

                Console.Write(hash[array[i]][index] + ", ");
            }


            //index==0 is HOT and checked if all the 5 actions are done except leaving house.Same for index==1 which is COLD
            if ((index == 0 && processed.Count != 5) || (index == 1 && processed.Count != 7))
            {
                Console.Write("fail");
                return;
            }

            //checking if the last step is leaving house or not
            if (hash.ContainsKey(array[array.Length - 1]) && array[array.Length - 1].Equals("7"))
            {
                Console.Write(hash[array[array.Length - 1]][index] + ", ");
                Console.Write("Success");
                return;
            }

            Console.Write("fail");
        }
    }
