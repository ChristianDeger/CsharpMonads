namespace CsharpMonads.Tree.Samples
{
    using System;

    public class ReplaceInTree
    {
        private static Tree<string> ReplaceIntWithSubtree(int value)
        {
            switch (value)
            {
                case 2:
                    return Fork.New(new Nil<string>(), Leaf.New("Two"));
                case 3:
                    return Fork.New(Leaf.New("Three"), Leaf.New("x"));
                default:
                    return Leaf.New(value.ToString());
            }
        }

        public static void RunSample()
        {
            Console.WriteLine();
            Console.WriteLine("Replace in tree:");

            var tree1 = Fork.New(Leaf.New(2), Leaf.New(3));
            Console.WriteLine(tree1.PrettyPrint());

            var tree2 = tree1.Bind(ReplaceIntWithSubtree);
            Console.WriteLine(tree2.PrettyPrint());
        }
    }
}