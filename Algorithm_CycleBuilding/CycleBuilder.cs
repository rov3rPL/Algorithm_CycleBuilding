using System;

namespace Algorithm_CycleBuilding
{
    class CycleBuilder
    {
        private int StartSpanInDays;
        private int NumberOfBlocks;
        private int DaySpan;
        private int TimeOfBlockBuilding;
        private int ProbabilityOfSuccessBlockBuilding;

        internal int NumberOfBlockBuildingTries { get; private set; }

        internal CycleBuilder(int startSpanInDays, int numberOfBlocks, int daySpan, int timeOfBlockBuilding, int probabilityOfSuccessBlockBuilding)
        {
            StartSpanInDays = startSpanInDays;
            NumberOfBlocks = numberOfBlocks;
            DaySpan = daySpan;
            TimeOfBlockBuilding = timeOfBlockBuilding;
            ProbabilityOfSuccessBlockBuilding = probabilityOfSuccessBlockBuilding;

            NumberOfBlockBuildingTries = 0;

            TimeSpan start = DateTime.Now.TimeOfDay;
            var success = Start(NumberOfBlocks);
            TimeSpan end = DateTime.Now.TimeOfDay;
            var diff = (end - start).TotalMilliseconds;
            Console.WriteLine($"[Success] {success} [Time] {diff} ms, Block building tries = {NumberOfBlockBuildingTries}");

        }

        private bool Start(int numberOfBlocks)
        {
            for(int i=0; i<StartSpanInDays; ++i)
            {
                var isSuccess = FindSolution(numberOfBlocks);
                if (isSuccess)
                    return true;
            }
            return false;
        }

        private bool FindSolution(int numberOfBlocks)
        {
            if (numberOfBlocks == 0)
                return true;

            for(int i=0; i<DaySpan; ++i)
            {
                var isBlock = TryToBuildBlock();
                if (isBlock)
                    return FindSolution(numberOfBlocks - 1);
            }
            return false;
        }
 
        private bool TryToBuildBlock()
        {
            System.Threading.Thread.Sleep(TimeOfBlockBuilding);
            ++NumberOfBlockBuildingTries;
            var r = new System.Random();
            var rand = r.Next(100);
            return rand < ProbabilityOfSuccessBlockBuilding;
        }

    }
}
