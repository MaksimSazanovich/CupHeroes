using Internal.Codebase.Infrastructure.Constants;
using Internal.Codebase.Runtime.CupMiniGame.Ball;
using Internal.Codebase.Runtime.CupMiniGame.BoosterLines.Multipliers;
using Internal.Codebase.Runtime.UI.MainUI.LoadingCurtain;
using UnityEngine;

namespace Internal.Codebase.Infrastructure.Services.ResourceProvider
{
    public sealed class ResourceProvider : IResourceProvider
    {
        private CurtainConfig curtainConfig;
        private BallConfig ballConfig;
        private MultipliersConfig multipliersConfig;

        public CurtainConfig LoadCurtainConfig()
        {
            if (curtainConfig == null)
                curtainConfig = Resources.Load<CurtainConfig>(AssetPath.CurtainConfig);
            return curtainConfig;
        }

        public BallConfig LoadBallConfig()
        {
            if (ballConfig == null)
                ballConfig = Resources.Load<BallConfig>(AssetPath.BallConfig);
            return ballConfig;
        }

        public MultipliersConfig LoadMultipliersConfig()
        {
            if (multipliersConfig == null)
                multipliersConfig = Resources.Load<MultipliersConfig>(AssetPath.MultipliersConfig);
            return multipliersConfig;
        }
    }
}