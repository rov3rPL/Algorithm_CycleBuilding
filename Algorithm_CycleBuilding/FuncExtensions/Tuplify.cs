using System;
using System.Collections.Generic;

namespace Algorithm_CycleBuilding.FuncExtensions
{
    public static partial class FuncExtensions
    {
        static Func<Tuple<A, B>, R> Tuplify<A, B, R>(this Func<A, B, R> f)
        {
            return t => f(t.Item1, t.Item2);
        }

        static Func<Tuple<A, B, C>, R> Tuplify<A, B, C, R>(this Func<A, B, C, R> f)
        {
            return t => f(t.Item1, t.Item2, t.Item3);
        }

        static Func<Tuple<A, B, C, D>, R> Tuplify<A, B, C, D, R>(this Func<A, B, C, D, R> f)
        {
            return t => f(t.Item1, t.Item2, t.Item3, t.Item4);
        }
    }
}
