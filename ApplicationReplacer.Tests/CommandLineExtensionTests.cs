using Xunit;

namespace ApplicationReplacer.Tests
{
    public class CommandLineExtensionTests
    {
        [Theory]
        [InlineData(
            new string[0],
            "")]
        [InlineData(
            new[] { "" },
                    "\"\"")]
        [InlineData(
            new[] { "", "" },
                    "\"\" \"\"")]
        [InlineData(
            new[] { "no-spaces" },
                    "no-spaces")]
        [InlineData(
            new[] { "with spaces 1", "with spaces 2" },
                    "\"with spaces 1\" \"with spaces 2\"")]
        [InlineData(
            new[] { "with \"double\" quotes 1", "with \"double\" quotes 2" },
                    "\"with \"\"double\"\" quotes 1\" \"with \"\"double\"\" quotes 2\"")]
        public void EscapeArgument(string[] args, string expected)
        {
            Assert.Equal(expected, args.ToCommandLine());
        }
    }
}
