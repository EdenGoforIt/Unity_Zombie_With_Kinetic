using System;
using System.Collections.Generic;

namespace GCD_LCM
{
    class Program
    {
        double maxNum = Math.Pow(31, 2);
        static void Main(string[] args)
        {
            List<Answer> answerList = new List<Answer>();
            int caseNum = Convert.ToInt32(Console.ReadLine());


            for (int i = 0; i < caseNum; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                int a = Convert.ToInt32(line[0]);
                int b = Convert.ToInt32(line[1]);
                //answerList.Add(new Answer(CalculateGCD(a, b), CalcuateLCM(a, b)));
                if (CalculateGCD(a, b) == 1)
                {
                    Console.WriteLine("-1");

                }
                else
                {
                    Console.WriteLine("{0} {1}", CalculateGCD(a, b), CalcuateLCM(a, b));
                }


                // }
                // foreach (Answer an in answerList)
                // {
                //     if (an.GCD == 1)
                //     {
                //         Console.WriteLine("-1");

                //     }
                //     else
                //     {
                //         Console.WriteLine("{0} {1}", an.GCD, an.LCM);

                //     }
                // }
            }
        }

        private static int CalcuateLCM(int a, int b)
        {
            return a * b / CalculateGCD(a, b);

        }

        private static int CalculateGCD(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                {
                    a %= b;

                }
                else
                {
                    b %= a;
                }

            }
            return a == 0 ? b : a;
        }
    }
    class Answer
    {

        public int GCD { get; set; }
        public int LCM { get; set; }


        public Answer(int gcd, int lcm)
        {
            this.GCD = gcd;
            this.LCM = lcm;
        }

    }
}