using GD.Game.Graphics;
using GD.Game.UserInterface;
using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Colour;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Screens;
using osuTK;
using osuTK.Graphics;

namespace GD.Game.Screens.Search
{
    public class SearchScreen : GDScreen
    {
        [BackgroundDependencyLoader]
        private void load()
        {
            AddRangeInternal(new Drawable[]
            {
                new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Colour = new Color4(2, 100, 248, 255)
                },
                new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Colour = ColourInfo.GradientVertical(new Color4(0, 0, 0, 0), Color4.Black.Opacity(0.5f))
                },
                new GDSprite("select-corner")
                {
                    Anchor = Anchor.BottomLeft,
                    Origin = Anchor.BottomLeft
                },
                new GDSprite("select-corner", FlipOrientation.Horizontal)
                {
                    Anchor = Anchor.BottomRight,
                    Origin = Anchor.BottomLeft
                },
                new TexturedGDButton("back-arrow")
                {
                    Position = new Vector2(85),
                    ClickAction = this.Exit
                }
            });
        }
    }
}
