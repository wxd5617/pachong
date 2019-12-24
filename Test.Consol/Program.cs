using System;

namespace Test.Consol
{
    class Program
    {
        static void Main(string[] args)
        {
            var cc = MyClass.FnpFilter.ToString();
            string dd= "FNPRODUCTFILTER";
            Console.WriteLine($"{cc}{dd}");




        }
    }


    enum MyClass
    {
        FnpFilter
    }
}
