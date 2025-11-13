using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using VContainer;
using VContainer.Unity;

namespace CodeBase.Infrastructure.UI.Services
{
    public class UIFactory : IUIFactory
    {
        [Inject] private readonly IAssetProvider _assetProvider;
        [Inject] private readonly IObjectResolver _objectResolver;

        private readonly IReadOnlyDictionary<Type, AssetReference> _windowsData;
        
        [Inject]
        public UIFactory(IReadOnlyDictionary<Type, AssetReference> windowsData)
        {
            _windowsData = windowsData;
            
        }
        public async UniTask<TWindow> CreateWindow<TWindow>() where TWindow : WindowBase
        {
            GameObject prefab = await _assetProvider.Load<GameObject>(_windowsData[typeof(TWindow)]);
            GameObject newGameObject = GameObject.Instantiate(prefab);
            _objectResolver.InjectGameObject(newGameObject);
            TWindow windowComponent = newGameObject.GetComponent<TWindow>();
            return windowComponent;
        }
    }
    

}
