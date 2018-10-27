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
        
        private BlockBuilder BlockBuilder { get; set; }

        internal CycleBuilder(int startSpanInDays, int numberOfBlocks, int daySpan, int timeOfBlockBuilding, int probabilityOfSuccessBlockBuilding,
            bool memoizeBuiltBlocks)
        {
            StartSpanInDays = startSpanInDays;
            NumberOfBlocks = numberOfBlocks;
            DaySpan = daySpan;
            TimeOfBlockBuilding = timeOfBlockBuilding;
            ProbabilityOfSuccessBlockBuilding = probabilityOfSuccessBlockBuilding;

            NumberOfBlockBuildingTries = 0;

            BlockBuilder = new BlockBuilder();

            TimeSpan start = DateTime.Now.TimeOfDay;
            var success = Start(NumberOfBlocks);
            TimeSpan end = DateTime.Now.TimeOfDay;
            var diff = (end - start).TotalMilliseconds;
            Console.WriteLine($"[Success] {success} [Time] {diff} ms, Block building tries = {NumberOfBlockBuildingTries}, Real block buildings = {BlockBuilder.RealBlockBuildings}");

        }

        private bool Start(int numberOfBlocks)
        {
            for(int i=0; i<StartSpanInDays; ++i)
            {
                var isSuccess = FindSolution(numberOfBlocks, i);
                if (isSuccess)
                    return true;
            }
            return false;
        }

        private bool FindSolution(int numberOfBlocks, int offsetFromStart)
        {
            //Console.WriteLine("FindSolution numberOfBlocks = {0}, offsetFromStart = {1}", numberOfBlocks, offsetFromStart);
            if (numberOfBlocks == 0)
                return true;

            for(int i=1; i<=DaySpan; ++i)
            {
                var isBlock = TryToBuildBlock(offsetFromStart + i);
                if (isBlock)
                    return FindSolution(numberOfBlocks - 1, offsetFromStart + i);
            }
            return false;
        }
 
        private bool TryToBuildBlock(int offsetFromStart)
        {
            var blockBuildingResult = BlockBuilder.Build(TimeOfBlockBuilding, ProbabilityOfSuccessBlockBuilding, offsetFromStart);

            ++NumberOfBlockBuildingTries;

            return blockBuildingResult;
        }

    }
}
