using GD.Game.Graphics;
using GD.Game.UserInterface;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
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
                    t.Y = 30;
                }),
                CreateWindowContent(),
                new GDTexturedButton("cross")
                {
                    Position = new Vector2(20),
                    ClickAction = () => IsVisible.Value = false
                }
            }
        };

        protected abstract GDSpriteText CreateTitle();

        protected abstract Drawable CreateWindowContent();
    }
}
