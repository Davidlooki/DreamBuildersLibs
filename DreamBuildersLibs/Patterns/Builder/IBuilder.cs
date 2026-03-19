namespace DreamBuildersLibs;

public interface IBuilder<out T>
{
    public T Build();
}