namespace CsharpMonads
{
    using Xunit;

    public class MaybeUsage
    {
        [Fact]
        public void UsingSelectManyToAdd()
        {
            var m1 = Maybe.From(1);
            var m2 = Maybe.From(5);

            var result = m1.SelectMany(x => m2, (x, y) => x + y);
            
            result.Some.ShouldBeEqualTo(6);
        }

        [Fact]
        public void UsingQueryExpressionToAdd()
        {
            var m1 = Maybe.From(1);
            var m2 = Maybe.From(5);

            var result = from x in m1
                         from y in m2
                         select x + y;

            result.Some.ShouldBeEqualTo(6);
        }
    }
}