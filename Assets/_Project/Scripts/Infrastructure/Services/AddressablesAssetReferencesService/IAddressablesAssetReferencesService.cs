using System.Collections.Generic;
using UnityEngine.AddressableAssets;

namespace CodeBase.Infrastructure.Services
{
    public interface IAddressablesAssetReferencesService
    {
        public IReadOnlyDictionary<string, AssetReference> SceneAssetReferences { get; }
        
        public IReadOnlyList<AssetReference> LevelReferences { get; }
    }
}