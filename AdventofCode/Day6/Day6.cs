using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventofCode.Day6
{
    [TestClass]
    public class Day6
    {

        [TestMethod]
        [TestCategory("Day6")]
        public void Part1()
        {
            string[] lines = File.ReadAllLines(@"C:\Users\Coral\source\repos\AdventofCode2022\AdventofCode\Day6\input");

            var data = lines.First().ToCharArray();
            var count = 0;

            for (int i = 0; i < data.Length; i++)
            {

                var packet = data.Take(new Range(i, i + 14));
                
                var distinctPacket = packet.Distinct();

                if(packet.Count() != distinctPacket.Count())
                {
                    //not a signal start
                }
                else
                {
                    count = i+14;
                    break;
                }

            }



            Console.WriteLine(count);
        }

        [TestMethod]
        [TestCategory("Day6")]
        public void Part2()
        {
            string[] lines = File.ReadAllLines(@"doooooooooooooooooog");




        }






    }
}
