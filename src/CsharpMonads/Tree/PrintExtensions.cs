namespace CsharpMonads.Tree
{
    using System;

    public static class PrintExtensions
    {
        public static string PrettyPrint<T>(this Tree<T> tree)
        {
            if (tree is Nil<T>)
            {
                return "Nil";
            }

            if (tree is Leaf<T>)
            {
                return string.Format("Leaf({0})", ((Leaf<T>)tree).Value);
            }

            if (tree is Fork<T>)
            {
                return string.Format(
                    "Fork({0},{1})",
                    ((Fork<T>)tree).Left.PrettyPrint(),
                    ((Fork<T>)tree).Right.PrettyPrint());
            }

            throw new NotImplementedException();
        }
    }
}