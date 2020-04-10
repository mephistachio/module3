using System;

namespace module3
{
    class Program
    {
        static void Main(string[] args)
        {
            var visitor = new FileSystemVisitior();
            _ = visitor.GetDirectories(@"C:\test");


        }
    }
}
