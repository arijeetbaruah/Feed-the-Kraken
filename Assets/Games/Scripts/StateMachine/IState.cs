namespace Baruah.StateMachine
{
    public interface IState
    {
        void OnEnter();
        void OnUpdate(float deltaTime);
        void OnExit();
    }

    public abstract class BaseState : IState
    {
        protected IStateMachine stateMachine;

        public BaseState(IStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public abstract void OnEnter();
        public abstract void OnExit();
        public abstract void OnUpdate(float deltaTime);
    }
}
