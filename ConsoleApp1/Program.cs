using System;

namespace module3
{
    class Program
    {

        static void Main(string[] args)
        {
            FileSystemVisitior visitor = new FileSystemVisitior(new FileSystemService());
            visitor.Start += Visitor_Start;
            visitor.Finish += Visitor_Finish;
            var list = visitor.GetDirectories(@"C:\test", "Boot");
        }

        private static void Visitor_Finish(object sender, FinishEventArgs e)
        {
            Console.WriteLine("It's finished");
        }

        private static void Visitor_Start(object sender, StartEventArgs e)
        {
            Console.WriteLine("It's started");
        }
    }
}


