namespace CsharpMonads
{
    using System;

    public class Maybe<T>
    {
        private bool _isNone;

        public Maybe()
        {
            _isNone = true;
        }

        public static Maybe<int> None
        {
            get { return new Maybe<int>(); }
        }

        public bool IsNone
        {
            get { return _isNone; }
        }

        public object Some
        {
            get { throw new InvalidOperationException(); }
        }
    }
}