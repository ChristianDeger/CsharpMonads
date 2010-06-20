namespace CsharpMonads
{
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
    }
}