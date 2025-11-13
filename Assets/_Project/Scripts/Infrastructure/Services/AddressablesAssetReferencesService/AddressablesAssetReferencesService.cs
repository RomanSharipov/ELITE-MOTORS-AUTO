using System.Collections.Generic;
using CodeBase.Configs;
using UnityEngine.AddressableAssets;

namespace CodeBase.Infrastructure.Services
{
    public class AddressablesAssetReferencesService : IAddressablesAssetReferencesService
    {
        private readonly AddressablesAssetReferencesData _assetReferencesData;

        public AddressablesAssetReferencesService(AddressablesAssetReferencesData assetReferencesData)
        {
            _assetReferencesData = assetReferencesData;
        }
        public IReadOnlyDictionary<string, AssetReference> SceneAssetReferences => 
            _assetReferencesData.SceneReferences.ToDictionary<AssetReference>();

        public IReadOnlyList<AssetReference> LevelReferences =>
            _assetReferencesData.LevelReferences;
    }
}   