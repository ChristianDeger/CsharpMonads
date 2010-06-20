namespace CsharpMonads
{
    using Xunit;

    [Concern(typeof(MaybeBind))]
    public class when_binding_a_maybe_none_with_maybe_none : StaticContextSpecification
    {
        private Maybe<int> _maybeNone1;
        private Maybe<int> _maybeNone2;
        private Maybe<int> _result;

        protected override void EstablishContext()
        {
            _maybeNone1 = Maybe<int>.None;
            _maybeNone2 = Maybe<int>.None;
        }

        protected override void Because()
        {
            _result = _maybeNone1.SelectMany(m => _maybeNone2, (x, y) => x + y);
        }

        [Observation]
        public void should_return_maybe_none()
        {
            _result.IsNone.ShouldBeTrue();
        }
    }
}