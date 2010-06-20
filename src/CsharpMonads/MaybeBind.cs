namespace CsharpMonads
{
    using System;

    public static class MaybeBind
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
    }
}