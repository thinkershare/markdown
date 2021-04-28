using Thinkershare.Markdown.Extensions;
using Xunit;

namespace Thinkershare.Markdown.Test.Extensions
{
    public class StringExtensionsShould
    {
        [Fact]
        public void BeEqualsWhenEscape()
        {
            const string inputOne = "<p>&nbsp; content &gt;";
            const string expectedOne = "&lt;p&gt;&nbsp; content &gt;";

            var actualOne = inputOne.Escape();
            Assert.Equal(expectedOne, actualOne);

            const string inputTwo = "content &gt; content";
            const string expectedTwo = "content &amp;gt; content";

            var actualTwo = inputTwo.Escape(true);
            Assert.Equal(expectedTwo, actualTwo);
        }
    }
}
