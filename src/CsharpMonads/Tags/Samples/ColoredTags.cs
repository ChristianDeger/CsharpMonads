namespace CsharpMonads.Tags.Samples
{
    using System;

    public class ColoredTags
    {
        public static void RunSample()
        {
            Console.WriteLine();
            Console.WriteLine("Colored tags:");

            var redTree = Red.Append(Red.New("bla"), Red.New("blub"));
            Console.WriteLine(redTree);

            var rolled = redTree.Roll();
            Console.WriteLine(rolled);

            var uppper = redTree.Bind(x=>x.ToUpper());
            Console.WriteLine(uppper);

            var blueTree = Blue.Append(Blue.New("blabla"), Blue.New("blubblub"));
            Console.WriteLine(blueTree);
        }
    }
}