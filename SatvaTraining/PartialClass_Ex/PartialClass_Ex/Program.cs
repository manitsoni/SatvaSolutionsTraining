using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialClass_Ex
{
    class Program
    {
        static void Main(string[] args)
        {
            PartialClass p1 = new PartialClass();
            Console.WriteLine("First Name : ");
            p1._firstname = Console.ReadLine();
            Console.WriteLine("Last Name : ");
            p1._lastname = Console.ReadLine();
            Console.WriteLine(p1.GetFullName());
            Console.ReadLine();
        }
    }
}
