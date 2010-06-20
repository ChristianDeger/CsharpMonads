namespace CsharpMonads
{
    using System;

    public static class MaybeBind
    {
        /// <summary>
        /// Signature copied from IEnumerable
        /// </summary>
        public static Maybe<TResult> SelectMany<TSource, TMaybe, TResult>(
            this Maybe<TSource> source,
            Func<TSource, Maybe<TMaybe>> maybeSelector,
            Func<TSource, TMaybe, TResult> resultSelector)
        {
            return Maybe<TResult>.None;
        }
    }
}