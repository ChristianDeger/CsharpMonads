namespace CsharpMonads
{
    using System;
    using Tags.Samples;
    using Tree;
    using Tree.Samples;

    class Program
    {
        static void Main(string[] args)
        {
            ColoredTags.RunSample();
            ReplaceInTree.RunSample();
            ChooseSample.RunSample();            

            Console.ReadKey();
        }
    }
}