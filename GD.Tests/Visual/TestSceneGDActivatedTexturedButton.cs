using GD.Game.UserInterface;
using osu.Framework.Testing;
using osu.Framework.Graphics;

namespace GD.Tests.Visual
{
    public class TestSceneGDActivatedTexturedButton : TestScene
    {
        public TestSceneGDActivatedTexturedButton()
        {
            Add(new GDActivatedTexturedButton("diff-legacy/Demon")
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre
            });
        }
    }
}
