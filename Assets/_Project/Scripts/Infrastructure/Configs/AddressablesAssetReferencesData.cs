using CodeBase.Infrastructure.Services;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CodeBase.Configs
{
    [CreateAssetMenu(fileName = "AddressablesAssetReferencesData", menuName = "StaticData/AddressablesAssetReferencesData")]
    public class AddressablesAssetReferencesData : ScriptableObject
    {
        public SceneReference[] SceneReferences;


        public AssetReference[] LevelReferences;
    
    }
}