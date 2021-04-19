using osu.Framework.Testing;
using osu.Framework.Graphics;
using GD.Game.UserInterface;
using osuTK;

namespace GD.Tests.Visual
{
    public class TestSceneTexturedButton : TestScene
    {
        public TestSceneTexturedButton()
        {
            Add(new TexturedGDButton("play")
            {
                Anchor = Anchor.Centre,
                Size = new Vector2(350),
                ClickAction = () => { }
            });
        }
    }
}
