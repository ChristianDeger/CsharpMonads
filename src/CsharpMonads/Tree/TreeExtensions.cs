namespace CsharpMonads.Tree
{
    using System;

    public static class TreeExtensions
    {
        public static Tree<TResult> SelectMany<TSource, TResult>(
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
                    ((Fork<TSource>)source).Left.SelectMany(selector), 
                    ((Fork<TSource>)source).Right.SelectMany(selector));
            }

            throw new NotImplementedException();
        }
    }
}