using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventofCode2022.Day_1
{
    public class Day1
    {


        public static void Main(string[] arg)
        {

            string lines = File.ReadAllText("./Day_1/Day1_Input.txt");

            var parsedElves = lines
                .Split("\n");



            Console.ReadLine();
        }


        public async Task Part1()
        {
            string[] lines = File.ReadAllLines(@"C:\Users\Coral\source\repos\AdventofCode2022\AdventofCode2022\Day 1\Day1 Input");



            var max = 0;
            var total = 0;
            foreach (var item in lines)
            {
                if (item == string.Empty)
                {
                    if (max > total)
                    {
                        total = 0;
                        continue;
                    }
                    else
                    {
                        max = total;
                        total = 0;
                        continue;
                    }
                }

                total += Int32.Parse(item);

            }



            Console.WriteLine($"Answer: {max}");
            Console.ReadLine();
        }

        public async Task Part2()
        {
            string[] lines = File.ReadAllLines(@"C:\Users\Coral\source\repos\AdventofCode2022\AdventofCode2022\Day 1\Day1 Input");


            var maxList = new List<int>();
            var total = 0;

            foreach (var item in lines)
            {
                if (item == string.Empty)
                {
                    maxList.Add(total);
                    total = 0;
                    continue;
                }

                total += Int32.Parse(item);

            }

            maxList.Sort();
            
            var query = maxList.TakeLast(3).Sum();

            Console.WriteLine(query);
            Console.ReadLine();
        }




    }
}
