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
        int capacity = enumerable is ICollection<T> c ? c.Count : enumerable is IReadOnlyCollection<T> rc ? rc.Count : 0;

        var result = new List<T>(capacity);

        await foreach (T item in enumerable.WithCancellation(cancellationToken)
                                           .ConfigureAwait(false))
        {
            result.Add(item);
        }

        return result;
    }
}