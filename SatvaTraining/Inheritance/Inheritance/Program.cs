using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public class Program1
    {
        public int a, b;
        public void SetValue()
        {
            try
            {
                Console.WriteLine("Enter Value A : ");
                string str1 = Console.ReadLine();
                a = Convert.ToInt32(str1);
                Console.WriteLine("Enter Value  B : ");
                string str2 = Console.ReadLine();
                b = Convert.ToInt32(str2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                
            }
            
        }
        public void Display()
        {
            Console.WriteLine("Dislay");
        }
    }
    public class Sum : Program1
    {
        public void Display1()
        {
            Console.WriteLine("Display1");
        }
        public void Summation(int a,int b)
        {
            Console.WriteLine("Sum is : " + (a + b));
        }
    }

    class Program : Sum
    {
        static void Main(string[] args)
        {
            Program p1 = new Program();
            p1.SetValue();
            p1.Display();
            p1.Display1();
            p1.Summation(p1.a, p1.b);

            Console.ReadLine();
        }
    }
}
