using FluentAssertions;
using Xunit;

namespace GasMeter.Tests
{
    public class APITests
    {
        [Fact]
        public void Test1()
        {
            var result = 2;
            result.Should().Be(2);
        }

        [Fact]
        public void Test2()
        {
            Assert.True(true);

        }
    }
}
