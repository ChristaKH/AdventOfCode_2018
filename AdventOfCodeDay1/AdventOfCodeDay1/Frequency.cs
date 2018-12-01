/** @author: Christa Hatch
 *  Purpose: To solve the two problems from Advent of Code Day 1
 */

/// Problem 1: Assuming the frequency starts at 0 and given a list of frequency changes
/// what is the resulting frequency. Answer Found: 459
/// 
/// Problem 2: What is the first repeated frequency result (once the list of frequency changes ends, 
/// repeat it till answer is found). Answer found: 65474

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventDay1
{
    class Frequency
    {
        private int freq;   //resulting frequency
        private List<int> changes;  //holds the changes that are read in. Stops taking in after read the first time
        private List<int> results; //Holds ALL frequency results after changes as well as initial frequency
        private int repeatedNum;    //Will hold value of the first repeated frequency
        private bool repeat;    //Keeps track of whether the first repeated frequency occurred yet
        private bool firstRound;    //Keeps track of whether the inputs are being read for the 1st time

        //Empty constructor
        public Frequency()
        {
            freq = 0;
            repeat = false;
            results = new List<int>();
            results.Add(0);
            changes = new List<int>();
            firstRound = true;
        }

        //Meant mostly for first round of inputs
        //Reads in frequency changes and adds them to frequency
        //Adds changes to List of changes
        //Adds frequency result to list of results
        public void Add(String line)
        {
            int num = Convert.ToInt32(line.Substring(1));
            if (line[0] == '-')
            {
                num *= -1;
            }

            freq += num;
            if (firstRound == true)
            {
                changes.Add(num);
            }
            if (repeat == false)
            {
                //Console.WriteLine(freq);
                if (results.Contains(freq))
                {
                    //Console.WriteLine("Repeat");
                    repeat = true;
                    repeatedNum = freq;
                }
                else
                {
                    Console.WriteLine("No Repeat");
                }
            }

            results.Add(freq);
        }

        //Mostly meant for after first round of inputs is entered
        //Adds [change] to [freq]
        //Adds resulting [freq] to [results]
        //Decides whether the new result is the first repeat or not
        //Prints if first repeat
        public void Add(int change)
        {
            // Console.WriteLine(change);
            freq += change;
            if (firstRound == true)
            {
                changes.Add(change);
            }
            else
            {
                if (repeat == false)
                {
                    //Console.WriteLine(freq);
                    if (results.Contains(freq))
                    {
                        Console.WriteLine("Repeat : " + freq);
                        repeat = true;
                        repeatedNum = freq;
                    }
                    else
                    {
                        Console.WriteLine("No Repeat round 2");
                    }
                }

            }
            results.Add(freq);
        }

        //Returns current frequency
        public int GetFrequency()
        {
            return freq;
        }

        //Signals the end of reading in initial inputs
        public void EndRound()
        {
            firstRound = false;
        }

        //Loop through changes to a repeat frequency is found
        public void CalcRepeat()
        {
            while (repeat == false)
            {
                for (int i = 0; i < changes.Count; i++)
                {
                    this.Add(changes[i]);
                }
            }

            Console.WriteLine("found");
        }


        static void Main(string[] args)
        {
            Frequency freq = new Frequency();
            using (StreamReader s = new StreamReader("C: \\Users\\chris\\source\\repos\\AdventDay1\\AdventDay1\\AdventDay1Input.txt"))
            {
                string line = null;
                while ((line = s.ReadLine()) != null)
                {
                    freq.Add(line);
                }
                s.Close();
            }

            freq.EndRound();
            freq.CalcRepeat();
            Console.ReadLine();
        }
    }
}