using GD.Game.Graphics;
using osu.Framework.Testing;
using osu.Framework.Graphics;

namespace GD.Tests.Visual
{
    public class TestSceneGDSpriteText : TestScene
    {
        private readonly GDSpriteText text;

        public TestSceneGDSpriteText()
        {
            Add(text = new GDSpriteText(50, Typeface.GDFont)
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Text = "Test text lol"
            });
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();
            AddStep("Change size to 10", () => text.TextSize = 10);
            AddStep("Change size to 50", () => text.TextSize = 50);
            AddStep("Change size to 100", () => text.TextSize = 100);
        }
    }
}
