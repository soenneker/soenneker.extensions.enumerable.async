using Soenneker.Tests.FixturedUnit;
using Xunit;


namespace Soenneker.Extensions.Enumerable.Async.Tests;

[Collection("Collection")]
public class AsyncEnumerableExtensionTests : FixturedUnitTest
{
    public AsyncEnumerableExtensionTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
    }
}
