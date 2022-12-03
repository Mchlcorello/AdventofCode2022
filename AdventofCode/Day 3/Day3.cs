using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AdventofCode.Day_3
{
    [TestClass]
    public class Day3
    {


        [TestMethod]
        [TestCategory("Day3")]
        public void Part1()
        {
            string[] lines = File.ReadAllLines(@"C:\Users\Coral\source\repos\AdventofCode2022\AdventofCode\Day 3\input");

            var duplicateList = new List<char>();

            var priority = new Dictionary<string, int>();

            var count = 1;

            for (char c = 'A'; c <= 'Z'; c++)
            {
                priority.Add(c.ToString().ToLower(), count);
                count++;
            }

            count = 27;
            
            for (char c = 'A'; c <= 'Z'; c++)
            {
                priority.Add(c.ToString().ToUpper(), count);
                count++;
            }

            foreach (var item in lines)
            {

                var compartment1 = item.Substring(0, item.Count() / 2);
                var compartment2 = item.Substring(item.Count() / 2);


                Action work = delegate
                {
                    foreach (var x in compartment1)
                    {
                        foreach (var y in compartment2)
                        {
                            if (x == y)
                            {
                                duplicateList.Add(y);
                                return;
                            }
                        }
                    }
                };
                work();
            
            
            }

            var sum = 0;

            foreach (var item in duplicateList)
            {
                sum += priority.GetValueOrDefault(item.ToString());
            }

        }

        [TestMethod]
        [TestCategory("Day3")]
        public void Part2()
        {
            string[] lines = File.ReadAllLines(@"C:\Users\Coral\source\repos\AdventofCode2022\AdventofCode\Day 3\input");

            var priority = new Dictionary<string, int>();

            var badge = new List<char>();

            var count = 1;

            for (char c = 'A'; c <= 'Z'; c++)
            {
                priority.Add(c.ToString().ToLower(), count);
                count++;
            }

            count = 27;

            for (char c = 'A'; c <= 'Z'; c++)
            {
                priority.Add(c.ToString().ToUpper(), count);
                count++;
            }

            var groupedList = new List<string>();

            for (int i = 0; i < 300; i+=3)
            {
                groupedList.Clear();
                groupedList = lines.ToList().GetRange(i, 3);

                Action work = delegate
                {
                    foreach (var ruck1 in groupedList[0])
                    {
                        foreach (var ruck2 in groupedList[1])
                        {
                            if (ruck1 == ruck2)
                            {
                                foreach (var ruck3 in groupedList[2])
                                {
                                    if (ruck2 == ruck3)
                                    {
                                        badge.Add(ruck3);
                                        return;
                                    }
                                }
                            }
                        }

                    }
                };
                work();

            }

            var sum = 0;

            foreach (var item in badge)
            {
                sum += priority.GetValueOrDefault(item.ToString());
            }
            
            Console.WriteLine(sum);
        }




        [TestMethod]
        [TestCategory("Day3")]
        public void zHolyshitthisissomucheasier()
        {
            string[] lines = File.ReadAllLines(@"C:\Users\Coral\source\repos\AdventofCode2022\AdventofCode\Day 3\input");

            var groups = lines.Chunk(3);
            
            var badge = new List<char>();
            
            var priority = new Dictionary<string, int>();

            var count = 1;

            for (char c = 'A'; c <= 'Z'; c++)
            {
                priority.Add(c.ToString().ToLower(), count);
                count++;
            }

            count = 27;

            for (char c = 'A'; c <= 'Z'; c++)
            {
                priority.Add(c.ToString().ToUpper(), count);
                count++;
            }

            //var r = qq.Aggregate((x, y) => String.Concat(x.Intersect(y)));
            
            
            foreach (var rucks in groups)
            {
                var c = rucks[0].Intersect(rucks[1]);
                var cc = c.Intersect(rucks[2]);
                badge.Add(cc.First());
            }

            var sum = 0;

            foreach (var item in badge)
            {
                sum += priority.GetValueOrDefault(item.ToString());
            }

            Console.WriteLine(sum);
        }
    }
}
