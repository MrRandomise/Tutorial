using System;
using Entities;
using Game.GameEngine;
using Game.Gameplay;
using Game.Gameplay.Conveyors;
using Game.Gameplay.Player;
using UnityEngine;

namespace Game.Tutorial
{
    public class TakeResourceInspector
    {
        private ConveyorVisitInteractor conveyorVisitInteractor;

        private TakeResourceConfig config;

        private Action callback;
        
        public void Construct(ConveyorVisitInteractor conveyorVisitInteractor, TakeResourceConfig config)
        {
            this.conveyorVisitInteractor = conveyorVisitInteractor;
            this.config = config;
        }

        public void Inspect(Action callback)
        {
            this.callback = callback;
            this.conveyorVisitInteractor.OutputZone.OnEntered += this.OnPlaceVisited;
        }
        private void OnPlaceVisited(IEntity entity)
        {
            if (!entity.TryGet(out IComponent_UnloadZone unloadZone)) return;
            if (unloadZone.ResourceType != config.targetResourceType) return;
            Debug.Log(unloadZone.CurrentAmount+" on visited");

            //if (unloadZone.IsEmpty) return;
            this.CompleteQuest();
        }

        private void CompleteQuest()
        {
            this.conveyorVisitInteractor.InputZone.OnEntered -= this.OnPlaceVisited;
            this.callback?.Invoke();
        }
    }
}