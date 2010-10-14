namespace CsharpMonads.Tree.Samples
{
    using System;

    public class ChooseSample
    {
        private static Tree<int> Choose(int n)
        {
            return Fork.Leafs(n + 2, n + 5);
        }

        public static void RunSample()
        {
            Console.WriteLine();
            Console.WriteLine("Choose from 2");

            var tree =
                Leaf.New(0)
                    .Bind(Choose)
                    .Bind(Choose)
                    .Bind(Choose);

            Console.WriteLine(tree.PrettyPrint());
        }
    }
}