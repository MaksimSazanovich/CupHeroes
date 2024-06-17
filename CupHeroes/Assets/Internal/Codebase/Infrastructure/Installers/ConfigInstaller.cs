using Internal.Codebase.Runtime.CupMiniGame.Ball;
using Internal.Codebase.Runtime.UI.MainUI.LoadingCurtain;
using UnityEngine;
using Zenject;

namespace Internal.Codebase.Infrastructure.Installers
{
    [DisallowMultipleComponent]
    public sealed class ConfigInstaller : MonoInstaller
    {
        [SerializeField] private CurtainConfig curtainConfig;
        [SerializeField] private BallConfig ballConfig;

        public override void InstallBindings()
        {
            Container.Bind<CurtainConfig>().FromInstance(curtainConfig).AsSingle();
            Container.Bind<BallConfig>().FromInstance(ballConfig).AsSingle();
        }
    }
}