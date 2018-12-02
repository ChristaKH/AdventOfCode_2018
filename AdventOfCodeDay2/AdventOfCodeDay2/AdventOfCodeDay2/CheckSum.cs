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
        private String[] alphabet = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k",
            "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
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
            int total;
            String tempLine = line;
            for( int i = 0; i < alphabet.Length; i++ )
            {
                Console.WriteLine(i);
                if( two == true && three == true )
                {
                    break;
                }

                tempLine = line;
                total = 0;
                while( tempLine.Contains( alphabet[i]) )
                {
                    total++;
                    if( tempLine.IndexOf( alphabet[i]) > 0 )
                    {
                        String s1 = tempLine.Substring(0, tempLine.IndexOf(alphabet[i]));
                        String s2 = tempLine.Substring(tempLine.IndexOf(alphabet[i]) + 1);
                        tempLine = s1 + s2;
                    }
                }

                if( total == 2 )
                {
                    two = true;
                }
                if( total == 3 )
                {
                    three = false;
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
                    Console.WriteLine("Reading line");
                    check.Add(line);
                }
                s.Close();
            }

            //Console.WriteLine(check.GetCheckSum());
            Console.ReadLine();
        }
    }
}
