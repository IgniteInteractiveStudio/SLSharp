using System;
using System.Collections.Generic;

namespace IIS.SLSharp
{
    public static class Extensions
    {
        public static TSource Max<TSource, TSelect>(this IEnumerable<TSource> source, Func<TSource, TSelect> selector)
            where TSelect : IComparable<TSelect>
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (selector == null)
                throw new ArgumentNullException("selector");

            var enumer = source.GetEnumerator();
 
            enumer.MoveNext();
            var maxItem = enumer.Current;
            var maxValue = selector(maxItem);

            while (enumer.MoveNext())
            {
                var currentItem = enumer.Current;
                var currentValue = selector(currentItem);

                if (currentValue.CompareTo(maxValue) <= 0)
                    continue;

                maxItem = currentItem;
                maxValue = currentValue;
            }

            return maxItem;
        }

        public static TSource Min<TSource, TSelect>(this IEnumerable<TSource> source, Func<TSource, TSelect> selector)
            where TSelect : IComparable<TSelect>
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (selector == null)
                throw new ArgumentNullException("selector");

            var enumer = source.GetEnumerator();

            enumer.MoveNext();
            var minItem = enumer.Current;
            var minValue = selector(minItem);

            while (enumer.MoveNext())
            {
                var currentItem = enumer.Current;
                var currentValue = selector(currentItem);

                if (currentValue.CompareTo(minValue) >= 0)
                    continue;

                minItem = currentItem;
                minValue = currentValue;
            }

            return minItem;
        }
    }
}
