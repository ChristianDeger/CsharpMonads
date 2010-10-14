namespace CsharpMonads.Tree
{
    using System;

    public static class TreeExtensions
    {
        public static Tree<TResult> Bind<TSource, TResult>(
            this Tree<TSource> source, Func<TSource, Tree<TResult>> selector)
        {
            if (source is Nil<TSource>)
            {
                return new Nil<TResult>();
            }

            if (source is Leaf<TSource>)
            {
                return selector(((Leaf<TSource>)source).Value);
            }

            if (source is Fork<TSource>)
            {
                return Fork.New(
                    ((Fork<TSource>)source).Left.Bind(selector),
                    ((Fork<TSource>)source).Right.Bind(selector));
            }

            throw new NotImplementedException();
        }
    }
}