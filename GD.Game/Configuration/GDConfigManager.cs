using osu.Framework.Configuration;
using osu.Framework.Platform;

namespace GD.Game.Configuration
{
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
