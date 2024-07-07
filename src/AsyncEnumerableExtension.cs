using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace Soenneker.Extensions.Enumerable.Async;

/// <summary>
/// A collection of helpful AsyncEnumerable extension methods
/// </summary>
public static class AsyncEnumerableExtension
{
    /// <summary>
    /// Iterates through the async enumerable, awaiting
    /// </summary>
    /// <remarks>Does not maintain synchronization context</remarks>
    [Pure]
    public static async ValueTask<List<T>> ToList<T>(this IAsyncEnumerable<T> enumerable)
    {
        var result = new List<T>();

        await foreach (T item in enumerable.ConfigureAwait(false))
        {
            result.Add(item);
        }

        return result;
    }
}
