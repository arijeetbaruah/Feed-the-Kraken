namespace Baruah.StateMachine
{
    public interface IState
    {
        void Initialize();
        void OnEnter();
        void OnUpdate(float deltaTime);
        void OnExit();
    }

    public abstract class BaseState : IState
    {
        public abstract void Initialize();
        public abstract void OnEnter();
        public abstract void OnExit();
        public abstract void OnUpdate(float deltaTime);
    }
}
