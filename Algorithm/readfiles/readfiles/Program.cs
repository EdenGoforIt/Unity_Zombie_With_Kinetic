using System;
using System.IO;
using System.Linq;

namespace readfiles
{
    class Program
    {
        static TextReader input = Console.In;
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory() + @"/test.txt";
            using (StreamReader reader = new StreamReader(path))
            {
                Console.SetIn(reader);
                string line;
                while ((line=Console.ReadLine())!=null)
                {
                    Console.WriteLine(line);
                     line = Console.ReadLine();
                }


                Console.SetIn(Console.In);
            }


            //if (args.Any())
            //{
            //    //string path = args[0];
            //    string path = Directory.GetCurrentDirectory() + @"test.txt";
            //    Console.WriteLine(path);

            //    if (File.Exists(path))
            //    {
            //        Console.SetIn(File.OpenText(path));
            //    }
            //}
            //string a = Console.ReadLine();
            //string b = Console.ReadLine();
            //string c = Console.ReadLine();
            //string d = Console.ReadLine();
            
            //Console.WriteLine(b);
            //Console.WriteLine(c);
            //Console.WriteLine(d);
      
            //Console.SetIn(Console.In);
        }
    }
}
