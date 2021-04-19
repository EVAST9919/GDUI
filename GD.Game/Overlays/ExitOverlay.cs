using System;
using GD.Game.Graphics;
using GD.Game.UserInterface;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osuTK;
using osuTK.Graphics;

namespace GD.Game.Overlays
{
    public class ExitOverlay : JumpingOverlay
    {
        public Action ConfirmAction { get; set; }

        protected override Drawable CreateWindow() => new Container
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            Size = new Vector2(1000, 480),
            Children = new Drawable[]
            {
                new GDSprite("overlay", baseScale: 1f)
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre
                },
                new GDGoldSpriteText(75)
                {
                    Text = "Quit Game",
                    Anchor = Anchor.TopCentre,
                    Origin = Anchor.TopCentre,
                    Y = 60
                },
                new TextFlowContainer(t => t.Font = GDFont.GetFont(Typeface.Arial, 55))
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    AutoSizeAxes = Axes.Both,
                    Y = -20
                }.With(t =>
                {
                    t.AddText("Are you sure you want to ");
                    t.AddText("Quit", s => s.Colour = new Color4(249, 93, 92, 255));
                    t.AddText("?");
                }),
                new GDColoredButton("Cancel", ButtonColour.Green)
                {
                    Anchor = Anchor.BottomCentre,
                    Width = 350,
                    Position = new Vector2(-130, -105),
                    ClickAction = () => IsVisible.Value = false
                },
                new GDColoredButton("Yes", ButtonColour.Green)
                {
                    Anchor = Anchor.BottomCentre,
                    Width = 220,
                    Position = new Vector2(200, -105),
                    ClickAction = () => ConfirmAction?.Invoke()
                }
            }
        };
    }
}
