// https://github.com/dotnet/runtime/blob/main/docs/design/specs/runtime-async.md
// https://github.com/dotnet/runtime/issues/109632
// https://dev.to/iron-software/c-asyncawait-in-net-10-the-complete-technical-guide-for-2025-1cii

using System.Runtime.CompilerServices;

async Task<int> GetTheUltimateAnswerAsync()
{
    await Task.Yield();
    return 42;
}

/*
[MethodImpl(MethodImplOptions.Async)]
Task<int> GetTheUltimateAnswerAsync()
{
    YieldAwaitable.YieldAwaiter awaiter = Task.Yield().GetAwaiter();
    if (!awaiter.IsCompleted)
        AsyncHelpers.UnsafeAwaitAwaiter(awaiter);
    awaiter.GetResult();
    return Task.FromResult(42);
}
*/