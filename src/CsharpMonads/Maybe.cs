namespace CsharpMonads
{
    using System;

    public class Maybe<T>
    {
        private readonly bool _isNone;
        private readonly T _some;

        private Maybe(T value)
        {
            _some = value;
        }

        private Maybe()
        {
            _isNone = true;
        }

        public static Maybe<T> None
        {
            get { return new Maybe<T>(); }
        }

        public static Maybe<T> From(T value)
        {
            return new Maybe<T>(value);
        }

        public bool IsNone
        {
            get { return _isNone; }
        }

        public T Some
        {
            get
            {
                if (_isNone)
                {
                    throw new InvalidOperationException("Maybe is none");
                }

                return _some;
            }
        }

        public override string ToString()
        {
            if (_isNone)
            {
                return "None: " + typeof(T).FullName;
            }

            return _some.ToString();
        }
    }

    public static class Maybe
    {
        public static Maybe<T> From<T>(T value)
        {
            return Maybe<T>.From(value);
        }
    }
}