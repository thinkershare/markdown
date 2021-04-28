using Xunit;

namespace Thinkershare.Markdown.Test
{
    public class MarkdownShould
    {
        private readonly Markdown _markdown;
        public MarkdownShould()
        {
            _markdown = new Markdown();
        }

        [Fact]
        public void BeNullWhenParseNull()
        {
            var actual = _markdown.Parse(null);
            Assert.Null(actual);
        }

        [Fact]
        public void BeEmptyWhenParseEmpty()
        {
            var actual = _markdown.Parse(string.Empty);
            Assert.Empty(actual);
        }

        [Theory]
        [MemberData(nameof(TestData.TestData.BeResultWhenParseFromOuter), MemberType = typeof(TestData.TestData))]
        public void BeResultWhenParseText(string source, string expected)
        {
            var actual = _markdown.Parse(source);
            Assert.Equal(actual, expected);
        }
    }
}
