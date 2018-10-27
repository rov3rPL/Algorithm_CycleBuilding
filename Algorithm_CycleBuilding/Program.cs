using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_CycleBuilding
{
    class Program
    {
        static void Main(string[] args)
        {
            //var cycleBuilder = new CycleBuilder(6, 13, 5, 30, 2); //576 ms

            //var cycleBuilder = new CycleBuilder(7, 10, 2, 20, 33); //480 ms

            //var cycleBuilder = new CycleBuilder(14, 10, 2, 20, 10); //660-695 ms

            //var cycleBuilder = new CycleBuilder(14, 10, 2, 40, 10); //1352 ms

            //var cycleBuilder = new CycleBuilder(14, 12, 5, 15, 20); //False [Time] 3584,9881 ms

            //var cycleBuilder = new CycleBuilder(14, 12, 5, 15, 20, true);

            var cycleBuilder = new CycleBuilder(14, 12, 5, 5, 20, true);

            //var cycleBuilder = new CycleBuilder(14, 12, 5, 15, 20, true);

            Console.ReadLine();
        }
    }
}
