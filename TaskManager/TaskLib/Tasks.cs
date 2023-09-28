using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLib
{
    //Define delegates
    public delegate void Method0();
    public delegate void Method1(TaskOptions options);

    //Define base class
    public abstract class Task
    {
        protected TaskOptions Options { get; set; }
        public abstract void Run();
    }

    //Define variant classes
    public class Task0 : Task
    {
        protected Method0 method;
        public Task0(Method0 method)
        {
            this.method = method;
        }
        public override void Run()
        {
            method();
        }
    }

    public class Task1 : Task
    {
        protected Method1 method;
        public Task1(Method1 method, TaskOptions options)
        {
            this.method = method;
            Options = options;
        }
        public override void Run()
        {
            method(Options);
        }
    }

    /*
    public class Task2 : Task
    {
        protected Method2 method;
        public Task2(Method2 method, string arg1, string arg2)
        {
            this.method = method;
            TaskArguments[0] = arg1;
            TaskArguments[1] = arg2;
        }
        public override void Run()
        {
            method(TaskArguments[0], TaskArguments[1]);
        }
    }
    */
}
