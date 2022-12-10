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
    public class Day8
    {

        [TestMethod]
        [TestCategory("Day8")]
        public void Part1()
        {
            var lines = File.ReadAllLines(@"C:\Users\Coral\source\repos\AdventofCode2022\AdventofCode\Day8\input").ToList();

            var visableTrees = 0;

            var intList = new List<List<int>>();

            var trees = new int[lines.Count, lines[0].Count()];
            
            foreach (var item in lines.Select(x => x.ToCharArray()).ToList())
            {
                var itemChars = item.Select(x => Int32.Parse(x.ToString())).ToList();
                intList.Add(itemChars);
            }

            PopulateTrees();
            void PopulateTrees()
            {
                for (int i = 0; i < lines.Count; i++)
                {
                    for (int j = 0; j < lines[0].Count(); j++)
                    {
                        trees[i, j] = intList[i][j];
                    }
                }
            }
            
            //Add Trees on top/bottom edge
            visableTrees += lines[0].Count() + lines[lines.Count() - 1].Count();

            for (int i = 0; i < lines.Count() - 1; i++)
            {
                //Top/Bottom edge break out of loop
                if (i == 0 || i == lines.Count()-1)
                {
                    continue;
                }

                for (int j = 0; j < lines[0].Length; j++)
                {
                    var tree = trees[i, j];

                    //Left/Right Edge add tree
                    if (j == 0 || j == lines[0].Count() - 1) 
                    {
                        visableTrees++;
                        continue;
                    }

                    Action CalculateTrees = delegate
                    {
                        
                        for (int left = 0; left <= j; left++) //Check Trees from left
                        {
                            if (left == j) //if loop makes it to tree column, tree is visable
                            {
                                visableTrees++;
                                return;
                            }
                            else if (trees[i,left] >= tree) //if tree is blocking break out of loop
                            {
                                break;
                            }
                        }


                        for (int right = lines[0].Count()-1; right >= j; right--) //Check Trees from right
                        {
                            if (right == j)
                            {
                                visableTrees++;
                                return;
                            }
                            else if (trees[i,right] >= tree)
                            {
                                break;
                            }
                        }

                        for (int top = 0; top <= i; top++)//Check Trees above
                        {
                            if(top == i)
                            {
                                visableTrees++;
                                return;
                            }
                            else if (trees[top,j] >= tree)
                            {
                                break;
                            }
                        }

                        for (int bot = lines.Count-1; bot >= i; bot--)//Check Trees below
                        {
                            if(bot == i)
                            {
                                visableTrees++;
                                return;
                            }else if (trees[bot,j] >= tree)
                            {
                                break;
                            }
                        }
                    };
                    CalculateTrees();
                }
            }
            Console.WriteLine(visableTrees);
        }

        [TestMethod]
        [TestCategory("Day8")]
        public void Part2()
        {
            var lines = File.ReadAllLines(@"C:\Users\Coral\source\repos\AdventofCode2022\AdventofCode\Day8\input").ToList();

            var sceneScores = 0;

            var intList = new List<List<int>>();

            var trees = new int[lines.Count, lines[0].Count()];

            foreach (var item in lines.Select(x => x.ToCharArray()).ToList())
            {
                var itemChars = item.Select(x => Int32.Parse(x.ToString())).ToList();
                intList.Add(itemChars);
            }

            PopulateTrees();
            void PopulateTrees()
            {
                for (int i = 0; i < lines.Count; i++)
                {
                    for (int j = 0; j < lines[0].Count(); j++)
                    {
                        trees[i, j] = intList[i][j];
                    }
                }
            }

            int CalculateSceneScores(int left, int right, int down, int up)
            {
                return left * right * up * down;
            }


            for (int i = 0; i < lines.Count; i++)
            {
                for (int j = 0; j < lines[0].Length; j++)
                {
                    var tree = trees[i, j];

                    var leftScore = 0;
                    var rightScore = 0;
                    var upScore = 0;
                    var botScore= 0;

                    for (int left = j-1; left >= 0; left--) 
                    {
                        if (trees[i,left] >= tree)
                        {
                            leftScore++;
                            break;
                        }
                        else
                        {
                            leftScore++;
                        }
                    }

                    for (int right = j+1; right <= lines[0].Length-1; right++)
                    {
                        if (trees[i,right] >= tree)
                        {
                            rightScore++;
                            break;
                        }
                        else
                        {
                            rightScore++;
                        }
                    }

                    if(i == 60 && j == 23)
                    {

                    }

                    for (int up = i-1; up >= 0; up--)
                    {
                        if(i == 0)
                        {
                            break;
                        }

                        if (trees[up,j] >= tree)
                        {
                            upScore++;
                            break;
                        }
                        else
                        {
                            upScore++;
                        }
                    }

                    for (int down = i+1; down <= lines.Count-1; down++)
                    {
                        if (trees[down,j] >= tree)
                        {
                            botScore++;
                            break;
                        }
                        else
                        {
                            botScore++;
                        }
                    }



                    var tempTotal = CalculateSceneScores(upScore, leftScore, rightScore, botScore);
                   
                    if (tempTotal >= sceneScores)
                    {
                        if(tempTotal == 839040)
                        {

                        }
                        sceneScores = tempTotal;
                    }
                }
            }
            Console.WriteLine(sceneScores);
        }
    }
}
