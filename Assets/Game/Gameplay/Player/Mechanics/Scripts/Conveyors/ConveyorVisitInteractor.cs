using System;
using Entities;
using Game.Gameplay.Conveyors;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Player
{
    public sealed class ConveyorVisitInteractor
    {
        [ReadOnly, ShowInInspector]
        public Zone InputZone { get; } = new();
        
        [ReadOnly, ShowInInspector]
        public Zone OutputZone { get; } = new();

        public sealed class Zone
        {
            public event Action<IEntity> OnEntered;
        
            public event Action<IEntity> OnExited;

            [ReadOnly]
            [ShowInInspector]
            public bool IsEntered { get; private set; }

            [ReadOnly]
            [ShowInInspector]
            public IEntity TargetConveyor { get; private set; }
        
            public void Enter(IEntity conveyor)
            {
                if (this.IsEntered)
                {
                    throw new Exception("Already entered into conveyor!");
                }
                this.TargetConveyor = conveyor;
                Debug.Log(TargetConveyor.Get<Component_Id>().Id);
                this.IsEntered = true;
                this.OnEntered?.Invoke(conveyor);
            }

            public void Exit()
            {
                if (!this.IsEntered)
                {
                    return;
                }
                Debug.Log(TargetConveyor.Get<Component_Id>().Id);

                var previousConveyor = this.TargetConveyor;
                this.TargetConveyor = null;
                this.IsEntered = false;
                this.OnExited?.Invoke(previousConveyor);
            }
        }
    }
}