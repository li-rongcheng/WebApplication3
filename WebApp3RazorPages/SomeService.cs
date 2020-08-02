using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp3RazorPages
{
    public interface ISomeService
    {
        void DoSomething();
    }

    public class SomeService : ISomeService
    {
        public void DoSomething()
        {
            Console.WriteLine("SomeService.DoSomething() called!!");
            var files = Directory.GetFiles("c:\\");
            foreach(var f in files)
            {
                Console.WriteLine(f);
            }
            Console.WriteLine("");
        }
    }
}
