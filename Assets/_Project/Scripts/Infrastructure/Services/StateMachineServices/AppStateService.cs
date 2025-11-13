namespace CodeBase.Infrastructure.Services
{
    public class AppStateService : IAppStateService
    {
        private GameStatemachine _mainGameStatemachine;
        
        public AppStateService(GameStatemachine mainGameStatemachine)
        {
            _mainGameStatemachine = mainGameStatemachine;
        }
        public void AddState(IState state)
        {
            _mainGameStatemachine.AddState(state.GetType(), state);
        }

        public void Enter<TState>() where TState : IState
        {
            _mainGameStatemachine.Enter<TState>();
        }
    }
}
