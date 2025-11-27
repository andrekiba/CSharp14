async Task<int> GetTheUltimateAnswerAsync()
{
    await Task.Yield();
    return 42;
}