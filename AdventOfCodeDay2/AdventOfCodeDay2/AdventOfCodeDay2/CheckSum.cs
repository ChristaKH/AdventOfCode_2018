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
        private int threes;
        private int twos;
        private int checkSum;
        private String correctID, otherID;
        private List<String> IDs;

        public CheckSum()
        {
            threes = 0;
            twos = 0;
            checkSum = 0;
            IDs = new List<String>();
            correctID = "";
            otherID = "";
        }

        public void AddList( String line )
        {
            IDs.Add(line);
        }

        public void Add( String line )
        {
            bool two = false;
            bool three = false;
            int total = 1;
            while( line.Length > 0 )
            {

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
                    //Console.WriteLine(line[0] + ": " + total );
                }
                else
                {
                    //Console.WriteLine(total);
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
                    total = 1;
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

        public void CalcID()
        {
            String temp = "";
            bool found = false;
            
            for( int i = 0; i < IDs.Count - 1; i++ )
            {
                //Console.WriteLine(i);
                int wrong = 0;
                for( int j = i + 1; j < IDs.Count; j++ )
                {
                    wrong = 0;
                    //Console.WriteLine(j);
                    for( int k = 0; k < IDs[i].Length; k++ )
                    {
                        if( IDs[i][k] != IDs[j][k] )
                        {
                            wrong++;
                            if( wrong > 1)
                            {
                                //Console.WriteLine(IDs[j][k]);
                                break;
                            }
                        }
                        
                    }
                    if( wrong == 1)
                    {
                        found = true;
                        correctID = IDs[i];
                        otherID = IDs[j];
                        //Console.WriteLine(correctID);
                        //Console.WriteLine(otherID);
                        break;
                    }
                }

                if( found == true )
                {
                    break;
                }
            }
        }

        public String GetID()
        {
            String temp = "";
            for( int i = 0; i < correctID.Length; i++ )
            {
                if( correctID[i] == otherID[i] )
                {
                    temp += correctID[i];
                }
            }
            return temp;
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
                    check.AddList(line);
                }
                s.Close();
            }

            check.CalcID();
            Console.WriteLine(check.GetID());
            //Console.WriteLine(check.GetCheckSum());
            Console.ReadLine();
        }
    }
}
