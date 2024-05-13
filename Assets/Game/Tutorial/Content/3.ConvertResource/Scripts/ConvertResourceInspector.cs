using System;
using Entities;
using Game.GameEngine;
using Game.Gameplay.Player;

namespace Game.Tutorial
{
    public class ConvertResourceInspector
    {
        private ConveyorVisitInteractor worldPlaceVisitor;

        private ConvertResourceConfig config;

        private Action callback;

        public void Construct(ConveyorVisitInteractor worldPlaceVisitor, ConvertResourceConfig config)
        {
            this.worldPlaceVisitor = worldPlaceVisitor;
            this.config = config;
        }

        public void Inspect(Action callback)
        {
            this.callback = callback;
            this.worldPlaceVisitor.InputZone.OnEntered += this.OnPlaceVisited;
        }
        
        private void OnPlaceVisited(IEntity entity)
        {
            this.CompleteQuest();
        }

        private void CompleteQuest()
        {
            this.worldPlaceVisitor.InputZone.OnEntered -= this.OnPlaceVisited;
            this.callback?.Invoke();
        }
    }
}