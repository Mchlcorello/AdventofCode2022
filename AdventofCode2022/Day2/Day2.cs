using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventofCode2022.Day2
{
    public class Day2
    {


        public static void Main(string[] arg)
        {

            string[] guide = File.ReadAllLines("./Day2/input.txt");


            var moves = new Dictionary<string, int>()
            {
                {"A", 1}, {"B", 2}, {"C", 3}
            };

            var matchResults = new Dictionary<string, int>()
            {
                {"l", 0}, {"d", 3}, {"w", 6}
            };

            var total = 0;

            var list = new List<int>();

            foreach (var match in guide)
            {
                var matchSplit = match.Split(' ');

                if()


            }



            Console.ReadLine();
        }




    }
}
