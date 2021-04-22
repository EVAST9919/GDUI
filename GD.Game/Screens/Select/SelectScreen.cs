﻿using GD.Game.Graphics;
using GD.Game.Legacy;
using GD.Game.Screens.Select.Carousel;
using GD.Game.UserInterface;
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
                new GroundLine
                {
                    Anchor = Anchor.BottomCentre,
                    Origin = Anchor.BottomCentre,
                    Size = new Vector2(1380, 4),
                    Y = -165,
                    Alpha = 0.9f
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

        private GDSprite ground;

        private bool firstChange = true;

        private void onColourChanged(LegacyColour colour)
        {
            var converted = colour.FromLegacy();

            if (firstChange)
            {
                Background.Colour = converted;
                ground.Colour = converted;
                firstChange = false;
            }
            else
            {
                Background.FadeColour(converted, 500, Easing.Out);
                ground.FadeColour(converted, 500, Easing.Out);
            }
        }
    }
}
