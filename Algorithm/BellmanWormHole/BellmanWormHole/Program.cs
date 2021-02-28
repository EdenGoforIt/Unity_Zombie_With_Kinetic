using System;
using System.Collections.Generic;

namespace BellmanWormHole
{
    class Program
    {
        private class Vertex
        {
            public Vertex(int vertex_id)
            {
                this.Vertex_id = vertex_id;
                this.Predecessor = -1;
                this.Distance = int.MaxValue;


            }
            public int Predecessor { get; set; }
            public int Distance { get; set; }
            public int Vertex_id { get; set; }
        }
        private class Edge
        {
            public Edge(Vertex start, Vertex end, int weight)
            {
                this.Start = start;
                this.End = end;
                this.Weight = weight;
            }

            public Vertex Start { get; set; }
            public Vertex End { get; set; }
            public int Weight { get; set; }
        }

        class Answer
        {
            public Answer(string value)
            {
                Value = value;
            }

            public string Value { get; set; }
        }

        static void Main(string[] args)
        {
            int caseNum = Convert.ToInt32(Console.ReadLine());
            List<Answer> answerList = new List<Answer>();
            List<Edge> edgeList = new List<Edge>();
            List<Vertex> vertexList = new List<Vertex>();
            for (int i = 0; i < caseNum; i++)
            {
                string[] SystemWormhole = Console.ReadLine().Split(' ');
                int SystemNumber = Convert.ToInt32(SystemWormhole[0]);
                int WormHoleNumber = Convert.ToInt32(SystemWormhole[1]);
                for (int j = 0; j < SystemNumber; j++)
                {
                    vertexList.Add(new Vertex(j));
                }
                for (int k = 0; k < WormHoleNumber; k++)
                {
                    string[] startEndWeight = Console.ReadLine().Split(' ');
                    Vertex startVer = vertexList[Convert.ToInt32(startEndWeight[0])];
                    Vertex endVer = vertexList[Convert.ToInt32(startEndWeight[1])];
                    int weight = Convert.ToInt32( startEndWeight[2]);
                    
                }
                string value = WormHole(edgeList);
                answerList.Add(new Answer(value));
                
                
            }
            foreach (Answer a in answerList)
            {
                Console.WriteLine("{0}")
            }

        }

        private static string WormHole(List<Edge> edgeList)
        {




            return "";
        }
    }
}
