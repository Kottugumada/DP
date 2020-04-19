using System;

namespace DP
{
    class Program
    {
        static void Main(string[] args)
        {
            EditDistance ed = new EditDistance();
            ed.MinDistance("HORSE","ROS");
            Console.ReadKey();
        }
    }
}
