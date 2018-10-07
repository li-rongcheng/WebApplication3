using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMvc.CmdObjects
{
    public class CmdBase<TInput,TOutput>
    {
        public TInput Input { get; set; }
        public TOutput Output { get; set; }
    }

    public class Cmd1 : CmdBase<string, int> { }
       
    public class Cmd2 : CmdBase<Cmd1, int> { }

    public class Cmd3 : CmdBase<Cmd2, string> { }

    static public class Extensions
    {
        static public Cmd1 Foo()
        {
            return new Cmd1();
        }

        static public Cmd2 Foo2(this Cmd1 cmd1)
        {
            return new Cmd2();
        }

        static public Cmd3 Foo3(this Cmd2 cmd2)
        {
            return new Cmd3();
        }
    }

    public class Test
    {
        public void Bar()
        {
            Extensions.Foo().Foo2().Foo3();
        }
    }
}
