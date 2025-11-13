using CodeBase.Infrastructure.Services;
using Cysharp.Threading.Tasks;
using VContainer;

namespace CodeBase.Infrastructure
{
    public class BootstrapState : IState
    {
        [Inject] private readonly IAssetProvider _assetProvider;
        [Inject] private readonly IAppStateService _appStateService;

        [Inject]
        public BootstrapState()
        {

        }

        public async UniTask Enter()
        {
            await _assetProvider.Initialize();
            _appStateService.Enter<MenuState>();
        }

        public  UniTask Exit()
        {
            return UniTask.CompletedTask;
        }
    }
}
