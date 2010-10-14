namespace CsharpMonads
{
    using System;

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

            Maybe<TMaybe> maybe = maybeSelector(source.Some);
            if (maybe.IsNone)
            {
                return Maybe<TResult>.None;
            }

            TResult result = resultSelector(source.Some, maybe.Some);
            return Maybe.From(result);
        }

        public static Maybe<U> SelectMany<T, U>(this Maybe<T> m, Func<T, Maybe<U>> k)
        {
            return m.IsNone
                       ? Maybe<U>.None
                       : k(m.Some);
        }

        public static Maybe<T> Concat<T>(this Maybe<T> source1, Func<Maybe<T>> source2F)
        {
            return source1.IsNone ? source2F() : source1;
        }
    }
}