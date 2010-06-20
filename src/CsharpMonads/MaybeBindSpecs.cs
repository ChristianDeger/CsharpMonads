namespace CsharpMonads
{
    using Xunit;

    // All specs with binding using addition of ints.

    [Concern(typeof(MaybeBind))]
    public class when_binding_maybe_none_with_maybe_none : StaticContextSpecification
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

    [Concern(typeof(MaybeBind))]
    public class when_binding_maybe_none_with_maybe_some : StaticContextSpecification
    {
        private Maybe<int> _maybeNone;
        private Maybe<int> _maybeSome;
        private Maybe<int> _result;

        protected override void EstablishContext()
        {
            _maybeNone = Maybe<int>.None;
            _maybeSome = Maybe<int>.From(1);
        }

        protected override void Because()
        {
            _result = _maybeNone.SelectMany(m => _maybeSome, (x, y) => x + y);
        }

        [Observation]
        public void should_return_maybe_none()
        {
            _result.IsNone.ShouldBeTrue();            
        }
    }

    [Concern(typeof(MaybeBind))]
    public class when_binding_maybe_some_with_maybe_none : StaticContextSpecification
    {
        private Maybe<int> _maybeNone;
        private Maybe<int> _maybeSome;
        private Maybe<int> _result;

        protected override void EstablishContext()
        {
            _maybeNone = Maybe<int>.None;
            _maybeSome = Maybe<int>.From(1);
        }

        protected override void Because()
        {
            _result = _maybeSome.SelectMany(m => _maybeNone, (x, y) => x + y);
        }

        [Observation]
        public void should_return_maybe_none()
        {
            _result.IsNone.ShouldBeTrue();            
        }
    }

    [Concern(typeof(MaybeBind))]
    public class when_binding_maybe_some_with_maybe_some : StaticContextSpecification
    {
        private Maybe<int> _maybeSome1;
        private Maybe<int> _maybeSome2;
        private Maybe<int> _result;

        protected override void EstablishContext()
        {
            _maybeSome1 = Maybe<int>.From(1);
            _maybeSome2 = Maybe<int>.From(2);
        }

        protected override void Because()
        {
            _result = _maybeSome1.SelectMany(m => _maybeSome2, (x, y) => x + y);
        }

        [Observation]
        public void should_return_maybe_some_with_calculated_value()
        {
            _result.Some.ShouldBeEqualTo(3);
        }
    }
}