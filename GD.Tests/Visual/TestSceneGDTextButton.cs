using GD.Game.Graphics;
using GD.Game.UserInterface;
using osu.Framework.Testing;
using osu.Framework.Graphics;

namespace GD.Tests.Visual
{
    public class TestSceneGDTextButton : TestScene
    {
        public TestSceneGDTextButton()
        {
            Add(new GDActivatedTextButton("Activated button", 50, Typeface.GDFont)
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre
            });
        }
    }
}
