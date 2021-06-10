using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    interface GetData
    {
        void Display();
    }
    interface Calculator
    {
        void Sum(int a, int b);
        void Sub(int a, int b);
        void Mul(int a, int b);
        void Div(int a, int b);
    }

    class Program : GetData, Calculator
    {
        static void Main(string[] args)
        {

            Program p1 = new Program();
            Console.WriteLine("Enter value A : ");
            string Ans1 = Console.ReadLine();
            Console.WriteLine("Enter value  B : ");
            string Ans2 = Console.ReadLine();
            int a = Convert.ToInt32(Ans1);
            int b = Convert.ToInt32(Ans2);
            p1.Div(a, b);
            p1.Sub(a, b);
            p1.Mul(a, b);
            p1.Sum(a, b);
            p1.Display();
            Console.ReadLine();
        }

        public void Display()
        {
            Console.Write("Hello This Is 1ts Method");
        }

        public void Div(int a, int b)
        {
            Console.WriteLine("Divisin of " + a + " and " + b + " is " + a / b);
        }

        public void Mul(int a, int b)
        {
            Console.WriteLine("Multiplication of " + a + " and " + b + " is " + a * b);
        }

        public void Sub(int a, int b)
        {
            Console.WriteLine("Substraction of " + a + " and " + b + " is " + (a - b));
        }

        public void Sum(int a, int b)
        {
            Console.WriteLine("Divisin of " + a + " and " + b + " is " + (a + b));
        }
    }
}
