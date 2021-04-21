using GD.Game.Screens.Select.Carousel;
using osu.Framework.Testing;
using osu.Framework.Graphics;
using osuTK.Graphics;
using osuTK;
using GD.Game.Legacy;

namespace GD.Tests.Visual
{
    public class TestSceneDrawableCarouselItem : TestScene
    {
        public TestSceneDrawableCarouselItem()
        {
            Add(new DrawableCarouselItem
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Item = { Value = new DefaultLevel
                {
                    StarDiff = 10,
                    Colour = Color4.Red,
                    Name = "Test Item",
                    LegacyDiff = LegacyDiff.Hard,
                    PracticeProgress = 50,
                    Progress = 69,
                    CoinsTaken = new[] { 1, 3 },
                    Orbs = new Vector2(225, 100)
                }}
            });
        }
    }
}
