using Cysharp.Threading.Tasks;
using Game.Gameplay.Player;
using Game.Tutorial.App;
using Game.Tutorial.Gameplay;
using Game.Tutorial.UI;
using GameSystem;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Tutorial
{
    [AddComponentMenu("Tutorial/Step «Take Resource»")]

    public class TakeResourceStepController : TutorialStepController
    {
        private PointerManager pointerManager;

        private NavigationManager navigationManager;

        private ScreenTransform screenTransform;
        
        private readonly TakeResourceInspector inspector = new();

        [SerializeField]
        private TakeResourceConfig config;

        [FormerlySerializedAs("panelShower")] [SerializeField]
        private TakeResourcePanelShower actionPanel = new();

        [SerializeField]
        private Transform pointerTransform;

        public override void ConstructGame(GameContext context)
        {
            this.pointerManager = context.GetService<PointerManager>();
            this.navigationManager = context.GetService<NavigationManager>();
            this.screenTransform = context.GetService<ScreenTransform>();

            var conveyorVisitInteractor = context.GetService<ConveyorVisitInteractor>();

            this.inspector.Construct(conveyorVisitInteractor, this.config);
            this.actionPanel.Construct(this.config);

            base.ConstructGame(context);
        }


        protected override void OnStart()
        {
            ShowTips().Forget();
            this.actionPanel.Show(this.screenTransform.Value);
        }

        private async UniTask ShowTips()
        {
            //4 sec is working time
            await UniTask.Delay(4*1000);
            TutorialAnalytics.LogEventAndCache("tutorial_step_4__take_resource_started");

            this.inspector.Inspect(this.NotifyAboutCompleteAndMoveNext);
            var targetPosition = this.pointerTransform.position;
            this.pointerManager.ShowPointer(targetPosition, this.pointerTransform.rotation);
            this.navigationManager.StartLookAt(targetPosition);
        }
        
        protected override void OnStop()
        {
            TutorialAnalytics.LogEventAndCache("tutorial_step_4__take_resource_completed");
            this.navigationManager.Stop();
            this.pointerManager.HidePointer();
            this.actionPanel.Hide();
        }
    }
}