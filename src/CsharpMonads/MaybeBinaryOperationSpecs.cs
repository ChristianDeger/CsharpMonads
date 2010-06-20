namespace CsharpMonads
{
    using Xunit;

    [Concern(typeof(MaybeBinaryOperation))]
    public class when_using_a_binary_operation_on_two_maybe_monads : StaticContextSpecification
    {
        private Maybe<int> _maybe1;
        private Maybe<int> _maybe2;
        private Maybe<int> _result;

        protected override void EstablishContext()
        {
            _maybe1 = Maybe.From(1);
            _maybe2 = Maybe.From(2);
        }

        protected override void Because()
        {
            _result = _maybe1.Operate(_maybe2, (x, y) => x + y);
        }

        [Observation]
        public void should_return_maybe_monad_with_calculated_result()
        {
            _result.Some.ShouldBeEqualTo(3);
        }
    }

    [Concern(typeof(MaybeBinaryOperation))]
    public class when_adding_to_int_maybe_monads : StaticContextSpecification
    {
        private Maybe<int> _maybe1;
        private Maybe<int> _maybe2;
        private Maybe<int> _result;

        protected override void EstablishContext()
        {
            _maybe1 = Maybe.From(1);
            _maybe2 = Maybe.From(2);
        }

        protected override void Because()
        {
            _result = _maybe1.Add(_maybe2);
        }

        [Observation]
        public void should_return_sum()
        {
            _result.Some.ShouldBeEqualTo(3);            
        }
    }
}