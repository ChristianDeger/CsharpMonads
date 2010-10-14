namespace CsharpMonads
{
    using System.Collections.Generic;
    using Xunit;

    public static class DictionaryExtension
    {
        public static Maybe<S> TryFind<T, S>(this Dictionary<T, S> dict, T key)
        {
            if (dict.ContainsKey(key))
            {
                return Maybe.From(dict[key]);
            }
            return Maybe<S>.None;
        }
    }

    public class DictionaryLookupSample
    {
        private static readonly Dictionary<string, string> employeeDept =
            new Dictionary<string, string>
                {
                    { "John", "Sales" },
                    { "Bob", "IT" }
                };

        private static readonly Dictionary<string, string> deptCountry =
            new Dictionary<string, string>
                {
                    { "IT", "USA" },
                    { "Sales", "France" }
                };

        private static readonly Dictionary<string, string> countryCurrency =
            new Dictionary<string, string>
                {
                    { "USA", "Dollar" },
                    { "France", "Euro" }
                };

        [Fact]
        public void DictionaryLookup()
        {
            Assert.Equal("Euro", LookUp("John").Some);
            Assert.True(LookUp("Steffen").IsNone);
        }

        private static Maybe<string> LookUp(string employee)
        {
            return from dept in employeeDept.TryFind(employee)
                   from country in deptCountry.TryFind(dept)
                   from currency in countryCurrency.TryFind(country)
                   select currency;
        }
    }
}