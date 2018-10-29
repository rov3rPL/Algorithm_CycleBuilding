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
        
        internal bool RunPesimistic { get; private set; }

        private BlockBuilder BlockBuilder { get; set; }

        internal CycleBuilder(int startSpanInDays, int numberOfBlocks, int daySpan, int timeOfBlockBuilding, int probabilityOfSuccessBlockBuilding,
            bool memoizeBuiltBlocks, bool runPesimistic = false)
        {
            StartSpanInDays = startSpanInDays;
            NumberOfBlocks = numberOfBlocks;
            DaySpan = daySpan;
            TimeOfBlockBuilding = timeOfBlockBuilding;
            ProbabilityOfSuccessBlockBuilding = probabilityOfSuccessBlockBuilding;

            NumberOfBlockBuildingTries = 0;

            RunPesimistic = runPesimistic;

            BlockBuilder = new BlockBuilder(memoizeBuiltBlocks);

            TimeSpan start = DateTime.Now.TimeOfDay;
            var success = Start(NumberOfBlocks);
            TimeSpan end = DateTime.Now.TimeOfDay;
            var diff = (end - start).TotalMilliseconds;
            Console.WriteLine($"[Success] {success} [Time] {diff} ms, Block building tries = {NumberOfBlockBuildingTries}, Real block buildings = {BlockBuilder.RealBlockBuildings}, Memoization: {memoizeBuiltBlocks}");

        }

        private bool Start(int numberOfBlocks)
        {
            for(int i=0; i<StartSpanInDays; ++i)
            {
                var isBlock = TryToBuildBlock(i, GetProbabilityOfSuccessBlockBuilding(numberOfBlocks), numberOfBlocks); //go down to every leaf
                if (isBlock)
                {
                    --numberOfBlocks;
                    var isSuccess = FindSolution(numberOfBlocks, i);
                    if (isSuccess)
                        return true;
                    ++numberOfBlocks;
                }
            }
            return false;
        }

        private bool FindSolution(int numberOfBlocks, int offsetFromStart)
        {
            ////Console.WriteLine("FindSolution numberOfBlocks = {0}, offsetFromStart = {1}", numberOfBlocks, offsetFromStart);
            if (numberOfBlocks == 0)
                return true;

            for(int i=1; i<=DaySpan; ++i)
            {
                var isBlock = TryToBuildBlock(offsetFromStart + i, GetProbabilityOfSuccessBlockBuilding(numberOfBlocks), numberOfBlocks); //go down to every leaf
                if (isBlock)
                {
                    var solution = FindSolution(numberOfBlocks - 1, offsetFromStart + i);
                    if (solution)
                        return solution;
                }
            }
            //Console.WriteLine();
            return false;
        }
 
        private bool TryToBuildBlock(int offsetFromStart, int probabilityOfSuccessBlockBuilding, int numberOfBlocks)
        {
            //Console.Write($"-{offsetFromStart} ({numberOfBlocks})");
            var blockBuildingResult = BlockBuilder.Build(TimeOfBlockBuilding, probabilityOfSuccessBlockBuilding, offsetFromStart);

            ++NumberOfBlockBuildingTries;

            return blockBuildingResult;
        }

        private int GetProbabilityOfSuccessBlockBuilding(int blockNumber)
        {
            return RunPesimistic ? (blockNumber != 1 ? 100 : 0) : ProbabilityOfSuccessBlockBuilding;
        }
    }
}
