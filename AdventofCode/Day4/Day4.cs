using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventofCode.Day4
{
    [TestClass]
    public class Day4
    {





        [TestMethod]
        [TestCategory("Day4")]
        public void Part1()
        {
            string[] lines = File.ReadAllLines(@"C:\Users\Coral\source\repos\AdventofCode2022\AdventofCode\Day4\input");
            var total = 0;

            foreach (var line in lines)
            {
                var assignments = line.Split(',');

                var nums = new List<int[]>();


                foreach (var assignment in assignments)
                {
                    nums.Add(Array.ConvertAll(assignment.Split('-'), x => int.Parse(x)));
                }

                var firstLower = nums[0].First();
                var firstUpper = nums[0].Last();

                var secondLower = nums[1].First();
                var secondUpper = nums[1].Last();

                if (firstLower >= secondLower && firstUpper <= secondUpper || secondLower >= firstLower && secondUpper <= firstUpper)
                {
                    total++;
                }

            }
        }

        [TestMethod]
        [TestCategory("Day4")]
        public void Part2()
        {
            string[] lines = File.ReadAllLines(@"C:\Users\Coral\source\repos\AdventofCode2022\AdventofCode\Day4\input");
            
            var total = 0;
            
            foreach (var line in lines)
            {
                var assignments = line.Split(',');

                var nums = new List<int[]>();


                foreach (var assignment in assignments)
                {
                    nums.Add(Array.ConvertAll(assignment.Split('-'), x => int.Parse(x)));
                }

                var firstList = new List<int>();
                
                for (int i = nums[0].First(); i < nums[0].Last()+1; i++)
                {
                    firstList.Add(i);
                }

                var secondList = new List<int>();
                
                for (int i = nums[1].First(); i < nums[1].Last() + 1; i++)
                {
                    secondList.Add(i);
                }

                var query = firstList.Intersect(secondList).Any();

                if (query)
                {
                    total++; 
                }


            }




            Console.WriteLine(total);
        }






    }
}
