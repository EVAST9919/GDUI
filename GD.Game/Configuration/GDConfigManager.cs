using osu.Framework.Configuration;
using osu.Framework.Platform;
using osu.Framework.Testing;

namespace GD.Game.Configuration
{
    [ExcludeFromDynamicCompile]
    public class GDConfigManager : IniConfigManager<GDSetting>
    {
        protected override void InitialiseDefaults()
        {
        }

        public GDConfigManager(Storage storage)
            : base(storage)
        {
        }
    }

    public enum GDSetting
    {
    }
}
