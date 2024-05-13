using System;
using Game.Meta;
using UnityEngine;

namespace Game.Tutorial
{
    public sealed class QuestInspector
    {
        private CompleteQuestConfig config;
        
        private MissionsManager missionsManager;

        private Mission targetMission;
        
        private Action callback;
        
        public void Construct(MissionsManager missionsManager, CompleteQuestConfig targetConfig)
        {
            this.missionsManager = missionsManager;
            this.config = targetConfig;
            this.targetMission = missionsManager.GetMission(targetConfig.missionConfig.Difficulty);
        }
        
        public void Inspect(Action callback)
        {
            this.callback = callback;
            this.targetMission = this.missionsManager.GetMission(this.config.missionConfig.Difficulty);
            this.missionsManager.OnRewardReceived += OnComplete;
        }

        private void OnComplete(Mission mission)
        {
            if (mission != this.targetMission) 
                return;
            this.missionsManager.OnRewardReceived -= OnComplete;
            this.targetMission = null;
            this.callback?.Invoke();
        }
    }
}