using Internal.Codebase.Infrastructure.Factories.BallsFactory;
using Internal.Codebase.Infrastructure.Factories.MainUIFactory;
using Internal.Codebase.Infrastructure.Factories.MultipliersFactory;
using UnityEngine;
using Zenject;

namespace Internal.Codebase.Infrastructure.Installers
{
    [DisallowMultipleComponent]
    public sealed class FactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IMainUIFactory>().To<MainUIFactory>().AsSingle().NonLazy();
            Container.Bind<IBallsFactory>().To<BallsFactory>().AsSingle().NonLazy();
            Container.Bind<IMultipliersFactory>().To<MultipliersFactory>().AsSingle().NonLazy();
        }
    }
}