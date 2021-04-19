﻿using GD.Game.Graphics;
using GD.Game.UserInterface;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osuTK;

namespace GD.Game.Overlays
{
    public abstract class BrownOverlay : JumpingOverlay
    {
        protected override Drawable CreateWindow() => new Container
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            AutoSizeAxes = Axes.Both,
            Children = new Drawable[]
            {
                new GDSprite("window-brown", baseScale: 1f, useLarge: true)
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre
                },
                CreateTitle().With(t =>
                {
                    t.Anchor = Anchor.TopCentre;
                    t.Origin = Anchor.TopCentre;
                    t.Y = 25;
                }),
                CreateWindowContent(),
                new TexturedGDButton("cross")
                {
                    Position = new Vector2(20),
                    Size = new Vector2(150),
                    ClickAction = () => IsVisible.Value = false
                }
            }
        };

        protected abstract SpriteText CreateTitle();

        protected abstract Drawable CreateWindowContent();
    }
}
