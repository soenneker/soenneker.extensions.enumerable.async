using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Threading;
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
    public static async ValueTask<List<T>> ToList<T>(this IAsyncEnumerable<T> enumerable, CancellationToken cancellationToken = default)
    {
        // Pre-allocate capacity if enumerable is a known-size collection
        int initialCapacity = enumerable is ICollection<T> collection ? collection.Count : 0;
        var result = initialCapacity > 0 ? new List<T>(initialCapacity) : new List<T>();

        await foreach (T item in enumerable.ConfigureAwait(false).WithCancellation(cancellationToken))
        {
            result.Add(item);
        }

        return result;
    }
}
