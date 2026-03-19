namespace DreamBuildersLibs;

public interface ICommand
{
    void Execute();
    void Undo();
}