using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[TestClass]
public class Day1
{
    [TestMethod]
    [TestCategory("Day1")]
    public void Part1()
    {
        string[] lines = File.ReadAllLines(@"C:\Users\Coral\source\repos\AdventofCode2022\AdventofCode\Day1\Input");



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

        Assert.IsTrue(max > 0);

        Console.WriteLine($"Answer: {max}");
    }




    [TestMethod]
    [TestCategory("Day1")]
    public void Part2()
    {
        string[] lines = File.ReadAllLines(@"C:\Users\Coral\source\repos\AdventofCode2022\AdventofCode\Day1\Input");


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
    }

 
}
