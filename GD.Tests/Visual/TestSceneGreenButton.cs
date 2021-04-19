using GD.Game.UserInterface;
using osu.Framework.Testing;
using osu.Framework.Graphics;
using osuTK;

namespace GD.Tests.Visual
{
    public class TestSceneGreenButton : TestScene
    {
        public TestSceneGreenButton()
        {
            Add(new GDColoredButton("test", ButtonColour.Green)
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Size = new Vector2(250, 100),
                ClickAction = () => { }
            });
        }
    }
}
