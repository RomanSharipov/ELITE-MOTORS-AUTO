using CodeBase.Infrastructure.Services;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace CodeBase.Infrastructure.Installers
{
    [CreateAssetMenu(fileName = "StatemachineInstaller",
    menuName = "ScriptableInstallers/StatemachineInstaller")]

    public class StatemachineInstaller : AScriptableInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            GameStatemachine mainGameStatemachine = new GameStatemachine();
            GameStatemachine gameLoopStatemachine = new GameStatemachine();
            
            builder.Register<AppStateService>(Lifetime.Singleton)
                .WithParameter("mainGameStatemachine", mainGameStatemachine)
                .As<IAppStateService>();

            RegisterStates(builder);
            
            builder.RegisterEntryPoint<EntryPoint>();
        }
        
        private void RegisterStates(IContainerBuilder builder)
        {
            builder.Register<BootstrapState>(Lifetime.Singleton)
                .AsSelf();
            builder.Register<MenuState>(Lifetime.Singleton)
                .AsSelf();
            builder.Register<GameLoopState>(Lifetime.Singleton)
                .AsSelf();
        }
    }
}
