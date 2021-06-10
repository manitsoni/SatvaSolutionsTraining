using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enum_Ex
{
    enum Day 
    {
        Monday,
        Tuesaday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
    class Data
    {
        public Data()
        {
            Console.WriteLine("Parameterless Constructor");
        }
       
    }
    class Program
    {
        Program()
        {
            Console.WriteLine("Ctor1");
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            Day c = new Day();
            int a = (int)Day.Friday;
            Data d1 = new Data();
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
