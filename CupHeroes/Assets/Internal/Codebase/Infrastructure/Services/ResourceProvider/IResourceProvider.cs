using System.Threading.Tasks;
using Internal.Codebase.Runtime.CupMiniGame.Ball;
using Internal.Codebase.Runtime.UI.MainUI.LoadingCurtain;
using Internal.Codebase.UI.MainUI.LoadingCurtain;
using UnityEngine;

namespace Internal.Codebase.Infrastructure.Services.ResourceProvider
{
    public interface IResourceProvider
    {
        public CurtainConfig LoadCurtainConfig();

        public BallConfig LoadBallConfig();
    }
}