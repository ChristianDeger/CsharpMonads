namespace CsharpMonads.Tags
{
    using System.Collections.Generic;
    using System.Linq;

    public class Tag<TColor, T> : List<T>
    {
        public override string ToString()
        {
            var s = string.Format("<{0}>", typeof(TColor).Name);
            s = this.Aggregate(s, (current, item) => current + item);
            return string.Format("{0}</{1}>", s, typeof(TColor).Name);
        }
    }

    public class Red
    {
        public static Tag<Red, T> New<T>(T value)
        {
            return new Tag<Red, T> { value };
        }

        public static Tag<Red, Tag<Red,T>> Append<T>(Tag<Red,T> value1, Tag<Red,T> value2)
        {
            return new Tag<Red, Tag<Red, T>> { value1, value2 };
        }
    }

    public class Blue
    {
        public static Tag<Blue, T> New<T>(T value)
        {
            return new Tag<Blue, T> { value };
        }

        public static Tag<Blue, Tag<Blue, T>> Append<T>(Tag<Blue, T> value1, Tag<Blue, T> value2)
        {
            return new Tag<Blue, Tag<Blue, T>> { value1, value2 };
        }
    }
}