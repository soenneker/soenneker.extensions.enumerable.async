[![](https://img.shields.io/nuget/v/soenneker.extensions.enumerable.async.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.enumerable.async/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.enumerable.async/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.enumerable.async/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.extensions.enumerable.async.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.enumerable.async/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.enumerable.async/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.enumerable.async/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Extensions.Enumerable.Async
Extension methods for consuming, materializing, and transforming `IAsyncEnumerable<T>` streams with cancellation-aware asynchronous code.

## Installation

```bash
dotnet add package Soenneker.Extensions.Enumerable.Async
```

## Usage

```csharp
using Soenneker.Extensions.Enumerable.Async;

IAsyncEnumerable<Order> orders = StreamOrders();
List<Order> buffered = await orders.ToList(cancellationToken);
```

`ToList()` returns a `ValueTask<List<T>>` and fully consumes the source before completing. Items remain in source order. Cancellation is passed to the async enumerator; cancellation and enumeration failures propagate to the caller, and partial results are not returned.

The awaits use `ConfigureAwait(false)`. When the source exposes a count, that count is used only to pre-size the list; the source is still enumerated exactly once.
