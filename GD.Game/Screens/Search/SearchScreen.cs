using GD.Game.Graphics;
using GD.Game.Legacy;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osuTK.Graphics;

namespace GD.Game.Screens.Search
{
    public class SearchScreen : GDMenuScreen
    {
        protected override BackButtonColour BackButtonColour => BackButtonColour.Green;

        protected override Color4 BackgroundColour => LegacyColour.BlueSky.FromLegacy();

        protected override Drawable CreateContent() => new Container
        {
            RelativeSizeAxes = Axes.Both,
            Children = new Drawable[]
            {
                new GDSprite("select-corner")
                {
                    Anchor = Anchor.BottomLeft,
                    Origin = Anchor.BottomLeft
                },
                new GDSprite("select-corner", FlipOrientation.Horizontal)
                {
                    Anchor = Anchor.BottomRight,
                    Origin = Anchor.BottomLeft
                }
            }
        };
    }
}
