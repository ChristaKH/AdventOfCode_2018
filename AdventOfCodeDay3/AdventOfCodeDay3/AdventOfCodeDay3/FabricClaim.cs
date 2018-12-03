using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventOfCodeDay3
{
    class FabricClaim
    {

        private int startX;
        private int stopX;
        private int startY;
        private int stopY;
        private int totalOverlap;
        private int [,] fabric;
        private List<int> noOverlap;
        private int[,] noOverlapIDs;

        public FabricClaim()
        {
            startX = 0;
            stopX = 0;
            startY = 0;
            stopY = 0;
            totalOverlap = 0;
            fabric = new int[1000, 1000];
            noOverlapIDs = new int[1000, 1000];
            noOverlap = new List<int>();

            for( int i = 1; i < 1348; i++ )
            {
                noOverlap.Add(i);
            }

            for( int i = 0; i < 1000; i++)
            {
                for( int j = 0; j < 1000; j++ )
                {
                    fabric[i, j] = 0;
                }
            }

            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    noOverlapIDs[i, j] = 0;
                }
            }

        }

        public void AddClaim( String line )
        {
            String part1,part2,  part2a, part2b, part3, part3a, part3b;
            part1 = line.Substring(0, line.IndexOf("@"));   //Claim ID
            part2 = line.Substring((line.IndexOf("@") + 1), (line.IndexOf(":")) - (line.IndexOf( "@") + 1) );   //Start of rectangle
            part3 = line.Substring(line.IndexOf(":") + 1);  //Dimensions of their claim

            //Clean up
            part1 = part1.Substring(1).Trim();
            part2 = part2.Trim();
            part2a = part2.Substring(0, part2.IndexOf(","));
            part2b = part2.Substring(part2.IndexOf(",") + 1);

            part3a = part3.Substring(0, part3.IndexOf("x"));
            part3b = part3.Substring(part3.IndexOf("x") + 1).Trim();
            
            startX = Convert.ToInt32(part2a);
            startY = Convert.ToInt32(part2b);
            stopX = startX + Convert.ToInt32(part3a);
            stopY = startY + Convert.ToInt32(part3b);

            for( int i = startX; i < stopX; i++ )
            {
                for( int j = startY; j < stopY; j++ )
                {
                    fabric[i, j]++;
                    if( fabric[i,j] != 1 )
                    {
                        if( noOverlap.Contains( noOverlapIDs[i,j]) )
                        {
                            noOverlap.Remove(noOverlapIDs[i, j]);
                        }

                        if (noOverlap.Contains(Convert.ToInt32(part1))) ;
                        {
                            noOverlap.Remove(Convert.ToInt32(part1));
                        }
                    }
                    else
                    {
                        noOverlapIDs[i, j] = Convert.ToInt32(part1);
                    }
                }
            }
        }

        public void CalcOverlap()
        {
            for( int i = 0; i < 1000; i++ )
            {
                for( int j = 0; j < 1000; j++ )
                {
                    if( fabric[i,j] > 1 )
                    {
                        totalOverlap++;
                    }
                }
            }

            //Console.WriteLine(totalOverlap);
        }

        public void CalcNoOverlap()
        {
            for( int i = 0; i < noOverlap.Count; i++ )
            {
                Console.WriteLine(noOverlap[i]);
            }
        }


        static void Main(string[] args)
        {
            FabricClaim fabric = new FabricClaim();

            using (StreamReader s = new StreamReader("C:\\Users\\chris\\source\\repos\\AdventOfCode_2018\\AdventOfCodeDay3\\AdventOfCodeDay3\\AdventOfCodeDay3\\AdventDay3Input.txt"))
            {
                string line = null;
                while ((line = s.ReadLine()) != null)
                {
                    fabric.AddClaim(line);
                }
                s.Close();
            }

            fabric.CalcNoOverlap();

            Console.ReadLine();
        }
    }
}
