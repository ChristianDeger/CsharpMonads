namespace CsharpMonads
{
    using System.Collections.Generic;
    using Xunit;

    public class HaskellLookupSample
    {
        private static readonly Dictionary<string, string> FullNamesDb =
            new Dictionary<string, string>
                {
                    { "Bill Gates", "billg@microsoft.com" },
                    { "Bill Clinton", "bill@hope.ar.us" },
                    { "Michael Jackson", "mj@wonderland.org" }
                };

        private static readonly Dictionary<string, string> NickNamesDb =
            new Dictionary<string, string>
                {
                    { "billy", "billg@microsoft.com" },
                    { "slick willy", "bill@hope.ar.us" },
                    { "jacko", "mj@wonderland.org" }
                };

        private static readonly Dictionary<string, string> PrefsDb =
            new Dictionary<string, string>
                {
                    { "billg@microsoft.com", "HTML" },
                    { "bill@hope.ar.us", "Plain" },
                    { "mj@wonderland.org", "HTML" }
                };

        [Fact]
        public void DictionaryLookup()
        {
            Assert.Equal("HTML", LookUp("billy").Some);
            Assert.Equal("HTML", LookUp("Bill Gates").Some);
            Assert.True(LookUp("Steffen").IsNone);
        }

        private static Maybe<string> LookUp(string text)
        {
            return
                FullNamesDb.TryFind(text)
                    .Concat(NickNamesDb.TryFind(text))
                    .SelectMany(y => PrefsDb.TryFind(y));
        }
    }
}