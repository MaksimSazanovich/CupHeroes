using System;
using Internal.Codebase.Infrastructure.Factories.MainUIFactory;
using Internal.Codebase.Runtime.UI.MainUI.LoadingCurtain;
using Zenject;

namespace Internal.Codebase.Infrastructure.Services.LoadingCurtain
{
    class CurtainService : ICurtainService
    {
        private IMainUIFactory mainUIFactory;
        private Curtain curtain;

        [Inject]
        private void Constructor(IMainUIFactory mainUIFactory) =>
            this.mainUIFactory = mainUIFactory;

        public void Init() =>
            curtain = mainUIFactory.CreateCurtain();

        public void ShowCurtain(bool isAnimated, Action callback = null) =>
            curtain.ShowCurtain(isAnimated, callback);

        public void HideCurtain(float startDelay, Action callback = null) =>
            curtain.HideCurtain(startDelay, callback);
    }
}