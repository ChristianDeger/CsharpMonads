namespace CsharpMonads
{
    using System;
    using System.Collections.Generic;

    public static class MaybeExtensions
    {
        /// <summary>
        ///   Signature copied from IEnumerable
        /// </summary>
        public static Maybe<TResult> SelectMany<TSource, TMaybe, TResult>(
            this Maybe<TSource> source,
            Func<TSource, Maybe<TMaybe>> maybeSelector,
            Func<TSource, TMaybe, TResult> resultSelector)
        {
            if (source.IsNone)
            {
                return Maybe<TResult>.None;
            }

            var maybe = maybeSelector(source.Some);
            if (maybe.IsNone)
            {
                return Maybe<TResult>.None;
            }

            var result = resultSelector(source.Some, maybe.Some);
            return Maybe.From(result);
        }

        public static Maybe<U> SelectMany<T, U>(this Maybe<T> m, Func<T, Maybe<U>> k)
        {
            if (m.IsNone)
            {
                return Maybe<U>.None;
            }
            return k(m.Some);
        }

        public static Maybe<T> Concat<T>(this Maybe<T> source1, Maybe<T> source2)
        {
            return source1.IsNone
                       ? source2
                       : source1;
        }

        public static Maybe<S> TryFind<T, S>(this Dictionary<T, S> dict, T key)
        {
            if (dict.ContainsKey(key))
            {
                return Maybe.From(dict[key]);
            }
            return Maybe<S>.None;
        }
    }
}