using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Method_Overloading_Overriding_Ex
{
    class Method_Overloding
    {
        public int x, y,z;
        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }
        public int Z { get { return z; }set { z = value; } }
        public void add(int x)
        {
            Console.WriteLine(x + x);
        }
        public void add(int x,int y)
        {
            Console.WriteLine(x + y);
        }
        public void add(int x,int y,int z)
        {
            Console.WriteLine(x + y + z);
        }
    }
    class Method_Overriding_Base
    {
        public virtual void mul(int x, int y)
        {
            Console.WriteLine(x * y);
        }
    }
    class Method_Overriding_Derived : Method_Overriding_Base
    {
        public override void mul(int x, int y)
        {
            Console.WriteLine("Enter First Number : ");
            x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Second Number : ");
            y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Multliplication is  : "+x * y);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("============================== Method overloading example ============================");
            Method_Overloding mo = new Method_Overloding();
            mo.x = 10;
            mo.y = 20;
            mo.z = 30;
            mo.add(mo.x);
            mo.add(mo.x, mo.y);
            mo.add(mo.x, mo.y, mo.z);
            Console.WriteLine("======================================================================================");

            Console.WriteLine("============================ Method overriding example ===============================");
            Method_Overriding_Base baseObj;
            baseObj = new Method_Overriding_Base();
            baseObj.mul(10,20);
            baseObj = new Method_Overriding_Derived();
            baseObj.mul(10, 20);
            Console.WriteLine("======================================================================================");
            Console.ReadLine();
        }
    }
}
