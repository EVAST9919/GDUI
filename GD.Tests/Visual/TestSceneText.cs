using GD.Game.Graphics;
using osu.Framework.Testing;
using osu.Framework.Graphics;

namespace GD.Tests.Visual
{
    public class TestSceneText : TestScene
    {
        public TestSceneText()
        {
            Add(new GDGoldSpriteText(80)
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Text = "Test"
            });
        }
    }
}
