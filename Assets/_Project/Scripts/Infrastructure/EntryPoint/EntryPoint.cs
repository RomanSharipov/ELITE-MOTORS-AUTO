using CodeBase.Infrastructure.Services;
using VContainer;
using VContainer.Unity;

namespace CodeBase.Infrastructure
{
    public class EntryPoint : IStartable
    {
        [Inject] private readonly IAppStateService _appStateService;
        
        [Inject] private readonly BootstrapState _bootstrapState;
        [Inject] private readonly GameLoopState _gameLoopState;
        [Inject] private readonly MenuState _menuState;
        
        void IStartable.Start()
        {
            _appStateService.AddState(_bootstrapState);
            _appStateService.AddState(_gameLoopState);
            _appStateService.AddState(_menuState);
            _appStateService.Enter<BootstrapState>();
        }
    }
}
