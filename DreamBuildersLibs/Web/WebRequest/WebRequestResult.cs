namespace DreamBuildersLibs;

public struct WebRequestResult<T> : IDisposable
{
    public T Result;
    public string Error;
    public bool Succeeded;
    public bool IsComplete;
    
    public void Dispose() { }
}