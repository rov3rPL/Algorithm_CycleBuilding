using System;
using Algorithm_CycleBuilding.FuncExtensions;

namespace Algorithm_CycleBuilding
{
    class BlockBuilder
    {
        internal int RealBlockBuildings { get; /*private*/ set; }

        internal BlockBuilder()
        {
            //_buildMemoized = _build.Memoize();
            _buildMemoized = _build;
            RealBlockBuildings = 0;
        }

        public bool Build(int timeOfBlockBuilding, int probabilityOfSuccessBlockBuilding,
            int offsetFromStart)
        {
            return _buildMemoized(this, timeOfBlockBuilding, probabilityOfSuccessBlockBuilding, offsetFromStart);
        }

        private Func<BlockBuilder, int, int, int, bool> _build = (BlockBuilder blockBuilder, int timeOfBlockBuilding, int probabilityOfSuccessBlockBuilding,
            int offsetFromStart) =>
        {
            //Console.WriteLine($"[OFFSET] {offsetFromStart}");
            System.Threading.Thread.Sleep(timeOfBlockBuilding);
            ++blockBuilder.RealBlockBuildings;
            var r = new System.Random();
            var rand = r.Next(100);
            return rand < probabilityOfSuccessBlockBuilding;
        };

        //private Func<int, int, int, bool> _buildMemoized;
        private Func<BlockBuilder, int, int, int, bool> _buildMemoized;

    }
}
