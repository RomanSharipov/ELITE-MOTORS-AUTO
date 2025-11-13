namespace CodeBase.Infrastructure.Services
{
    public interface IAppStateService
    {
        public void AddState(IState state);
        public void Enter<TState>() where TState : IState;
    }
}
