namespace CsharpMonads
{
    using System;
    using Xunit;

    [Concern(typeof(Maybe<int>))]
    public class when_creating_a_maybe_monad_without_value : InstanceContextSpecification<Maybe<int>>
    {
        protected override Maybe<int> CreateSut()
        {
            return Maybe<int>.None;
        }

        protected override void Because()
        {
            // ctor        
        }

        [Observation]
        public void should_be_none()
        {
            Sut.IsNone.ShouldBeTrue();
        }

        [Observation]
        public void should_not_be_possible_to_read_some()
        {
            Action access = () => Ignore.Return(Sut.Some);
            access.ShouldThrowAn<InvalidOperationException>();
        }

        [Observation]
        public void should_display_none_with_type()
        {
            Sut.ToString().ShouldBeEqualTo("None: System.Int32");
        }
    }

    [Concern(typeof(Maybe<int>))]
    public class when_creating_a_maybe_monad_with_value : InstanceContextSpecification<Maybe<int>>
    {
        private int _value;

        protected override void EstablishContext()
        {
            _value = 1;
        }

        protected override Maybe<int> CreateSut()
        {
            return Maybe.From(_value);
        }

        protected override void Because()
        {
            // ctor
        }

        [Observation]
        public void should_some_return_value()
        {
            Sut.Some.ShouldBeEqualTo(_value);
        }

        [Observation]
        public void should_not_be_none()
        {
            Sut.IsNone.ShouldBeFalse();
        }
        
        [Observation]
        public void should_display_value()
        {
            Sut.ToString().ShouldBeEqualTo(_value.ToString());
        }
    }
}