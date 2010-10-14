namespace CsharpMonads.Tree
{
    using System;
    using Xunit;

    public class TreeSample
    {
        static Tree<string> Replace(int value)
        {
            if (value == 2)
                return Fork.New(new Nil<string>(), Leaf.New("Two"));
            if (value == 3)
                return Fork.New(Leaf.New("Three"), Leaf.New("x"));

            throw new NotImplementedException();
        }

        public static void ReplaceTree()
        {
            var tree1 = Fork.New(Leaf.New(2), Leaf.New(3));
            Console.WriteLine(tree1.ToString());

            var tree2 = tree1.SelectMany(Replace);
            Console.WriteLine(tree2.ToString());
        }
    }
}