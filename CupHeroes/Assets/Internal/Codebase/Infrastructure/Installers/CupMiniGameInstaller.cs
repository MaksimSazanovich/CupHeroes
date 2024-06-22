using Internal.Codebase.Runtime.CupMiniGame.BallSpawner;
using Internal.Codebase.Runtime.CupMiniGame.Cup;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Internal.Codebase.Infrastructure.Installers
{
    [DisallowMultipleComponent]
    public sealed class CupMiniGameInstaller : MonoInstaller
    {
        [SerializeField] private BallsSpawner ballsSpawner;
        [SerializeField] private Cup cup;
        [SerializeField] private CupDropController cupDropController;

        public override void InstallBindings()
        {
            Container.Bind<BallsSpawner>().FromInstance(ballsSpawner).AsSingle();
            Container.Bind<Cup>().FromInstance(cup).AsSingle();
            Container.Bind<CupDropController>().FromInstance(cupDropController).AsSingle();
        }
    }
}