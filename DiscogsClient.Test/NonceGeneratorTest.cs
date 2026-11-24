using DiscogsClient.Internal;
using FluentAssertions;
using System.Text.RegularExpressions;
using Xunit;

namespace DiscogsClient.Test
{
    public class NonceGeneratorTest
    {
        [Fact]
        public void Next_Returns_32_Lowercase_Hex_Characters()
        {
            var nonce = NonceGenerator.Next();

            nonce.Length.Should().Be(32);
            Regex.IsMatch(nonce, "^[0-9a-f]{32}$").Should().BeTrue();
        }

        [Fact]
        public void Next_Returns_Different_Values_On_Successive_Calls()
        {
            var first = NonceGenerator.Next();
            var second = NonceGenerator.Next();

            first.Should().NotBe(second);
        }
    }
}
