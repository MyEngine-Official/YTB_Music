using YtbMusic.Core.Systems;
using YotsubaEngine.Core.System.S_AGNOSTIC;


namespace YtbMusic.Core
{
    public class SystemRegistry
    {
        public void LoadAllCustomSystems()
        {
            SystemBuilder.AddSystem<SoundSystem>();
        }
    }
}
