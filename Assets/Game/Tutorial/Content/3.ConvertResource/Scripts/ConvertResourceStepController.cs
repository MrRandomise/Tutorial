using Game.Gameplay.Player;
using Game.Tutorial.App;
using Game.Tutorial.Gameplay;
using Game.Tutorial.UI;
using GameSystem;
using UnityEngine;

namespace Game.Tutorial
{
    [AddComponentMenu("Tutorial/Step «Convert Resource»")]

    public class ConvertResourceStepController : TutorialStepController
    {
        private PointerManager pointerManager;

        private NavigationManager navigationManager;

        private ScreenTransform screenTransform;
        
        private readonly ConvertResourceInspector inspector = new();

        [SerializeField]
        private ConvertResourceConfig config;

        [SerializeField]
        private ConvertResourcePanelShower panelShower = new();

        [SerializeField]
        private Transform pointerTransform;

        public override void ConstructGame(GameContext context)
        {
            this.pointerManager = context.GetService<PointerManager>();
            this.navigationManager = context.GetService<NavigationManager>();
            this.screenTransform = context.GetService<ScreenTransform>();

            var conveyorVisitInteractor = context.GetService<ConveyorVisitInteractor>();

            this.inspector.Construct(conveyorVisitInteractor, this.config);
            this.panelShower.Construct(this.config);

            base.ConstructGame(context);
        }


        protected override void OnStart()
        {
            TutorialAnalytics.LogEventAndCache("tutorial_step_3__convert_resource_started");
            this.inspector.Inspect(this.NotifyAboutCompleteAndMoveNext);

            var targetPosition = this.pointerTransform.position;
            this.pointerManager.ShowPointer(targetPosition, this.pointerTransform.rotation);
            this.navigationManager.StartLookAt(targetPosition);
            this.panelShower.Show(this.screenTransform.Value);
        }
        
        protected override void OnStop()
        {
            TutorialAnalytics.LogEventAndCache("tutorial_step_3__convert_resource_completed");
            this.navigationManager.Stop();
            this.pointerManager.HidePointer();
            this.panelShower.Hide();
        }
        
        
    }
}