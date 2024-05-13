using System;
using Game.App;
using Game.Localization;
using Game.Tutorial.Gameplay;
using Game.Tutorial.UI;
using UnityEngine;

namespace Game.Tutorial
{
    [Serializable]
    public class ConvertResourcePanelShower : InfoPanelShower
    {
        private ConvertResourceConfig config;

        public void Construct(ConvertResourceConfig config)
        {
            this.config = config;
        }

        protected override void OnShow()
        {
            var title = LocalizationManager.GetCurrentText(this.config.title);
            this.view.SetTitle(title);
            this.view.SetIcon(this.config.icon);

            LanguageManager.OnLanguageChanged += this.OnLanguageChanged;
        }

        protected override void OnHide()
        {
            LanguageManager.OnLanguageChanged -= this.OnLanguageChanged;
        }

        private void OnLanguageChanged(SystemLanguage language)
        {
            var title = LocalizationManager.GetText(this.config.title, language);
            this.view.SetTitle(title);
        }
    }
}