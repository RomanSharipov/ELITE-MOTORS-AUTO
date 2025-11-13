using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.UI;
using CodeBase.Infrastructure.UI.Services;
using Cysharp.Threading.Tasks;
using VContainer;
using UniRx;

namespace CodeBase.Infrastructure
{
    public class MenuState : IState
    {
        [Inject] private readonly IAssetProvider _assetProvider;
        [Inject] private readonly IWindowService _windowService;
        [Inject] private readonly IAppStateService _appStateService;

        private CompositeDisposable _compositeDisposable = new();

        [Inject]
        public MenuState()
        {

        }

        public async UniTask Enter()
        {
            _windowService.Open<MainMenu>(window =>
            {
                window.OnStartGameButton.Subscribe(_ =>
                {
                    _appStateService.Enter<GameLoopState>();
                }).AddTo(_compositeDisposable);
            }).Forget();
        }

        public UniTask Exit()
        {
            _windowService.CloseAllWindows();
            _assetProvider.Cleanup();
            return UniTask.CompletedTask;
        }
    }
}
