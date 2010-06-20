namespace CsharpMonads
{
    using System;

    public static class MaybeBinaryOperation
    {
        public static Maybe<T> Operate<T>(
            this Maybe<T> left,
            Maybe<T> right,
            Func<T, T, T> operation)
        {
            return left.SelectMany(x => right, operation);
        }

        public static Maybe<int> Add(this Maybe<int> left, Maybe<int> right)
        {
            return Operate(left, right, (x, y) => x + y);
        }
    }
}