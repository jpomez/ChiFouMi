using System;

namespace ChiFouMi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new ChiFouMi(Console.ReadLine, Console.WriteLine, new RulesEngine().Run).Run(args);
        }
    }
}