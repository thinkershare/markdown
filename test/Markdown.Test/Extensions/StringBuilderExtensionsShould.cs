using System.Text;
using Thinkershare.Markdown.Extensions;
using Xunit;

namespace Thinkershare.Markdown.Test.Extensions
{
    public class StringBuilderExtensionsShould
    {
        [Theory]
        [InlineData("    \n", "\n")]
        [InlineData("\n       ", "\n")]
        [InlineData(" 1\n  \n  1\n1\n  ", " 1\n\n  1\n1\n")]
        [InlineData("1\n  \n  1\n1  \n 1 \n1\n", "1\n\n  1\n1  \n 1 \n1\n")]
        public void BeEqualsWhenClearWhitespace(string input, string expected)
        {
            var builder = new StringBuilder(input);

            builder.ClearWhitespace();
            var actual = builder.ToString();

            Assert.Equal(expected, actual);
        }
    }
}
