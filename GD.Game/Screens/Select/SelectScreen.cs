using GD.Game.Graphics;
using GD.Game.Screens.Select.Carousel;
using GD.Game.UserInterface;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osuTK;
using osuTK.Graphics;

namespace GD.Game.Screens.Select
{
    public class SelectScreen : GDMenuScreen
    {
        protected override BackButtonColour BackButtonColour => BackButtonColour.Green;

        protected override Color4 BackgroundColour => Color4.White;

        protected override Drawable CreateContent() => new Container
        {
            RelativeSizeAxes = Axes.Both,
            Children = new Drawable[]
            {
                ground = new GDSprite("select-ground", baseScale: 1f, useLarge: true)
                {
                    Anchor = Anchor.BottomCentre,
                    Origin = Anchor.Centre,
                    Y = 30,
                    Alpha = 0.5f
                },
                new Sprite
                {
                    Anchor = Anchor.BottomCentre,
                    Origin = Anchor.BottomCentre,
                    Size = new Vector2(1300, 4),
                    Y = -165,
                    Alpha = 0.9f,
                    Texture = Textures.Get("ground-line")
                },
                new GDSpriteText(42)
                {
                    Anchor = Anchor.BottomCentre,
                    Origin = Anchor.BottomCentre,
                    Text = "Download the soundtracks",
                    Y = -100
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
                    Items = new[]
                    {
                        new CarouselItem { Colour = Color4.Blue, Name = "Stereo Madness", StarDiff = 1, LegacyDiff = LegacyDiff.Easy, Progress = 10, PracticeProgress = 100 },
                        new CarouselItem { Colour = Color4.Green, Name = "Back On Track", StarDiff = 2, LegacyDiff = LegacyDiff.Hard, Progress = 20, PracticeProgress = 90 },
                        new CarouselItem { Colour = Color4.Red, Name = "3", StarDiff = 3, LegacyDiff = LegacyDiff.Harder, Progress = 30, PracticeProgress = 80 },
                        new CarouselItem { Colour = Color4.Yellow, Name = "Cant Let Go", StarDiff = 4, LegacyDiff = LegacyDiff.Hard, Progress = 40, PracticeProgress = 70 },
                        new CarouselItem { Colour = Color4.Pink, Name = "5", StarDiff = 5, LegacyDiff = LegacyDiff.Normal, Progress = 50, PracticeProgress = 60 },
                        new CarouselItem { Colour = Color4.Purple, Name = "6", StarDiff = 6, LegacyDiff = LegacyDiff.Demon, Progress = 60, PracticeProgress = 50 }
                    },
                    ColourChanged = onColourChanged
                },
                new TexturedGDButton("info-icon")
                {
                    Anchor = Anchor.TopRight,
                    Position = new Vector2(-70, 70)
                }
            }
        };

        private GDSprite ground;

        private bool firstChange = true;

        private void onColourChanged(Color4 colour)
        {
            if (firstChange)
            {
                Background.Colour = colour;
                ground.Colour = colour;
                firstChange = false;
            }
            else
            {
                Background.FadeColour(colour, 500, Easing.Out);
                ground.FadeColour(colour, 500, Easing.Out);
            }
        }
    }
}
