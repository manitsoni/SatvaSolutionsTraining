using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
    abstract class Demo1
    {
        public abstract void Display();
        public abstract void D2();
        public void Display1()
        {
            Console.WriteLine("Calling non-absrtract method");
        }
    }
    class Demo : Demo1
    {
        public override void Display()
        {
            Console.WriteLine("Calling abstract methos example");
        }
        public override void D2()
        {
            Console.WriteLine("Calling Abstract method :  : : : : : : : : : ");
        }
    }
    abstract class getset
    {
        protected int myNumber;
        public abstract int number { get; set; }
    }
    class getsetDerived : getset
    {
        public override int number
        {
            get
            {
                return myNumber;
            }
            set
            {
                myNumber = value;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Demo d1 = new Demo();
            d1.Display();
            d1.Display1();

            getsetDerived d = new getsetDerived();
            d.number = 5;
            Console.WriteLine(d.number);
            Console.ReadLine();
        }
    }
}
