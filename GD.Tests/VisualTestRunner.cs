using System;
using osu.Framework;
using osu.Framework.Platform;

namespace GD.Tests
{
    public static class TestSceneButton
    {
        [STAThread]
        public static int Main(string[] args)
        {
            using (DesktopGameHost host = Host.GetSuitableDesktopHost(@"GD-tests"))
            {
                host.Run(new GDTestBrowser());
                return 0;
            }
        }
    }
}
