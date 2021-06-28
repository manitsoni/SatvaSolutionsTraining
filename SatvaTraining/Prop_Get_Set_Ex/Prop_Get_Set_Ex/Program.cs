using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prop_Get_Set_Ex
{
    abstract class AbstractDemo
    {
        public abstract void SetValue();
    }
    class GetSet : AbstractDemo
    {
        public string Name;
        public string name { get { return Name; } set { Name = value; } }
        public override void SetValue()
        {
            Console.WriteLine("Name : " + Name);
        }
    }
    class GetVal : AbstractDemo
    {
        public int Age;
        public int age { get { return Age; } set { Age = value; } }
        public override void SetValue()
        {
            Console.WriteLine("Age Is : " + Age);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter sw = null;
            sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogFile.txt", true);
            sw.WriteLine(DateTime.Now.ToString() + " " + "Hello");
            sw.Flush();
            sw.Close();

            GetSet g = new GetSet();
            RefactorMethodEx(g);
            GetVal g1 = new GetVal();
            g1.Age = 23;
            g1.SetValue();
            Console.ReadLine();
        }

        private static void RefactorMethodEx(GetSet g)
        {
            g.Name = "Hinkal Manit Soni";
            g.SetValue();
        }
    }
}
