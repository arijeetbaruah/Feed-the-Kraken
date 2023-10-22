namespace Baruah
{
    public interface INavigationAction
    {
        void Execute();
    }

    public abstract class BaseNavigationAction : INavigationAction
    {
        public abstract void Execute();
    }
}
