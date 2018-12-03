using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventOfCodeDay2
{
    class CheckSum
    {
        /*private String[] alphabet = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k",
            "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };*/
        private int threes;
        private int twos;
        private int checkSum;

        public CheckSum()
        {
            threes = 0;
            twos = 0;
            checkSum = 0;
        }

        public void Add( String line )
        {
            bool two = false;
            bool three = false;
            int total = 1;
            while( line.Length > 0 )
            {
                total = 1;
                if( two == true && three == true )
                {
                    break;
                }
                //Console.WriteLine("Chosen letter: " + line[0]);
                if( line.LastIndexOf( line[0]) > 0 )
                {

                    String part1 = line.Substring(0, line.LastIndexOf(line[0]));
                    //Console.WriteLine("Part 1: " + part1);
                    String part2 = line.Substring((line.LastIndexOf(line[0]) + 1));
                    //Console.WriteLine("Part2: " + part2);
                    line = part1 + part2;
                    total++;
                    //Console.WriteLine(total);
                }
                else
                {
                    line = line.Substring(1);
                    //Console.WriteLine("New line: " + line);
                    if( total == 2 )
                    {
                        //Console.WriteLine("Entered ");
                        two = true;
                    }
                    //Console.WriteLine(total + " " + two );
                    
                    if( total == 3 )
                    {
                        three = true;
                    }
                }
            }

            if( two == true )
            {
                twos++;
            }

            if( three == true )
            {
                threes++;
            }

            Console.WriteLine("Two: " + twos + " Threes: " + threes);
        }


        public int GetCheckSum()
        {
            checkSum = threes * twos;
            return checkSum;
        }

        static void Main(string[] args)
        {
            CheckSum check = new CheckSum();
            using (StreamReader s = new StreamReader("C:\\Users\\chris\\source\\repos\\AdventOfCode_2018\\AdventOfCodeDay2\\AdventOfCodeDay2\\AdventOfCodeDay2\\AdventDay2Input.txt")) 
            {
                string line = null;
                while ((line = s.ReadLine()) != null)
                {
                    //Console.WriteLine("Reading line");
                    check.Add(line);
                    Console.ReadLine();
                }
                s.Close();
            }

            //Console.WriteLine(check.GetCheckSum());
            Console.ReadLine();
        }
    }
}
