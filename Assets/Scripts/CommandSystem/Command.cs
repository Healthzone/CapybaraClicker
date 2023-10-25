public abstract class Command
{
    public abstract void Execute();

    public  bool IsFinished { get; protected set; }
}
