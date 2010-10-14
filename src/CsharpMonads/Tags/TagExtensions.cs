namespace CsharpMonads.Tags
{
    using System;

    public static class TagExtensions
    {
        public static Tag<TColor, TResult> Bind<TColor, T, TResult>(this Tag<TColor, Tag<TColor, T>> tags, Func<T,TResult> f)
        {
            var result = new Tag<TColor,TResult>();
            foreach (var tag in tags)
            {
                foreach (var item in tag)
                {
                    result.Add(f(item));
                }
            }
            return result;
        }

        public static Tag<TColor, T> Roll<TColor, T>(this Tag<TColor, Tag<TColor, T>> tags)
        {
            return Bind(tags, x => x);
        }
    }
}