using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Soenneker.Extensions.Enumerable.Async.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;
using Xunit.Abstractions;

namespace Soenneker.Extensions.Enumerable.Async.Tests;

[Collection("Collection")]
public class AsyncEnumerableExtensionTests : FixturedUnitTest
{
    private readonly IAsyncEnumerableExtension _extension;

    public AsyncEnumerableExtensionTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _extension = Resolve<IAsyncEnumerableExtension>(true);
    }
}
