using System;
using System.Collections.Generic;

namespace HunterSim
{
    public static class ExtensionMethods
    {
        public static void AddRange<T>(this IList<T> list, IEnumerable<T> range)
        {
            range.ForEach(x => list.Add(x));
        }

        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (var item in list)
            {
                action(item);
            }
        }
    }
}
