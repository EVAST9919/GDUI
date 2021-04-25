using GD.Game.Graphics;
using GD.Game.Legacy;
using GD.Game.Screens.Select.Carousel;
using GD.Game.TransformableExtensions;
using GD.Game.UserInterface;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osuTK;
using osuTK.Graphics;

namespace GD.Game.Screens.Select
{
    public class SelectScreen : GDMenuScreen
    {
        protected override BackButtonColour BackButtonColour => BackButtonColour.Green;

        protected override Color4 BackgroundColour => Color4.White;

        private Ground ground;

        protected override Drawable CreateContent() => new Container
        {
            RelativeSizeAxes = Axes.Both,
            Children = new Drawable[]
            {
                ground = new Ground(false)
                {
                    Y = 135
                },
                new GDSpriteText(42)
                {
                    Anchor = Anchor.BottomCentre,
                    Origin = Anchor.BottomCentre,
                    Text = "Download the soundtracks",
                    Y = -95
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
                new GDSprite("select-top", useLarge: true)
                {
                    Anchor = Anchor.TopCentre,
                    Origin = Anchor.TopCentre
                },
                new DrawableCarousel
                {
                    Items = Dictionaries.DEFAULT_LEVELS.ToArray(),
                    ColourChanged = onColourChanged
                },
                new GDTexturedButton("info-icon")
                {
                    Anchor = Anchor.TopRight,
                    Position = new Vector2(-70, 70)
                }
            }
        };

        private bool firstChange = true;

        private void onColourChanged(LegacyColour colour)
        {
            var converted = colour.ToColor4();

            if (firstChange)
            {
                Background.Colour = converted;
                ground.SpriteColour = converted.Darken(0.2f);
                firstChange = false;
            }
            else
            {
                Background.FadeColour(converted, 500, Easing.Out);
                ground.FadeSpeiteColour(converted.Darken(0.2f), 500, Easing.Out);
            }
        }
    }
}
