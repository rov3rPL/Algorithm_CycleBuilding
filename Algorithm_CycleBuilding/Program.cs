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

            //var cycleBuilder = new CycleBuilder(14, 12, 5, 5, 20, true); //120 ms

            //var cycleBuilder2 = new CycleBuilder(14, 12, 5, 5, 20, false); //600 ms

            //var cycleBuilder3 = new CycleBuilder(14, 10, 2, 5, 10, true); //102-104-122 ms

            //var cycleBuilder4 = new CycleBuilder(14, 10, 2, 5, 10, false); //165-176-190-199 ms

            //var cycleBuilder5 = new CycleBuilder(14, 10, 2, 5, 20, true); //104 ms

            //var cycleBuilder6 = new CycleBuilder(14, 10, 2, 5, 20, false); //230 ms

            //var cycleBuilder6 = new CycleBuilder(14, 10, 2, 5, 70, true); //159 ms

            //var cycleBuilder7 = new CycleBuilder(14, 10, 2, 5, 70, false); //374 ms

            //var cycleBuilder8 = new CycleBuilder(14, 10, 2, 5, 100, true); //79-93 ms

            //var cycleBuilder9 = new CycleBuilder(14, 10, 2, 5, 100, false); //53-57 ms

            //var cycleBuilder10 = new CycleBuilder(6, 13, 5, 5, 2, true); //74 ms

            //var cycleBuilder11 = new CycleBuilder(6, 13, 5, 5, 2, false); //175 ms

            //var cycleBuilder = new CycleBuilder(1, 3, 2, 5, 0, true);
            //var cycleBuilder = new CycleBuilder(2, 3, 2, 5, 0, true);
            //var cycleBuilder = new CycleBuilder(14, 10, 2, 5, 0, true);

            //2 441 406 ?
            //var cycleBuilder = new CycleBuilder(1, 10, 5, 5, 0, true);
            //var cycleBuilder21 = new CycleBuilder(1, 2, 5, 5, 0, true);
            //var cycleBuilder22 = new CycleBuilder(1, 3, 5, 5, 0, true);
            //var cycleBuilder = new CycleBuilder(14, 10, 5, 5, 0, true);

            //[6,7,10,14], [10,12,13] [2,5] [5,15,20,30,40] [2,5,10,20,33,50,70,100] [true,false] //1920 kombinacji x 100 prób = 192 000 wyników

            //[14] [12] [5] [5,40]  [2,5,10,20,33,50,70,100] [true,false] //32 * 100 = 3200

            //Min z 100 wywołań, Max  z 100 wywołań, Avg z 100 wywołań

            int N_SAMPLES = 100;
            var test_StartDays = new int[] { 14 };
            var test_NumberOfBlocks = new int[] { 12 };
                    //var test_SpanDays = new int[] { 2, 5 };
            //var test_SpanDays = new int[][] { new int[2] { 1, 2 }, new int[2] { 1, 5 } };
            var test_SpanDays = new int[][] { new int[2] { 2, 3 } };
            var test_TimeOfBlockBuilding = new int[] { 40, 5 };
            var test_ProbabilityOfBlockBuilding =
                                        //new int[] { 2, 5, 10, 20, 33, 50, 70, 100 };
                                        new int[] { -1 }; //test pesymistyczny1
                                        //new int[] { 100 };
            var test_UseMemoization = new bool[] {
                false,
                true
            };

            for(var i=0; i< test_StartDays.Length; ++i)
            {
                for (var j = 0; j < test_NumberOfBlocks.Length; ++j)
                {
                    for (var k = 0; k < test_SpanDays.Length; ++k)
                    {
                        for (var m = 0; m < test_ProbabilityOfBlockBuilding.Length; ++m)
                        {
                            for (var n = 0; n < test_TimeOfBlockBuilding.Length; ++n)
                            {
                                for (var p = 0; p < test_UseMemoization.Length; ++p)
                                {
                                    for (int z = 0; z < N_SAMPLES; ++z)
                                    {
                                        Console.Write($"StartDays = {test_StartDays[i]}, NumberOfBlocks = {test_NumberOfBlocks[j]}, SpanDays = {test_SpanDays[k]}, TimeOfBlockBuilding = {test_TimeOfBlockBuilding[n]}, ProbabilityOfBlockBuilding = {test_ProbabilityOfBlockBuilding[m]}, UseMemoization = {test_UseMemoization[p]} ");
                                        var cycleBuilder = new CycleBuilder(
                                            test_StartDays[i],
                                            test_NumberOfBlocks[j],
                                            test_SpanDays[k][0], //span days from
                                            test_SpanDays[k][1], //span days to
                                            test_TimeOfBlockBuilding[n],
                                            test_ProbabilityOfBlockBuilding[m],
                                            test_UseMemoization[p]
                                        );
                                    }

                                    Console.WriteLine();
                                    Console.WriteLine();
                                }
                            }

                        }
                    }
                }

            }

            Console.ReadLine();
        }
    }
}
