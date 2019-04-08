using System;

namespace NordVpnParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var parser = new Parser();

            parser.ParseAndWrite();

            Console.ReadLine();
        }
    }
}
