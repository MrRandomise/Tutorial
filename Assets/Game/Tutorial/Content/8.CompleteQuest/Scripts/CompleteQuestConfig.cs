using Game.GameEngine;
using Game.Localization;
using Game.Meta;
using Lessons.Meta;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Tutorial
{
    [CreateAssetMenu(
        fileName = "Config «Complete Quest»",
        menuName = "Tutorial/New Config «Complete Quest»"
    )]
    public sealed class CompleteQuestConfig : ScriptableObject
    {
        [FormerlySerializedAs("upgradeConfig")]
        [Header("Quest")]
        [SerializeField]
        public MissionConfig missionConfig;
        
        [SerializeField]
        public WorldPlaceType worldPlaceType =  WorldPlaceType.TAVERN;

        [SerializeField]
        public PopupName requiredPopupName = PopupName.MISSIONS;
        
        [Header("Meta")]
        [TranslationKey]
        [SerializeField]
        public string title = "KILL ENEMY";

        [SerializeField]
        public Sprite icon;
    }
}