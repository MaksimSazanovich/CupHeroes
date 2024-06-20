using Internal.Codebase.Runtime.UI.MainUI.LoadingCurtain;

namespace Internal.Codebase.Infrastructure.Factories.MainUIFactory
{
    public interface IMainUIFactory
    {
        public Curtain CreateCurtain();
    }
}