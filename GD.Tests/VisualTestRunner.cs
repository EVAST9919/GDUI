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
            using (DesktopGameHost host = Host.GetSuitableHost(@"GD-tests", true))
            {
                host.Run(new GDTestBrowser());
                return 0;
            }
        }
    }
}
