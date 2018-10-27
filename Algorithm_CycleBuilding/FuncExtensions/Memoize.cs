using System;
using System.Collections.Generic;

namespace Algorithm_CycleBuilding.FuncExtensions
{
    public static partial class FuncExtensions
    {
        //Eric Lippert https://stackoverflow.com/a/2852595

        public static Func<A, R> Memoize<A, R>(this Func<A, R> f)
        {
            var d = new Dictionary<A, R>();
            return a =>
            {
                //var arg = a as Tuple<BlockBuilder, int, int, int>;
                //Console.Write(String.Format("offset = {0}", arg.Item4));

                R r;
                if (!d.TryGetValue(a, out r))
                {
                    //Console.WriteLine(" -  wywołanie funkcji budowania bloku");
                    r = f(a);
                    d.Add(a, r);
                }
                //else
                //    Console.WriteLine();
                return r;
            };
        }

        public static Func<A, B, R> Memoize<A, B, R>(this Func<A, B, R> f)
        {
            return f.Tuplify().Memoize().Detuplify();
        }

        public static Func<A, B, C, R> Memoize<A, B, C, R>(this Func<A, B, C, R> f)
        {
            return f.Tuplify().Memoize().Detuplify();
        }

        public static Func<A, B, C, D, R> Memoize<A, B, C, D, R>(this Func<A, B, C, D, R> f)
        {
            return f.Tuplify().Memoize().Detuplify();
        }

        //public static Func<A, B, R> Memoize<A, B, R>(this Func<A, B, R> f)
        //{
        //    Func<Tuple<A, B>, R> tuplified = t => f(t.Item1, t.Item2);
        //    Func<Tuple<A, B>, R> memoized = tuplified.Memoize();
        //    return (a, b) => memoized(Tuple.Create(a, b));
        //}
    }
}
