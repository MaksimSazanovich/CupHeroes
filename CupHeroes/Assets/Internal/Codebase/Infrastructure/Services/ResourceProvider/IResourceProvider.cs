using Internal.Codebase.Runtime.CupMiniGame.Ball;
using Internal.Codebase.Runtime.CupMiniGame.BoosterLines.Multipliers;
using Internal.Codebase.Runtime.UI.MainUI.LoadingCurtain;

namespace Internal.Codebase.Infrastructure.Services.ResourceProvider
{
    public interface IResourceProvider
    {
        public CurtainConfig LoadCurtainConfig();
        public BallConfig LoadBallConfig();
        public MultipliersConfig LoadMultipliersConfig();
    }
}