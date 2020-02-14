using System;

namespace Vector
{
using System;

namespace Vector{
    class Program
    {
        static void Main(string[] args)
        {
            Vector2 v2 = new Vector2(4, 4);
            Vector2 res = v2.Normalized();
            Console.WriteLine("Hello World! {0}", res);
        }
    }
}
}