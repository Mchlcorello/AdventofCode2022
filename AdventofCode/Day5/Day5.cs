using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventofCode.Day5
{
    [TestClass]
    public class Day5
    {

        [TestMethod]
        [TestCategory("Day5")]
        public void Part1()
        {
            string[] input = File.ReadAllLines(@"C:\Users\Coral\source\repos\AdventofCode2022\AdventofCode\Day5\input");
            var yard = File.ReadAllLines(@"C:\Users\Coral\source\repos\AdventofCode2022\AdventofCode\Day5\StorageYard.txt").ToList();

            //string[] input = File.ReadAllLines(@"C:\Users\Coral\source\repos\AdventofCode2022\AdventofCode\Day5\input - Copy");
            //var yard = File.ReadAllLines(@"C:\Users\Coral\source\repos\AdventofCode2022\AdventofCode\Day5\StorageYard - Copy.txt").ToList();

            foreach (var item in yard)
            {
                item.Trim();
            }

            List<string> instructions = input.Skip(10).ToList();
            //List<string> instructions = input.Skip(6).ToList();

            List<List<string>> crates = new List<List<string>>() { new List<string>()};

            var index = 0;
            foreach (var crate in yard)
            {
                if(crate == string.Empty)
                {
                    crates.Add(new List<string>());
                    index++;
                }
                else
                {
                    crates.ElementAt(index).Add(crate);
                }
            }



            void ParseInstructions()
            {

                foreach (var line in instructions)
                {
                    var nums = new List<int>();
                    var split = line.Split(' ');
                    foreach (var item in split)
                    {
                        if (item.All(char.IsDigit))
                        {
                            nums.Add(Convert.ToInt32(item));
                        }
                    }

                    //Take the range
                    var move = nums[0];

                    //Take the from index and create payload
                    var from = nums[1];

                    var payload = crates[from - 1].Take(move);

                    //Reverse payload and place in new index
                    var to = nums[2];

                    foreach (var crate in payload)
                    {
                        var toIndex = crates[to - 1];

                        var newOrder = toIndex.Prepend(crate).ToList();

                        crates[to - 1] = newOrder;

                    }

                    crates[from - 1].RemoveRange(0, move);

                }
            }
            ParseInstructions();

            List<string> tops = new List<string>();

            foreach (var crate in crates)
            {
                tops.Add(crate.First());
                Console.Write(crate.First().ToString().Trim());
            }
        }

        [TestMethod]
        [TestCategory("Day5")]
        public void Part2()
        {
            string[] input = File.ReadAllLines(@"C:\Users\Coral\source\repos\AdventofCode2022\AdventofCode\Day5\input");
            var yard = File.ReadAllLines(@"C:\Users\Coral\source\repos\AdventofCode2022\AdventofCode\Day5\StorageYard.txt").ToList();

            //string[] input = File.ReadAllLines(@"C:\Users\Coral\source\repos\AdventofCode2022\AdventofCode\Day5\input - Copy");
            //var yard = File.ReadAllLines(@"C:\Users\Coral\source\repos\AdventofCode2022\AdventofCode\Day5\StorageYard - Copy.txt").ToList();

            foreach (var item in yard)
            {
                item.Trim();
            }

            List<string> instructions = input.Skip(10).ToList();
            //List<string> instructions = input.Skip(6).ToList();

            List<List<string>> crates = new List<List<string>>() { new List<string>() };

            var index = 0;
            foreach (var crate in yard)
            {
                if (crate == string.Empty)
                {
                    crates.Add(new List<string>());
                    index++;
                }
                else
                {
                    crates.ElementAt(index).Add(crate);
                }
            }



            void ParseInstructions()
            {

                foreach (var line in instructions)
                {
                    var nums = new List<int>();
                    var split = line.Split(' ');
                    foreach (var item in split)
                    {
                        if (item.All(char.IsDigit))
                        {
                            nums.Add(Convert.ToInt32(item));
                        }
                    }

                    //Take the range
                    var move = nums[0];

                    //Take the from index and create payload
                    var from = nums[1];

                    var payload = crates[from - 1].Take(move);

                    //Reverse payload and place in new index
                    var to = nums[2];

                    payload = payload.Reverse();

                    foreach (var crate in payload)
                    {
                        var toIndex = crates[to - 1];

                        var newOrder = toIndex.Prepend(crate).ToList();

                        crates[to - 1] = newOrder;

                    }

                    crates[from - 1].RemoveRange(0, move);

                }
            }
            ParseInstructions();

            List<string> tops = new List<string>();

            foreach (var crate in crates)
            {
                tops.Add(crate.First());
                Console.Write(crate.First().ToString().Trim());
            }
        }






    }
}
