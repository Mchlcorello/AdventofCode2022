using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AdventofCode.Template
{


    [TestClass]
    public class Day7
    {

        internal class Node
        {
            public string Name { get; set; }
            public Node Parent { get; set; }
            public List<Node> Childs { get; set; }
            public int Size { get; set; }
        }

        [TestMethod]
        [TestCategory("Day7")]
        public void Part1()
        {
            var lines = File.ReadAllLines(@"C:\Users\Coral\source\repos\AdventofCode2022\AdventofCode\Day7\input").ToList();

            var result = new List<Node>();
            Node currentNode = null;

            foreach (var line in lines)
            {
                if (line.StartsWith("$"))
                {
                    if (line.Equals("$ ls"))
                    {
                        continue;
                    }
                    if (!line.Equals("$ cd .."))
                    {
                        var nodeName = line.Split(' ')[2];
                        if(currentNode == null)
                        {
                            Node node = new Node();
                            node.Name = nodeName;
                            node.Parent = currentNode;
                            currentNode = node;
                            result.Add(node);
                        }
                        else
                        {
                            Node child = currentNode.Childs.Where(x => x.Name == nodeName).FirstOrDefault();
                            child.Parent = currentNode;
                            currentNode = child;
                        }
                    }
                    else
                    {
                        int size = currentNode.Size;
                        currentNode = currentNode.Parent;
                        if(currentNode.Name != "/")
                        {
                            currentNode.Size += size;
                        }
                    }
                    continue;
                }else if (line.StartsWith("dir"))
                {
                    if(currentNode.Childs == null)
                    {
                        currentNode.Childs = new List<Node>();
                    }
                    Node child = new Node();
                    child.Name = line.Split(' ')[1];

                    currentNode.Childs.Add(child);
                    result.Add(child);
                }
                else
                {
                    int values = int.Parse(line.Split(' ')[0]);
                    currentNode.Size += values;
                }
            }

            Console.WriteLine(result.Where(x => x.Size <= 100000).Select(c => c.Size).Sum());
            Assert.IsTrue(false);
        }

        [TestMethod]
        [TestCategory("Day7")]
        public void Part2()
        {
            var lines = File.ReadAllLines(@"C:\Users\Coral\source\repos\AdventofCode2022\AdventofCode\Day7\input").ToList();

            var result = new List<Node>();
            Node currentNode = null;

            foreach (var line in lines)
            {
                if (line.StartsWith("$"))
                {
                    if (line.Equals("$ ls"))
                    {
                        continue;
                    }
                    if (!line.Equals("$ cd .."))
                    {
                        var nodeName = line.Split(' ')[2];
                        if (currentNode == null)
                        {
                            Node node = new Node();
                            node.Name = nodeName;
                            node.Parent = currentNode;
                            currentNode = node;
                            result.Add(node);
                        }
                        else
                        {
                            Node child = currentNode.Childs.Where(x => x.Name == nodeName).FirstOrDefault();
                            child.Parent = currentNode;
                            currentNode = child;
                        }
                    }
                    else
                    {
                        int size = currentNode.Size;
                        currentNode = currentNode.Parent;
                        if (currentNode.Name != "/")
                        {
                            currentNode.Size += size;
                        }
                    }
                    continue;
                }
                else if (line.StartsWith("dir"))
                {
                    if (currentNode.Childs == null)
                    {
                        currentNode.Childs = new List<Node>();
                    }
                    Node child = new Node();
                    child.Name = line.Split(' ')[1];

                    currentNode.Childs.Add(child);
                    result.Add(child);
                }
                else
                {
                    int values = int.Parse(line.Split(' ')[0]);
                    currentNode.Size += values;
                }
            }

            Node root = result.Where(x => x.Name == "/").FirstOrDefault();
            root.Size += root.Childs.Sum(s => s.Size);
            int neededSpace = 30000000 - (70000000 - root.Size);
            Console.WriteLine(result.Select(x => x.Size).Where(s => s >= neededSpace).Min());

            Assert.IsTrue(false);
        }






    }
}
