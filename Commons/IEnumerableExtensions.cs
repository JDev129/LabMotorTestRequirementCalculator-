using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commons
{
    public static class EnumerableExtensions
    {
        public static string BuildOutput<T>(
            this IEnumerable<T> @this,
            Func<T, string> builder) =>
            @this.Aggregate(new StringBuilder(), 
                (current, item) => current.Append(builder(item))).ToString();

        public static (bool successful, T successfullMatch) CheckEachForAMatch<T>(
            this IList<T> @this,
            Func<T, bool> check)
        {
            foreach (var item in @this)
                if (check(item))
                    return (true, item);
            return (false, (T)Activator.CreateInstance(typeof(T)));
        }

        public static string ForEachAdd<T>(
            this IList<T> @this,
            Func<T, string> TToString)
        {
            var res = string.Empty;
            foreach (var item in @this)
                res += TToString(item);
            return res;
        }

        public static IList<TypeFinish> ConvertListType<TypeStart, TypeFinish>(
            this IList<TypeStart> @this,
            Func<TypeStart, TypeFinish> Converter)
        {
            var res = new List<TypeFinish>();
            foreach (var item in @this)
                res.Add(Converter(item));
            return res;
        }

        public static IList<T> AddTo<T>(
            this IList<T> @this,
            T it)
        {
            @this.Add(it);
            return @this;
        }

        public static IList<T> AddWhen<T>(
            this IList<T> @this,
            Func<bool> condition,
            T it)
        {
            if(condition())
                @this.Add(it);
            return @this;
        }

        public static IEnumerable<T> ListOfOne<T>(
            this T @this) => new List<T>().AddTo(@this);

        public static IList<T> AddToWhen<T>(
            this IList<T> @this,
            IEnumerable<(Func<bool>, IEnumerable<T>)> addWhenItems)
        {
            foreach (var item in addWhenItems)
                if (item.Item1())
                    foreach (var addition in item.Item2)
                        @this.Add(addition);
            return @this;
        }

        public static IList<T> AddWhen<T>(
            this IList<T> @this,
            Func<bool> condition,
            IEnumerable<T> items)
        {
            if (condition())
                foreach (var addition in items)
                    @this.Add(addition);
            return @this;
        }

        public static List<T> AddItem<T>(
           this IList<T> @this,
           T value)
        {
            @this.Add(value);
            return @this.ToList();
        }
    }
}
