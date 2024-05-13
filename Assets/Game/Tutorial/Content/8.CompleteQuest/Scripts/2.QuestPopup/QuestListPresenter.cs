using System;
using System.Collections.Generic;
using System.Linq;
using Game.Gameplay.Player;
using Game.Meta;
using GameSystem;
using UnityEngine;

namespace Game.Tutorial
{
    public sealed class QuestListPresenter : MonoBehaviour, IGameConstructElement
    {
        [SerializeField]
        private CompleteQuestConfig config;

        [SerializeField]
        private MissionView targetView;

        [SerializeField]
        private MissionView[] otherViews;

        private MissionsManager upgradesManager;

        private MoneyPanelAnimator_AddMoney moneyPanelAnimator;

        private readonly List<MissionPresenter> presenters;

        public QuestListPresenter()
        {
            this.presenters = new List<MissionPresenter>();
        }

        void IGameConstructElement.ConstructGame(GameContext context)
        {
            this.upgradesManager = context.GetService<MissionsManager>();
            this.moneyPanelAnimator = context.GetService<MoneyPanelAnimator_AddMoney>();
        }

        public void Show()
        {
            this.InitMissions();
        }

        public void Hide()
        {
            this.HideMissions();
            this.presenters.Clear();
        }

        private void InitMissions()
        {
            var targetDifficulty = this.config.missionConfig.Difficulty;
            var targetMission = this.upgradesManager.GetMission(targetDifficulty);
            this.CreatePresenter(targetMission, this.targetView);

            var otherMissions = this.upgradesManager
                .GetMissions()
                .Where(it => it.Difficulty != targetDifficulty)
                .ToArray();

            var otherCount = Math.Min(this.otherViews.Length, otherMissions.Length);
           
            for (var i = 0 ; i < otherCount; i++)
            {
                var mission = otherMissions[i];
                var view = this.otherViews[i];
                this.CreatePresenter(mission, view);
            }
        }

        private void CreatePresenter(Mission targetMission, MissionView view)
        {
            var targetPresenter = new MissionPresenter();
            
            targetPresenter.Construct(this.upgradesManager, this.moneyPanelAnimator);
            
            this.presenters.Add(targetPresenter);
            targetPresenter.Start(targetMission);
        }

        private void HideMissions()
        {
            for (int i = 0, count = this.presenters.Count; i < count; i++)
            {
                var presenter = this.presenters[i];
                presenter.Stop();
            }
        }
    }
}