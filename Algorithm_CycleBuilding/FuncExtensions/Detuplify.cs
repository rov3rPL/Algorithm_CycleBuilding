using System;
using System.Collections.Generic;

namespace Algorithm_CycleBuilding.FuncExtensions
{
    public static partial class FuncExtensions
    {
        static Func<A, B, R> Detuplify<A, B, R>(this Func<Tuple<A, B>, R> f)
        {
            return (a, b) => f(Tuple.Create(a, b));
        }

        static Func<A, B, C, R> Detuplify<A, B, C, R>(this Func<Tuple<A, B, C>, R> f)
        {
            return (a, b, c) => f(Tuple.Create(a, b, c));
        }

        static Func<A, B, C, D, R> Detuplify<A, B, C, D, R>(this Func<Tuple<A, B, C, D>, R> f)
        {
            return (a, b, c, d) => f(Tuple.Create(a, b, c, d));
        }
    }
}
