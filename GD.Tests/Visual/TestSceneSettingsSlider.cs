using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics;
using osu.Framework.Testing;
using GD.Game.Overlays.Settings.Items.Controls;

namespace GD.Tests.Visual
{
    public class TestSceneSettingsSlider : TestScene
    {
        public TestSceneSettingsSlider()
        {
            Add(new Container
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Width = 200,
                AutoSizeAxes = Axes.Y,
                Child = new SettingsSlider
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre
                }
            });
        }
    }
}
