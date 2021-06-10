using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HierarchicalInheritance
{
    class GetSet
    {
        public int a, b;
    }   
    class Sum : GetSet
    {
        public void Add(int p,int q)
        {
            Console.WriteLine("Sum of A and B Is : " + (p + q));
        }
    }
    class Mul : GetSet
    {
        public void Multliplication(int p, int q)
        {
            Console.WriteLine("Multliplication of A and B Is : " + (p * q));
        }
    }
    class Div : GetSet
    {
        public void Divison(int p, int q)
        {
            Console.WriteLine("Divison of A and B Is : " + (p / q));
        }
    }
    class Sub : GetSet
    {
        public void Substraction(int p, int q)
        {
            Console.WriteLine("Substraction of A and B Is : " + (p - q));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            GetSet getset = new GetSet();
            getset.a = 10;
            getset.b = 20;

            Sum s1 = new Sum();
            s1.Add(getset.a, getset.b);

            Mul m1 = new Mul();
            m1.Multliplication(getset.a, getset.b);

            Div d1 = new Div();
            d1.Divison(getset.a, getset.b);

            Sub s2 = new Sub();
            s2.Substraction(getset.a, getset.b);

            Console.ReadLine();
        }
    }
}
