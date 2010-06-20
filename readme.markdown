Monads in C#
--

My first attempt of a maybe monad with SelectMany extension method and query expression syntax:

var m1 = Maybe.From(1);
var m2 = Maybe.From(5);

var result = from x in m1
             from y in m2
             select x + y;

result.Some.ShouldBeEqualTo(6);
