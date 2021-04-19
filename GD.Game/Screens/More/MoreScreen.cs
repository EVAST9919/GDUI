using GD.Game.Graphics;
using GD.Game.UserInterface;
using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Colour;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Screens;
using osuTK;
using osuTK.Graphics;

namespace GD.Game.Screens.More
{
    public class MoreScreen : GDScreen
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
                new GDSprite("select-corner", FlipOrientation.Vertical)
                {
                    Origin = Anchor.BottomLeft
                },
                new FillFlowContainer
                {
                    AutoSizeAxes = Axes.Both,
                    Direction = FillDirection.Vertical,
                    Spacing = new Vector2(50),
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Children = new[]
                    {
                        new FillFlowContainer
                        {
                            AutoSizeAxes = Axes.Both,
                            Direction = FillDirection.Horizontal,
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            Spacing = new Vector2(50),
                            Children = new[]
                            {
                                new BigButton("create"),
                                new BigButton("saved"),
                                new BigButton("scores")
                            }
                        },
                        new FillFlowContainer
                        {
                            AutoSizeAxes = Axes.Both,
                            Direction = FillDirection.Horizontal,
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            Spacing = new Vector2(50),
                            Children = new[]
                            {
                                new BigButton("quests"),
                                new BigButton("daily"),
                                new BigButton("weekly"),
                                new BigButton("gauntlets")
                            }
                        },
                        new FillFlowContainer
                        {
                            AutoSizeAxes = Axes.Both,
                            Direction = FillDirection.Horizontal,
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            Spacing = new Vector2(50),
                            Children = new[]
                            {
                                new BigButton("featured"),
                                new BigButton("fame"),
                                new BigButton("packs"),
                                new BigButton("search")
                            }
                        }
                    }
                },
                new TexturedGDButton("back-arrow-pink")
                {
                    Position = new Vector2(85),
                    ClickAction = this.Exit
                }
            });
        }

        private class BigButton : TexturedGDButton
        {
            public BigButton(string textureName)
                : base($"more-buttons/{textureName}", baseScale: 0.72f)
            {
                Anchor = Anchor.Centre;
            }
        }
    }
}
