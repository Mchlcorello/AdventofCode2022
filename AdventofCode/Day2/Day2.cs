using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventofCode.Day2
{
    [TestClass]
    public class Day2
    {

        [TestMethod]
        [TestCategory("Day2")]
        public void Part1()
        {

            string[] guide = File.ReadAllLines(@"C:\Users\Coral\source\repos\AdventofCode2022\AdventofCode\Day2\input");

            var moves = new Dictionary<char, int>()
            {
                //Rock    Paper     Scissors
                {'A', 1}, {'B', 2}, {'C', 3},
                {'X', 1}, {'Y', 2}, {'Z', 3}
            };

            var total = 0;

            foreach (var match in guide)
            {
                var matchSplit = match.Split(' ');
                var comp = matchSplit[0];
                var user = matchSplit[1];

                //draw
                if (comp == "A" && user == "X")
                    total += 3 + moves.GetValueOrDefault(user[0]);
                if (comp == "B" && user == "Y")
                    total += 3 + moves.GetValueOrDefault(user[0]);
                if (comp == "C" && user == "Z")
                    total += 3 + moves.GetValueOrDefault(user[0]);

                //comp wins
                if (comp == "A" && user == "Z")
                    total += 0 + moves.GetValueOrDefault(user[0]);
                if (comp == "B" && user == "X")
                    total += 0 + moves.GetValueOrDefault(user[0]);
                if (comp == "C" && user == "Y")
                    total += 0 + moves.GetValueOrDefault(user[0]);

                //user wins
                if (comp == "A" && user == "Y")
                    total += 6 + moves.GetValueOrDefault(user[0]);
                if (comp == "B" && user == "Z")
                    total += 6 + moves.GetValueOrDefault(user[0]);
                if (comp == "C" && user == "X")
                    total += 6 + moves.GetValueOrDefault(user[0]);
            }
            Console.WriteLine(total);
        }


        [TestMethod]
        [TestCategory("Day2")]
        public void Part2()
        {
            string[] guide = File.ReadAllLines(@"C:\Users\Coral\source\repos\AdventofCode2022\AdventofCode\Day2\input");


            var moves = new Dictionary<char, int>()
            {
                //Rock    Paper     Scissors
                {'A', 1}, {'B', 2}, {'C', 3},
                {'X', 1}, {'Y', 2}, {'Z', 3}
            };

            var total = 0;

            foreach (var match in guide)
            {
                var matchSplit = match.Split(' ');
                var comp = matchSplit[0];
                var user = matchSplit[1];

                //draw
                switch (user)
                {

                    case "X":
                        switch (comp)
                        {
                            case "A":
                                total += 0 + moves.GetValueOrDefault('C');
                                break;
                            case "B":
                                total += 0 + moves.GetValueOrDefault('A');
                                break;
                            case "C":
                                total += 0 + moves.GetValueOrDefault('B');
                                break;
                        }
                        break;

                    case "Y":
                        switch (comp)
                        {
                            case "A":
                                total += 3 + moves.GetValueOrDefault('A');
                                break;
                            case "B":
                                total += 3 + moves.GetValueOrDefault('B');
                                break;
                            case "C":
                                total += 3 + moves.GetValueOrDefault('C');
                                break;
                        }
                        break;

                    case "Z":
                        switch (comp)
                        {
                            case "A":
                                total += 6 + moves.GetValueOrDefault('B');
                                break;
                            case "B":
                                total += 6 + moves.GetValueOrDefault('C');
                                break;
                            case "C":
                                total += 6 + moves.GetValueOrDefault('A');
                                break;
                        }
                        break;

                }
            }


            Console.WriteLine(total);
        }
    }
}
