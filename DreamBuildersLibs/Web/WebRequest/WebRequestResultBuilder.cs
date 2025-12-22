namespace DreamBuildersLibs;

public class WebRequestResultBuilder<T>
{
    private T _result;
    private string _error;
    private bool _succeeded;
    private bool _isComplete;

    public WebRequestResultBuilder<T> WithResult(T result)
    {
        _result = result;

        return this;
    }

    public WebRequestResultBuilder<T> WithError(string error)
    {
        _error = error;

        return this;
    }

    public WebRequestResultBuilder<T> WithSucceeded(bool succeeded)
    {
        _succeeded = succeeded;

        return this;
    }

    public WebRequestResultBuilder<T> WithIsComplete(bool isComplete)
    {
        _isComplete = isComplete;

        return this;
    }

    public WebRequestResult<T> Build()
    {
        var webRequestResult = new WebRequestResult<T>();
        webRequestResult.Result = _result;
        webRequestResult.Error = _error;
        webRequestResult.Succeeded = _succeeded;
        webRequestResult.IsComplete = _isComplete;

        return webRequestResult;
    }
}