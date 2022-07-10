using System;

namespace Stealer
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            Console.WriteLine(spy.StealFieldInfo("Stealer.Hacker", "username","password"));
        }
    }
}
