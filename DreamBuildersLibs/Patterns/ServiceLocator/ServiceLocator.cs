namespace DreamBuildersLibs;

public static class ServiceLocator
{
    private static readonly Dictionary<string, IService> _services = new();

    public static void Register<T>(T service) where T : class, IService
    {
        string serviceName = GetServiceName<T>();

        if (!string.IsNullOrWhiteSpace(serviceName) && !_services.TryAdd(serviceName, service))
        {
            //TODO: Throw warning about already registered service.
        }
    }

    /// <summary>
    /// Unregister the service and if it inherits IDisposable, Dispose, unless check to false.
    /// </summary>
    public static void Unregister<T>(bool tryDispose = true) where T : class, IService
    {
        if (!_services.Remove(GetServiceName<T>(), out IService service))
        {
            //TODO: Throw warning about Could not Unregister service. Service not found!

            return;
        }

        if (tryDispose && service is IDisposable disposable)
            disposable.Dispose();
    }

    public static bool TryGet<T>(out T service) where T : class, IService
    {
        if (!_services.TryGetValue(GetServiceName<T>(), out var foundService))
        {
            //TODO: Throw warning about Could not locate service.
                
            service = null!;

            return false;
        }

        service = (foundService as T)!;

        return true;
    }

    private static string GetServiceName<T>() => typeof(T).FullName!;
}