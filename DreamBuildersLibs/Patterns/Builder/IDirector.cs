namespace DreamBuildersLibs;

public interface IDirector<T>
{
    public T Construct(IBuilder<T> builder);
}