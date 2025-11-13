using CodeBase.CoreGamePlay;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.UI.Services;
using Cysharp.Threading.Tasks;
using VContainer;
using UniRx;
using CodeBase.Infrastructure.UI;

namespace CodeBase.Infrastructure
{
    public class GameLoopState : IState
    {
        [Inject] private readonly ILevelService _levelService;
        [Inject] private readonly IWindowService _windowService;
        [Inject] private readonly IAssetProvider _assetProvider;
        [Inject] private readonly IAppStateService _appStateService;
        
        private CompositeDisposable _compositeDisposable = new();

        public async UniTask Enter()
        {
            
            ISceneInitializer levelMain = await _levelService.LoadCurrentLevel();

            levelMain.InitializeSceneServices();

            _windowService.Open<GameLoopWindow>(window =>
            {
                window.OnGoToMenuButton.Subscribe(_ =>
                {
                    _appStateService.Enter<MenuState>();
                }).AddTo(_compositeDisposable);
            }).Forget();
        }
        
        public UniTask Exit()
        {
            _compositeDisposable.Clear();
            _windowService.CloseAllWindows();
            _levelService.UnLoadCurrentLevel();
            
            _assetProvider.Cleanup();
            return UniTask.CompletedTask;
        }
    }
}
