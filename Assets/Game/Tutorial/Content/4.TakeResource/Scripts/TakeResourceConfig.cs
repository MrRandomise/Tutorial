using Game.GameEngine;
using Game.GameEngine.GameResources;
using Game.Gameplay.Conveyors;
using Game.Localization;
using UnityEngine;

namespace Game.Tutorial
{
    [CreateAssetMenu(
        fileName = "Tutorial Step «Take Resource»",
        menuName = "Tutorial/New Tutorial Step «Take Resource»"
    )]
    public sealed class TakeResourceConfig : ScriptableObject
    {
        [Header("Quest")]
        [SerializeField]
        public ResourceType targetResourceType = ResourceType.LUMBER;
    
        [Header("Meta")]
        [TranslationKey]
        [SerializeField]
        public string title = "CONVERT TREE";

        [SerializeField]
        public Sprite icon;
    }
}