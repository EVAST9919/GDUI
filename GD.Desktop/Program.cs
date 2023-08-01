using GD.Game;
using osu.Framework;
using osu.Framework.Platform;

namespace GD.Desktop
{
    public static class Program
    {
        public static void Main()
        {
            GameHost host = Host.GetSuitableDesktopHost(@"GD");
            host.Run(new GDGame());
        }
    }
}
