namespace CsharpMonads.Tree.Samples
{
    using System;

    public class ChooseSample
    {
        private static Tree<int> Choose(int n)
        {
            return Fork.New(Leaf.New(n + 2), Leaf.New(n + 5));
        }

        public static void RunSample()
        {
            Console.WriteLine();
            Console.WriteLine("Choose from 2");

            var tree =
                Leaf.New(0)
                    .SelectMany(Choose)
                    .SelectMany(Choose)
                    .SelectMany(Choose);

            Console.WriteLine(tree);
        }
    }
}