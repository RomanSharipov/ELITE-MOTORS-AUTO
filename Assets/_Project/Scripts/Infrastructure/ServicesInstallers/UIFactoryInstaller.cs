using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.UI;
using CodeBase.Infrastructure.UI.Services;
using UnityEngine;
using UnityEngine.AddressableAssets;
using VContainer;

namespace CodeBase.Infrastructure.Installers
{
    [CreateAssetMenu(fileName = "UIFactoryInstaller",
        menuName = "ScriptableInstallers/UIFactoryInstaller")]
    public class UIFactoryInstaller : AScriptableInstaller
    {
        [SerializeField] private AssetReference _gameLoopWindow;
        [SerializeField] private AssetReference _mainMenu;
        
        public override void Install(IContainerBuilder builder)
        {
            Dictionary<Type, AssetReference> windowsData = new()
            {
                [typeof(GameLoopWindow)] = _gameLoopWindow,
                [typeof(MainMenu)] = _mainMenu

            };


            builder.Register<UIFactory>(Lifetime.Singleton)
                .WithParameter("windowsData", windowsData)
                .As<IUIFactory>();
        }
    }
}