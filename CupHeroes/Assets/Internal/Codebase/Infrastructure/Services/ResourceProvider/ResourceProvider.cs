using Internal.Codebase.Infrastructure.Constants;
using Internal.Codebase.Runtime.CupMiniGame.Ball;
using Internal.Codebase.Runtime.UI.MainUI.LoadingCurtain;
using UnityEngine;

namespace Internal.Codebase.Infrastructure.Services.ResourceProvider
{
    public sealed class ResourceProvider : IResourceProvider
    {
        public CurtainConfig LoadCurtainConfig()
        {
            return Resources.Load<CurtainConfig>(AssetPath.CurtainConfig);
        }

        public BallConfig LoadBallConfig()
        {
            return Resources.Load<BallConfig>(AssetPath.BallConfig);
        }
    }
}