namespace CsharpMonads.Tree
{
    public abstract class Tree<T>
    {
    }

    public class Nil<T> : Tree<T>
    {
    }

    public class Leaf<T> : Tree<T>
    {
        public Leaf(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
    }

    public class Fork<T> : Tree<T>
    {
        public Fork(Tree<T> left, Tree<T> right)
        {
            Left = left;
            Right = right;
        }

        public Tree<T> Left { get; set; }
        public Tree<T> Right { get; set; }
    }

    public static class Leaf
    {
        internal static Tree<T> New<T>(T value)
        {
            return new Leaf<T>(value);
        }
    }

    public static class Fork
    {
        internal static Tree<T> New<T>(Tree<T> left, Tree<T> right)
        {
            return new Fork<T>(left, right);
        }

        internal static Tree<T> Leafs<T>(T left, T right)
        {
            return New(Leaf.New(left), Leaf.New(right));
        }
    }
}