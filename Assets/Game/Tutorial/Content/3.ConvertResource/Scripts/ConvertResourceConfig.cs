using Game.GameEngine;
using Game.GameEngine.GameResources;
using Game.Gameplay.Conveyors;
using Game.Localization;
using UnityEngine;

namespace Game.Tutorial
{
    [CreateAssetMenu(
        fileName = "Tutorial Step «Convert Resource»",
        menuName = "Tutorial/New Tutorial Step «Convert Resource»"
    )]
    public sealed class ConvertResourceConfig : ScriptableObject
    {
        [Header("Quest")]
        [SerializeField]
        public ResourceType targetResourceType = ResourceType.WOOD;
    
        [Header("Meta")]
        [TranslationKey]
        [SerializeField]
        public string title = "CONVERT TREE";

        [SerializeField]
        public Sprite icon;
    }
}