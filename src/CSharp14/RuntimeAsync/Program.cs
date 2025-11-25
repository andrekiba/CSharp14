// https://github.com/dotnet/runtime/blob/main/docs/design/specs/runtime-async.md
// https://github.com/dotnet/runtime/issues/109632
// https://dev.to/iron-software/c-asyncawait-in-net-10-the-complete-technical-guide-for-2025-1cii
using System.Runtime.CompilerServices;

async Task<int> DoThingAsync()
{
    await Task.Yield();
    return 42;
}

/*
[MethodImpl(MethodImplOptions.Async)]
Task<string> SayCiao()
{
#pragma warning disable SYSLIB5007
    AsyncHelpers.Await(Task.Delay(TimeSpan.FromSeconds(1)));
#pragma warning restore SYSLIB5007
    
    return "ciao";
}
*/